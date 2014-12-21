using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PackageModel
{
    [Serializable]
    public class GameModel
    {
        public ModelPart[] ModelParts;
        public ModelPartInstance[] Instances;

        public void Serialize(string Filename)
        {
            var xs = new Newtonsoft.Json.JsonSerializer();
            xs.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            xs.Formatting = Newtonsoft.Json.Formatting.Indented;
            var fs = new FileStream(Filename, FileMode.Create, FileAccess.ReadWrite);
            var wt = new StreamWriter(fs);
            xs.Serialize(wt, this);

            wt.Close();

            fs.Close();
        }

        public static GameModel Deserialize(string Filename)
        {
            Newtonsoft.Json.JsonSerializer xs = new Newtonsoft.Json.JsonSerializer();
            xs.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            FileStream fs = new FileStream(Filename, FileMode.Create, FileAccess.ReadWrite);
            var rt = new StreamReader(fs);
            var jrt = new Newtonsoft.Json.JsonTextReader(rt);
           var res = xs.Deserialize<GameModel>(jrt);

            jrt.Close();
            rt.Close();
            fs.Close();

            return res;
        }

    }
    public class ModelPart
    {
        public string Name;
        public string File;
    }
    public class ModelPartInstance
    {
        public string Name;
        public string ModelPart;
        public Matrix Matrix;
    }

}
