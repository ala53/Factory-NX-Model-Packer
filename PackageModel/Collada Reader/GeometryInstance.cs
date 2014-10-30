using ColladaDotNet;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PackageModel.Collada_Reader
{
    class GeometryInstance
    {
        public UniqueColladaGeometry Instanced;
        public GeometryInstance()
        {

        }
        public GeometryInstance(Collada_Instance_Geometry geometry, Matrix MulMatrix, Collada ColladaFile, Dictionary<string, ColladaGeometry> Geometries, MaterialList materials, TextureMap map)
        {
            string Url = geometry.URL.Substring(1);

            Dictionary<string, RectangleF> MaterialsDB = new Dictionary<string, RectangleF>();

            foreach (Collada_Instance_Material_Geometry material in geometry.Bind_Material[0].Technique_Common.Instance_Material)
            {
                var resolvedId = materials.ResolveMaterial(material.Target);
                var rect = map.TextureLocation(resolvedId);
                MaterialsDB.Add(material.Symbol, rect);
            }

            Instanced = Geometries[Url].MakeUniqueInstance(MulMatrix, MaterialsDB);
        }
    }
}
