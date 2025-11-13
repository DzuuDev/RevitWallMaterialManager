using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitWallMaterialManager.Utils;
using RevitWallMaterialManager.WallSetter;

namespace RevitWallMaterialManager.UI
{
    public partial class FormSetCompoundStructureFinish : System.Windows.Forms.Form
    {
        private List<SetCompoundStructureCore> _listWallForSetFinish;
        private List<Material> _lstMaterials;
        private List<SetCompoundStructureFinish> _listWallFinish;
        private List<string> LayerType = new List<string>() { "None", "Exterior", "Structure", "Interior" };
        private List<CompoundLayerItem> _currentExteriorLayers;
        private CompoundLayerItem _currentStructureLayer;
        private List<CompoundLayerItem> _currentInteriorLayers;

        public FormSetCompoundStructureFinish(List<SetCompoundStructureCore> listWallForSetFinish, List<Material> lstMaterials)
        {
            InitializeComponent();
            _listWallForSetFinish = listWallForSetFinish;
            _lstMaterials = lstMaterials;

            cbbChooseLayers.DataSource = LayerType;
            cbbChooseLayers.DisplayMember = "Name";
            cbbMaterial.DataSource = _lstMaterials;
            cbbMaterial.DisplayMember = "Name";

            cbbMaterial.Enabled = false;
            btn_ChangeMaterial.Enabled = false;
            btn_DeleteLayerMaterial.Enabled = false;
            dgvExterior.Enabled = false;
            dgvInterior.Enabled = false;
            dgvStructure.Enabled = false;
            tboxInputThickness.Enabled = false;

            // Chế độ chọn toàn hàng
            dgvExterior.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExterior.MultiSelect = false;

            dgvInterior.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInterior.MultiSelect = false;

            dgvStructure.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Selection Exterior-Interior
            dgvExterior.SelectionChanged += dgvExterior_SelectionChanged;
            dgvInterior.SelectionChanged += dgvInterior_SelectionChanged;

            // Tổng hợp dữ liệu
            _listWallFinish = Common.BuildWallFinishList(listWallForSetFinish);
            LoadWallsToDataGridView();

            dgvWalls.SelectionChanged += dgvWalls_SelectionChanged;
            dgvWalls.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadWallsToDataGridView()
        {
            // Thiết lập DataGridView
            dgvWalls.Rows.Clear();

            // Thêm dữ liệu từng Wall
            foreach (var wallFinish in _listWallFinish)
            {
                dgvWalls.Rows.Add(wallFinish.Wall.Name);
            }
        }

        private void dgvWalls_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvWalls.SelectedRows.Count == 0) return;

            int selectedIndex = dgvWalls.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= _listWallFinish.Count) return;

            var selectedFinish = _listWallFinish[selectedIndex];
            var layers = selectedFinish.Layers;

            // Lấy core boundary từ CompoundStructure
            var cs = selectedFinish.Wall.WallType.GetCompoundStructure();

            if (cs == null) return;

            int firstCore = cs.GetFirstCoreLayerIndex();
            int lastCore = cs.GetLastCoreLayerIndex();

            if (firstCore < 0 || lastCore < 0) return;

            // Chia layer dựa theo core boundary
            _currentExteriorLayers = layers.Take(firstCore).ToList();
            _currentStructureLayer = layers[firstCore]; // nếu core nhiều lớp, có thể dùng Take(lastCore - firstCore + 1)
            _currentInteriorLayers = layers.Skip(lastCore + 1).ToList();

            // Load vào 3 DataGridView
            // Exterior
            dgvExterior.Rows.Clear();
            foreach (var layer in _currentExteriorLayers)
            {
                int rowIndex = dgvExterior.Rows.Add();
                dgvExterior.Rows[rowIndex].Cells["ColumnExterior"].Value = layer.Material?.Name ?? "<By Category>";
                dgvExterior.Rows[rowIndex].Cells["ColumnThicknessExterior"].Value =
                    UnitUtils.ConvertFromInternalUnits(layer.Thickness, UnitTypeId.Millimeters);
            }

            // Structure
            dgvStructure.Rows.Clear();
            int sIndex = dgvStructure.Rows.Add();
            dgvStructure.Rows[sIndex].Cells["ColumnStructure"].Value = _currentStructureLayer.Material?.Name ?? "<By Category>";
            dgvStructure.Rows[sIndex].Cells["ColumnThicknessStructure"].Value =
                UnitUtils.ConvertFromInternalUnits(_currentStructureLayer.Thickness, UnitTypeId.Millimeters);

            // Interior
            dgvInterior.Rows.Clear();
            foreach (var layer in _currentInteriorLayers)
            {
                int rowIndex = dgvInterior.Rows.Add();
                dgvInterior.Rows[rowIndex].Cells["ColumnInterior"].Value = layer.Material?.Name ?? "<By Category>";
                dgvInterior.Rows[rowIndex].Cells["ColumnThicknessInterior"].Value =
                    UnitUtils.ConvertFromInternalUnits(layer.Thickness, UnitTypeId.Millimeters);
            }
        }

        private void cbbChooseLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbbChooseLayers.SelectedItem?.ToString();
            bool enableControls = selected == "Exterior" || selected == "Structure" || selected == "Interior";

            // Enable/disable các nút và combobox
            cbbMaterial.Enabled = enableControls;
            btn_ChangeMaterial.Enabled = enableControls;
            btn_DeleteLayerMaterial.Enabled = enableControls;
            tboxInputThickness.Enabled = enableControls;

            // Enable/disable DataGridView tương ứng
            dgvExterior.Enabled = selected == "Exterior";
            dgvStructure.Enabled = selected == "Structure";
            dgvInterior.Enabled = selected == "Interior";
        }

        private void dgvExterior_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExterior.SelectedRows.Count == 0) return;

            int selectedIndex = dgvExterior.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= _currentExteriorLayers.Count) return;

            var selectedLayer = _currentExteriorLayers[selectedIndex];
            // Xử lý khi layer exterior được chọn
        }

        private void dgvInterior_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInterior.SelectedRows.Count == 0) return;

            int selectedIndex = dgvInterior.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= _currentInteriorLayers.Count) return;

            var selectedLayer = _currentInteriorLayers[selectedIndex];
            // Xử lý khi layer interior được chọn
        }

        private void btn_ChangeMaterial_Click(object sender, EventArgs e)
        {
            Material material = cbbMaterial.SelectedItem as Material;
            if (material == null) return;

            var selectedLayerType = cbbChooseLayers.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedLayerType)) return;

            // Lấy giá trị thickness từ textbox
            if (!double.TryParse(tboxInputThickness.Text, out double thicknessMm) || thicknessMm < 0.794)
            {
                MessageBox.Show("Vui lòng nhập độ dày hợp lệ (>0.794 mm).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tboxInputThickness.Focus();
                return;
            }

            // Chuyển sang đơn vị internal của Revit
            double thickness = UnitUtils.ConvertToInternalUnits(thicknessMm, UnitTypeId.Millimeters);

            if (selectedLayerType == "Exterior")
            {
                if (dgvExterior.SelectedRows.Count == 0) return;
                int selectedIndex = dgvExterior.SelectedRows[0].Index;
                if (selectedIndex < 0 || selectedIndex >= _currentExteriorLayers.Count) return;

                // Thay đổi layer đã chọn
                _currentExteriorLayers[selectedIndex].Material = material;
                _currentExteriorLayers[selectedIndex].Thickness = thickness;

                // Reload DataGridView
                dgvExterior.Rows.Clear();
                foreach (var layer in _currentExteriorLayers)
                {
                    int rowIndex = dgvExterior.Rows.Add();
                    dgvExterior.Rows[rowIndex].Cells["ColumnExterior"].Value = layer.Material?.Name ?? "<By Category>";
                    dgvExterior.Rows[rowIndex].Cells["ColumnThicknessExterior"].Value =
                        UnitUtils.ConvertFromInternalUnits(layer.Thickness, UnitTypeId.Millimeters);
                }
            }
            else if (selectedLayerType == "Structure")
            {
                if (_currentStructureLayer == null) return;

                _currentStructureLayer.Material = material;
                _currentStructureLayer.Thickness = thickness;

                dgvStructure.Rows[0].Cells["ColumnStructure"].Value = _currentStructureLayer.Material?.Name ?? "<By Category>";
                dgvStructure.Rows[0].Cells["ColumnThicknessStructure"].Value =
                    UnitUtils.ConvertFromInternalUnits(_currentStructureLayer.Thickness, UnitTypeId.Millimeters);
            }
            else if (selectedLayerType == "Interior")
            {
                if (dgvInterior.SelectedRows.Count == 0) return;
                int selectedIndex = dgvInterior.SelectedRows[0].Index;
                if (selectedIndex < 0 || selectedIndex >= _currentInteriorLayers.Count) return;

                // Thay đổi layer đã chọn
                _currentInteriorLayers[selectedIndex].Material = material;
                _currentInteriorLayers[selectedIndex].Thickness = thickness;

                // Reload DataGridView
                dgvInterior.Rows.Clear();
                foreach (var layer in _currentInteriorLayers)
                {
                    int rowIndex = dgvInterior.Rows.Add();
                    dgvInterior.Rows[rowIndex].Cells["ColumnInterior"].Value = layer.Material?.Name ?? "<By Category>";
                    dgvInterior.Rows[rowIndex].Cells["ColumnThicknessInterior"].Value =
                        UnitUtils.ConvertFromInternalUnits(layer.Thickness, UnitTypeId.Millimeters);
                }
            }
        }

        private void btn_DeleteLayerMaterial_Click(object sender, EventArgs e)
        {
            var selectedLayerType = cbbChooseLayers.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedLayerType)) return;

            if (selectedLayerType == "Exterior")
            {
                if (dgvExterior.SelectedRows.Count == 0) return;

                int selectedIndex = dgvExterior.SelectedRows[0].Index;
                if (selectedIndex < 0 || selectedIndex >= _currentExteriorLayers.Count) return;

                // Thay vì RemoveAt, chỉ set Material = null
                _currentExteriorLayers[selectedIndex].Material = null;

                // Reload DataGridView
                dgvExterior.Rows.Clear();
                foreach (var layer in _currentExteriorLayers)
                {
                    int rowIndex = dgvExterior.Rows.Add();
                    dgvExterior.Rows[rowIndex].Cells["ColumnExterior"].Value = layer.Material?.Name ?? "<By Category>";
                    dgvExterior.Rows[rowIndex].Cells["ColumnThicknessExterior"].Value =
                        UnitUtils.ConvertFromInternalUnits(layer.Thickness, UnitTypeId.Millimeters);
                }
            }
            else if (selectedLayerType == "Structure")
            {
                if (_currentStructureLayer == null) return;

                // Gán về "By Category"
                _currentStructureLayer.Material = null;
                dgvStructure.Rows[0].Cells["ColumnStructure"].Value = "<By Category>";
            }
            else if (selectedLayerType == "Interior")
            {
                if (dgvInterior.SelectedRows.Count == 0) return;

                int selectedIndex = dgvInterior.SelectedRows[0].Index;
                if (selectedIndex < 0 || selectedIndex >= _currentInteriorLayers.Count) return;

                // Thay vì RemoveAt, chỉ set Material = null
                _currentInteriorLayers[selectedIndex].Material = null;

                // Reload DataGridView
                dgvInterior.Rows.Clear();
                foreach (var layer in _currentInteriorLayers)
                {
                    int rowIndex = dgvInterior.Rows.Add();
                    dgvInterior.Rows[rowIndex].Cells["ColumnInterior"].Value = layer.Material?.Name ?? "<By Category>";
                    dgvInterior.Rows[rowIndex].Cells["ColumnThicknessInterior"].Value =
                        UnitUtils.ConvertFromInternalUnits(layer.Thickness, UnitTypeId.Millimeters);
                }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (dgvWalls.SelectedRows.Count == 0) return;

            int selectedIndex = dgvWalls.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= _listWallFinish.Count) return;

            var selectedWallFinish = _listWallFinish[selectedIndex];

            // Gọi trực tiếp hàm set compound structure, truyền 3 nhóm layer
            Common.SetCompoundStructureForWall(
                selectedWallFinish.Wall,
                _currentExteriorLayers,
                _currentStructureLayer,
                _currentInteriorLayers
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}