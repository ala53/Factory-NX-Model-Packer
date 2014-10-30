using ColladaDotNet;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;

namespace PackageModel.Collada_Reader
{
    class MaterialList
    {
        public Dictionary<string, string> Materials = new Dictionary<string, string>();
        public List<Color> Colors = new List<Color>();
        public MaterialList(ColladaDotNet.Collada ColladaFile)
        {
            Dictionary<string, string> Textures = new Dictionary<string, string>();
            Dictionary<string, string> Effects = new Dictionary<string, string>();

            //Resolve Textures
            if (ColladaFile.Library_Images != null)
                foreach (Collada_Image img in ColladaFile.Library_Images.Image)
                {
                    Textures.Add(img.ID, img.Init_From.Value_As_String);
                }

            //Resolve Effects
            foreach (Collada_Effect effect in ColladaFile.Library_Effects.Effect)
            {
                //Resolve the chain 
                var technique = effect.Profile_COMMON[0].Technique;
                if (technique.Constant != null)
                {
                    //It's a "CONSTANT"/ a color
                    var floatArr = technique.Constant.Transparent.Color.Value();
                    Color col = new Color(
                        floatArr[0],
                        floatArr[1],
                        floatArr[2],
                        floatArr[3]);

                    Colors.Add(col);
                    Effects.Add(effect.ID, "@COLORPOLYGON" + col.PackedValue.ToString());

                    continue;
                }

                if (technique.Lambert.Diffuse.Color != null)
                {
                    var floatArr = technique.Lambert.Diffuse.Color.Value();
                    Color col = new Color(
                        floatArr[0],
                        floatArr[1],
                        floatArr[2],
                        floatArr[3]);

                    Colors.Add(col);
                    Effects.Add(effect.ID, "@COLORPOLYGON" + col.PackedValue.ToString());
                    continue;
                }

                if (technique.Lambert.Diffuse.Texture != null)
                {
                    var texId = effect.Profile_COMMON[0].New_Param[0].Surface.Init_From.Value_As_String;
                    Effects.Add(effect.ID, Textures[texId]);
                    continue;
                }
            } 

            //Resolve Materials

            foreach (Collada_Material material in ColladaFile.Library_Materials.Material)
            {
                Materials.Add(material.ID, Effects[material.Instance_Effect.URL.Substring(1)]);

            }
        }

        public string ResolveMaterial(string MaterialID)
        {
            if (MaterialID.StartsWith("#"))
                MaterialID = MaterialID.Substring(1);
            return Materials[MaterialID];
        }
    }
}
