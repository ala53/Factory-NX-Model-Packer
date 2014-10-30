using ColladaDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace grengine_collada.Collada_Main.Extended
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Collada_NewParam_Surface
    {
        [XmlElement(ElementName = "init_from")]
        public Collada_Init_From Init_From;
    }
}
