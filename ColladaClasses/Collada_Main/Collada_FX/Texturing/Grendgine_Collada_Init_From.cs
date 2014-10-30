using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="init_from", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Init_From
	{
		[XmlAttribute("mips_generate")]
		public bool Mips_Generate;
		
		[XmlAttribute("array_index")]
		public int Array_Index;
		
		[XmlAttribute("mip_index")]
		public int Mip_Index;
		
		[XmlAttribute("depth")]
		public int Depth;
		
		[XmlAttribute("face")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Face.POSITIVE_X)]
		public Collada_Face Face;
		
	    [XmlElement(ElementName = "ref")]
		public string Ref;			
		
	    [XmlElement(ElementName = "hex")]
		public Collada_Hex Hex;


        [XmlTextAttribute()]
        public string Value_As_String;

	}
}

