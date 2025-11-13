#region Name spaces

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitWallMaterialManager.UI;
using RevitWallMaterialManager.Utils;
using System.Collections.Generic;
using RevitWallMaterialManager.WallSetter;
using System.Windows.Forms;
using System;
using static RevitWallMaterialManager.UI.FormSetCompoundStructureCore;

#endregion Name spaces

namespace RevitWallMaterialManager.Command
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (commandData == null)
            {
                message = "CommandData is null.";
                return Result.Failed;
            }

            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            // Lấy dữ liệu cơ bản
            List<Wall> walls = Common.GetAllWalls(doc);
            List<Material> materials = Common.GetAllMaterials(doc);
            List<Level> levels = Common.GetAllLevels(doc);
            List<SetCompoundStructureCore> customData = Common.BuildCustomWallData(walls);
            List<WallType> wallTypeList = Common.FilterWallType(doc);

            using (FormSetCompoundStructureCore form = new FormSetCompoundStructureCore(customData, levels, materials, wallTypeList))
            {
                DialogResult result = form.ShowDialog();
                if (result != DialogResult.OK)
                    return Result.Cancelled;

                // Dữ liệu trả về từ form sẽ được xử lý trực tiếp trong các hàm nhỏ
            }

            return Result.Succeeded;
        }
    }
}