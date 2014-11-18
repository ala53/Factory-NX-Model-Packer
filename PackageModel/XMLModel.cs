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
            XmlSerializer xs = new XmlSerializer(typeof(GameModel));
            FileStream fs = new FileStream(Filename, FileMode.Create, FileAccess.ReadWrite);
            xs.Serialize(fs, this);

            fs.Close();
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
