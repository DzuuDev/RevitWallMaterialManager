using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitWallMaterialManager.WallSetter
{
    public class SetCompoundStructureFinish
    {
        public Wall Wall { get; set; }
        public List<CompoundLayerItem> Layers { get; set; } = new List<CompoundLayerItem>();

        public SetCompoundStructureFinish(Wall wall)
        {
            Wall = wall;
            InitializeLayers();
        }

        private void InitializeLayers()
        {
            WallType wallType = Wall.WallType;
            CompoundStructure cs = wallType.GetCompoundStructure();
            if (cs == null) return;

            for (int i = 0; i < cs.LayerCount; i++)
            {
                Layers.Add(new CompoundLayerItem
                {
                    Material = cs.GetMaterialId(i).IntegerValue != 0
                               ? Wall.Document.GetElement(cs.GetMaterialId(i)) as Material
                               : null,
                    Thickness = cs.GetLayerWidth(i)
                });
            }
        }
    }

    public class CompoundLayerItem
    {
        public Material Material { get; set; }  // vật liệu của layer
        public double Thickness { get; set; }   // độ dày layer
    }
}