using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitWallMaterialManager.WallSetter
{
    public class SetCompoundStructureCore
    {
        public bool IsChecked { get; set; }
        public Wall Wall { get; set; }
        public string WallName { get; set; }
        public WallType WallType { get; set; }
        public string LevelName { get; set; }
        public Material CoreMaterial { get; set; }
        public string CoreMaterialName => CoreMaterial?.Name ?? "<By Category>";

        public SetCompoundStructureCore(Wall wall, Material coreMaterial)
        {
            IsChecked = false;
            Wall = wall;
            WallName = wall.Name;
            WallType = wall.WallType;
            Level level = wall.Document.GetElement(wall.LevelId) as Level;
            LevelName = level?.Name ?? "";
            CoreMaterial = coreMaterial;
        }
    }
}