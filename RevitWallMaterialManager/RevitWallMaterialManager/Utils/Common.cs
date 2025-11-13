using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using RevitWallMaterialManager.WallSetter;
using System;
using System.Text.RegularExpressions;

namespace RevitWallMaterialManager.Utils
{
    public class Common
    {
        /// <summary>
        /// Get all Walls in model
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<Wall> GetAllWalls(Document doc)
        {
            if (doc == null) return new List<Wall>();

            FilteredElementCollector collector = new FilteredElementCollector(doc)
                .OfClass(typeof(Wall))
                .WhereElementIsNotElementType();

            List<Wall> walls = new List<Wall>();
            foreach (Element e in collector)
            {
                if (e is Wall w)
                    walls.Add(w);
            }

            return walls;
        }

        /// <summary>
        /// Lấy toàn bộ Level trong model
        /// </summary>
        public static List<Level> GetAllLevels(Document doc)
        {
            if (doc == null) return new List<Level>();

            FilteredElementCollector collector = new FilteredElementCollector(doc)
                .OfClass(typeof(Level))
                .WhereElementIsNotElementType();

            List<Level> levels = new List<Level>();
            foreach (Element e in collector)
            {
                if (e is Level lvl)
                    levels.Add(lvl);
            }

            return levels;
        }

        /// <summary>
        /// Lọc tường theo level được chọn
        /// </summary>
        /// <param name="walls"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static List<Wall> FilterWallsByLevel(List<Wall> walls, Level level)
        {
            if (walls == null || level == null)
                return new List<Wall>();

            return walls.Where(w => w.LevelId == level.Id).ToList();
        }

        /// <summary>
        /// filter wall type
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<WallType> FilterWallType(Document doc)
        {
            if (doc == null) return new List<WallType>();

            return new FilteredElementCollector(doc)
                .OfClass(typeof(WallType))
                .Cast<WallType>()
                .ToList();
        }

        /// <summary>
        /// Lấy toàn bộ vật liệu trong model
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<Material> GetAllMaterials(Document doc)
        {
            if (doc == null) return new List<Material>();

            FilteredElementCollector collector = new FilteredElementCollector(doc)
                .OfClass(typeof(Material))
                .WhereElementIsNotElementType();

            List<Material> materials = new List<Material>();
            foreach (Element e in collector)
            {
                if (e is Material mat)
                    materials.Add(mat);
            }

            return materials;
        }

        /// <summary>
        /// Cập nhật lại lớp vật liệu core cấu trúc của tường
        /// </summary>
        /// <param name="walls"></param>
        /// <param name="newMaterial"></param>
        public static void SetWallsCoreMaterial(List<Wall> walls, Material newMaterial)
        {
            if (walls == null || walls.Count == 0 || newMaterial == null) return;

            foreach (Wall wall in walls)
            {
                WallType wallType = wall.WallType;
                if (wallType == null) continue;

                CompoundStructure cs = wallType.GetCompoundStructure();
                if (cs == null) continue;

                IList<CompoundStructureLayer> layers = cs.GetLayers();
                for (int i = 0; i < layers.Count; i++)
                {
                    if (layers[i].Function == MaterialFunctionAssignment.Structure)
                    {
                        cs.SetMaterialId(i, newMaterial.Id);
                        wallType.SetCompoundStructure(cs);
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="walls"></param>
        /// <returns></returns>
        public static List<SetCompoundStructureCore> BuildCustomWallData(List<Wall> walls)
        {
            if (walls == null || walls.Count == 0)
                return new List<SetCompoundStructureCore>();

            return walls.Select(wall =>
            {
                Material coreMat = GetCoreMaterial(wall);
                return new SetCompoundStructureCore(wall, coreMat);
            }).ToList();
        }

        private static Material GetCoreMaterial(Wall wall)
        {
            if (wall == null) return null;

            WallType wallType = wall.WallType;
            if (wallType == null) return null;

            CompoundStructure cs = wallType.GetCompoundStructure();
            if (cs == null) return null;

            int coreStart = cs.GetFirstCoreLayerIndex();
            if (coreStart < 0) return null;

            var layers = cs.GetLayers();
            if (coreStart >= layers.Count) return null;

            CompoundStructureLayer coreLayer = layers[coreStart];
            return wall.Document.GetElement(coreLayer.MaterialId) as Material;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="_levels"></param>
        /// <param name="firstDefaultDisplayWall"></param>
        /// <returns></returns>
        public static List<string> GetLevelNamesWithDefault(List<Level> _levels, string firstDefaultDisplayWall)
        {
            var levelNames = new List<string> { firstDefaultDisplayWall };
            levelNames.AddRange(_levels.Select(l => l.Name));
            return levelNames;
        }

        /// <summary>
        /// Update compound structure walls
        /// </summary>
        /// <param name="wallList"></param>
        /// <param name="materialForUpdate"></param>
        public static void UpdateCoreCompoundStructureForWall(
            List<SetCompoundStructureCore> wallList,
            Material materialForUpdate,
            List<WallType> wallTypeList)
        {
            if (wallList == null || wallList.Count == 0) return;
            if (materialForUpdate == null || materialForUpdate.Id == ElementId.InvalidElementId) return;

            ElementId materialId = materialForUpdate.Id;

            // Cache WallType đã duplicate theo wall.Id
            Dictionary<int, WallType> duplicatedTypes = new Dictionary<int, WallType>();

            // Giả sử tất cả wall trong cùng Document
            Document doc = wallList.First().Wall.Document;

            using (Transaction t = new Transaction(doc, "Update Core Material"))
            {
                t.Start();

                foreach (var wallData in wallList)
                {
                    if (wallData?.Wall == null || wallData.WallType == null)
                        continue;

                    try
                    {
                        Wall wall = wallData.Wall;
                        WallType originalType = wall.WallType;
                        WallType targetType = null;

                        string wallIdSuffix = $"_{wall.Id.IntegerValue}";
                        bool hasOwnType = originalType.Name.EndsWith(wallIdSuffix, StringComparison.OrdinalIgnoreCase);

                        if (!hasOwnType)
                        {
                            // Lần đầu: duplicate riêng type cho tường
                            string baseName = originalType.Name; // giữ nguyên tên gốc
                            string newName = $"{baseName}_{wall.Id.IntegerValue}";

                            targetType = wallTypeList.FirstOrDefault(wt => wt.Name.Equals(newName, StringComparison.OrdinalIgnoreCase));
                            if (targetType == null)
                            {
                                targetType = originalType.Duplicate(newName) as WallType;
                                if (targetType != null)
                                    wallTypeList.Add(targetType);
                            }

                            duplicatedTypes[wall.Id.IntegerValue] = targetType;

                            // Gán WallType mới cho tường
                            if (targetType != null)
                                wall.WallType = targetType;
                        }
                        else
                        {
                            // Đã có type riêng → dùng lại
                            if (!duplicatedTypes.TryGetValue(wall.Id.IntegerValue, out targetType))
                                targetType = originalType;
                        }

                        if (targetType == null) continue;

                        // Lấy CompoundStructure và cập nhật vật liệu lõi
                        CompoundStructure cs = targetType.GetCompoundStructure();
                        if (cs == null) continue;

                        int coreIndex = cs.GetFirstCoreLayerIndex();
                        if (coreIndex < 0) continue;

                        cs.SetMaterialId(coreIndex, materialId);
                        targetType.SetCompoundStructure(cs);
                    }
                    catch (Exception ex)
                    {
                        TaskDialog.Show("Update Core Material Warning",
                            $"Không thể cập nhật wall '{wallData?.WallName}': {ex.Message}");
                    }
                }

                t.Commit();
            }

            TaskDialog.Show("Success", "Cập nhật vật liệu kết cấu thành công!");
        }

        /// <summary>
        /// Xóa compound structure walls
        /// </summary>
        /// <param name="wallList"></param>
        public static void DeleteCompoundStructureForWalls(List<SetCompoundStructureCore> wallList)
        {
            if (wallList == null || wallList.Count == 0) return;

            // Giả sử tất cả wall cùng Document
            Document doc = wallList.First().Wall.Document;

            using (Transaction t = new Transaction(doc, "Delete Core Material"))
            {
                t.Start();

                foreach (var wallData in wallList)
                {
                    if (wallData == null || wallData.WallType == null)
                        continue;

                    try
                    {
                        WallType wallType = wallData.WallType;
                        CompoundStructure cs = wallType.GetCompoundStructure();
                        if (cs == null) continue;

                        int coreIndex = cs.GetFirstCoreLayerIndex();
                        if (coreIndex < 0) continue;

                        // Đặt vật liệu core layer về By Category
                        cs.SetMaterialId(coreIndex, ElementId.InvalidElementId);

                        // Cập nhật lại cấu trúc tường
                        wallType.SetCompoundStructure(cs);
                    }
                    catch (Exception ex)
                    {
                        TaskDialog.Show("Delete Core Material Warning",
                            $"Không thể đặt core material về 'By Category' cho tường '{wallData?.WallName}': {ex.Message}");
                    }
                }

                t.Commit();
            }

            TaskDialog.Show("Success", "Xóa vật liệu kết cấu tường thành công!");
        }

        /// <summary>
        /// Custom Data Set Finish Compound layer walls
        /// </summary>
        /// <param name="coreList"></param>
        /// <returns></returns>
        public static List<SetCompoundStructureFinish> BuildWallFinishList(List<SetCompoundStructureCore> coreList)
        {
            var finishList = new List<SetCompoundStructureFinish>();

            foreach (var core in coreList)
            {
                var finish = new SetCompoundStructureFinish(core.Wall);

                var cs = core.Wall.WallType.GetCompoundStructure();
                if (cs != null)
                {
                    int firstCore = cs.GetFirstCoreLayerIndex();
                    int lastCore = cs.GetLastCoreLayerIndex();

                    // Nếu chỉ có 1 lớp core, gán CoreMaterial cho lớp đầu
                    if (firstCore >= 0 && firstCore < finish.Layers.Count)
                    {
                        finish.Layers[firstCore].Material = core.CoreMaterial;
                    }
                }

                finishList.Add(finish);
            }

            return finishList;
        }

        /// <summary>
        /// Áp dụng CompoundStructure cho wall dựa trên 3 nhóm layer: Exterior, Structure, Interior user thao tác truyền vào
        /// Transaction sẽ được mở bên trong hàm.
        /// </summary>
        public static void SetCompoundStructureForWall(
            Wall wall,
            List<CompoundLayerItem> exteriorLayers,
            CompoundLayerItem structureLayer,
            List<CompoundLayerItem> interiorLayers)
        {
            if (wall == null) return;
            Document doc = wall.Document;

            using (Transaction t = new Transaction(doc, "Set Compound Structure"))
            {
                try
                {
                    t.Start();

                    WallType originalType = wall.WallType;
                    WallType targetType = null;

                    // Kiểm tra xem tường đã có type riêng chưa
                    string wallIdSuffix = $"_{wall.Id.IntegerValue}";
                    bool hasOwnType = originalType.Name.EndsWith(wallIdSuffix, StringComparison.OrdinalIgnoreCase);

                    if (!hasOwnType)
                    {
                        // Tạo tên type mới dựa trên base name + wallId
                        string newName = $"{originalType.Name}_{wall.Id.IntegerValue}";

                        // Duplicate type
                        targetType = originalType.Duplicate(newName) as WallType;
                        if (targetType == null)
                            throw new Exception($"Duplicate WallType failed for wall {wall.Name}.");

                        wall.WallType = targetType; // gán tường dùng type duplicate
                    }
                    else
                    {
                        targetType = originalType;
                    }

                    // Lấy CompoundStructure của type duplicate
                    CompoundStructure cs = targetType.GetCompoundStructure();
                    if (cs == null)
                        throw new Exception($"WallType {targetType.Name} does not have a CompoundStructure.");

                    IList<CompoundStructureLayer> oldLayers = cs.GetLayers();
                    int firstCore = cs.GetFirstCoreLayerIndex();
                    int lastCore = cs.GetLastCoreLayerIndex();

                    // --- Exterior layers
                    for (int i = 0; i < firstCore; i++)
                    {
                        CompoundStructureLayer oldLayer = oldLayers[i];
                        CompoundLayerItem newData = (exteriorLayers != null && i < exteriorLayers.Count) ? exteriorLayers[i] : null;

                        double thickness = newData?.Thickness ?? oldLayer.Width;
                        ElementId matId = (newData?.Material != null) ? newData.Material.Id : ElementId.InvalidElementId; // By Category

                        cs.SetLayerWidth(i, thickness);
                        cs.SetMaterialId(i, matId);
                    }

                    // --- Core layers
                    for (int i = firstCore; i <= lastCore; i++)
                    {
                        CompoundStructureLayer oldLayer = oldLayers[i];

                        double thickness = structureLayer?.Thickness ?? oldLayer.Width;
                        ElementId matId = (structureLayer?.Material != null) ? structureLayer.Material.Id : ElementId.InvalidElementId;

                        cs.SetLayerWidth(i, thickness);
                        cs.SetMaterialId(i, matId);
                    }

                    // --- Interior layers
                    for (int i = lastCore + 1; i < oldLayers.Count; i++)
                    {
                        int idx = i - (lastCore + 1);
                        CompoundLayerItem newData = (interiorLayers != null && idx < interiorLayers.Count) ? interiorLayers[idx] : null;
                        CompoundStructureLayer oldLayer = oldLayers[i];

                        double thickness = newData?.Thickness ?? oldLayer.Width;
                        ElementId matId = (newData?.Material != null) ? newData.Material.Id : ElementId.InvalidElementId;

                        cs.SetLayerWidth(i, thickness);
                        cs.SetMaterialId(i, matId);
                    }

                    // Gán lại CompoundStructure cho WallType
                    targetType.SetCompoundStructure(cs);

                    t.Commit();
                    TaskDialog.Show("Success", $"Wall '{wall.Name}' updated successfully!");
                }
                catch (Exception ex)
                {
                    if (t.GetStatus() == TransactionStatus.Started)
                        t.RollBack();

                    TaskDialog.Show("Error", $"Không thể cập nhật tường '{wall.Name}': {ex.Message}");
                }
            }
        }
    }
}