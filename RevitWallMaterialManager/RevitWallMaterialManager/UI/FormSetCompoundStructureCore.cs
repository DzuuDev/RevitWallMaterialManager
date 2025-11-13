using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitWallMaterialManager.WallSetter;
using RevitWallMaterialManager.Utils;
using System.Windows.Media.Media3D;
using Material = Autodesk.Revit.DB.Material;

namespace RevitWallMaterialManager.UI
{
    public partial class FormSetCompoundStructureCore : System.Windows.Forms.Form
    {
        public enum CompoundActionType
        {
            None,
            Update,
            Delete
        }

        private string firstDefaultDisplayWall = "All";
        private List<string> listLevelsFilter = new List<string>();
        private bool checkAllWall = true;
        private List<Level> _levels = new List<Level>();
        private List<Material> _lstMaterials = new List<Material>();
        private List<SetCompoundStructureCore> _customDataWallDisplayOrigin = new List<SetCompoundStructureCore>();
        private List<SetCompoundStructureCore> customDataWallDisplaysByFilter = new List<SetCompoundStructureCore>();

        private List<WallType> _wallTypeList;
        public Material materialChooseForUpdate;
        public List<SetCompoundStructureCore> dataForUpdate = new List<SetCompoundStructureCore>();
        public CompoundActionType ActionType { get; private set; } = CompoundActionType.None;

        public FormSetCompoundStructureCore(List<SetCompoundStructureCore> CustomDataWallDisplay, List<Level> levels, List<Material> materials, List<WallType> wallTypeList)
        {
            InitializeComponent();
            _customDataWallDisplayOrigin = CustomDataWallDisplay;
            _levels = levels;
            _lstMaterials = materials;
            _wallTypeList = wallTypeList;
            listLevelsFilter = Common.GetLevelNamesWithDefault(_levels, firstDefaultDisplayWall);
            cbbMaterials.DataSource = _lstMaterials;
            cbbMaterials.DisplayMember = "Name";

            DgvWalls.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Load += FormWallMaterialManager_Load;
            cbbLevels.SelectedIndexChanged += cbbLevels_SelectedIndexChanged;

            DgvWalls.CellValueChanged += DgvWalls_CellValueChanged;
            DgvWalls.CurrentCellDirtyStateChanged += DgvWalls_CurrentCellDirtyStateChanged;
            _wallTypeList = wallTypeList;
        }

        private void FormWallMaterialManager_Load(object sender, EventArgs e)
        {
            // Gán dữ liệu tầng một lần
            cbbLevels.DataSource = listLevelsFilter;

            // Mặc định hiển thị toàn bộ
            ReloadDataGridView(_customDataWallDisplayOrigin);
        }

        private void cbbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLevel = cbbLevels.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedLevel)) return;

            if (selectedLevel == firstDefaultDisplayWall)
            {
                customDataWallDisplaysByFilter = _customDataWallDisplayOrigin.ToList();
            }
            else
            {
                customDataWallDisplaysByFilter = _customDataWallDisplayOrigin
                    .Where(w => w.LevelName == selectedLevel)
                    .ToList();
            }
            ReloadDataGridView(customDataWallDisplaysByFilter);
        }

        private void cbbMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            materialChooseForUpdate = cbbMaterials.SelectedItem as Material;
            if (materialChooseForUpdate == null) return;
        }

        private void ReloadDataGridView(List<SetCompoundStructureCore> wallList)
        {
            DgvWalls.Rows.Clear();
            foreach (var wallData in wallList)
            {
                int rowIndex = DgvWalls.Rows.Add();
                var row = DgvWalls.Rows[rowIndex];

                row.Cells["ColumnCheckbox"].Value = wallData.IsChecked;
                row.Cells["ColumnWalls"].Value = wallData.WallName;
                row.Cells["ColumnCoreStructure"].Value = wallData.CoreMaterialName;

                row.Tag = wallData; // quan trọng: giữ reference object gốc
            }
            tboxCount.Text = wallList.Count.ToString();
        }

        private List<SetCompoundStructureCore> GetSelectedWalls()
        {
            var selectedWalls = new List<SetCompoundStructureCore>();

            foreach (DataGridViewRow row in DgvWalls.Rows)
            {
                if (row.Cells["ColumnCheckbox"].Value is bool val && val)
                {
                    if (row.Tag is SetCompoundStructureCore wallData)
                    {
                        wallData.IsChecked = true; // đã đồng bộ từ CellValueChanged rồi
                        selectedWalls.Add(wallData);
                    }
                }
            }

            return selectedWalls;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            dataForUpdate = GetSelectedWalls();

            if (dataForUpdate.Count > 0)
            {
                Common.UpdateCoreCompoundStructureForWall(dataForUpdate, materialChooseForUpdate, _wallTypeList);

                ActionType = CompoundActionType.Update;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Define.ShowWarning("Không có tường nào được chọn, vui lòng chọn lại!");
            }
        }

        private void btn_DeleteCompoundStructure_Click(object sender, EventArgs e)
        {
            dataForUpdate = GetSelectedWalls();
            if (dataForUpdate.Count > 0)
            {
                Common.DeleteCompoundStructureForWalls(dataForUpdate);
                ActionType = CompoundActionType.Delete;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Define.ShowWarning("Không có tường nào được chọn, vui lòng chọn lại!");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_CheckAllCheckBox_Click(object sender, EventArgs e)
        {
            if (checkAllWall == true)
            {
                foreach (DataGridViewRow row in DgvWalls.Rows)
                {
                    row.Cells["ColumnCheckbox"].Value = true;
                }
                checkAllWall = false;
            }
            else
            {
                foreach (DataGridViewRow row in DgvWalls.Rows)
                {
                    row.Cells["ColumnCheckbox"].Value = false;
                }
                checkAllWall = true;
            }
        }

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = tboxSearch.Text.Trim().ToLower();

            // Quyết định baseList dựa trên lựa chọn combobox
            var selectedLevel = cbbLevels.SelectedItem?.ToString() ?? firstDefaultDisplayWall;
            var baseList = selectedLevel == firstDefaultDisplayWall
                ? _customDataWallDisplayOrigin
                : customDataWallDisplaysByFilter; // có thể là empty list

            // Nếu baseList là null phòng trường hợp chưa được khởi tạo
            if (baseList == null) baseList = new List<SetCompoundStructureCore>();

            var filteredList = string.IsNullOrEmpty(keyword)
                ? baseList
                : baseList.Where(w =>
                      (w.WallName ?? "").ToLower().Contains(keyword) ||
                      (w.CoreMaterialName ?? "").ToLower().Contains(keyword))
                  .ToList();

            ReloadDataGridView(filteredList);
        }

        private void DgvWalls_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvWalls.IsCurrentCellDirty && DgvWalls.CurrentCell is DataGridViewCheckBoxCell)
            {
                DgvWalls.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvWalls_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (DgvWalls.Columns[e.ColumnIndex].Name != "ColumnCheckbox") return;

            var row = DgvWalls.Rows[e.RowIndex];
            bool isChecked = row.Cells["ColumnCheckbox"].Value is bool val && val;
            var wallData = row.Tag as SetCompoundStructureCore; // gán Tag khi reload

            if (wallData != null)
                wallData.IsChecked = isChecked;
        }

        private void btn_CustomMaterialFinish_Click(object sender, EventArgs e)
        {
            dataForUpdate = GetSelectedWalls();

            if (dataForUpdate.Count > 0)
            {
                using (var form = new FormSetCompoundStructureFinish(dataForUpdate, _lstMaterials))
                {
                    form.ShowDialog();
                }
            }
            else
            {
                Define.ShowWarning("Không có tường nào được chọn, vui lòng chọn lại!");
            }
        }
    }
}