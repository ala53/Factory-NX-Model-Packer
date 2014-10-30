using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Wires
	{
		[XmlAttribute("count")]
		public int Count;
		
		[XmlAttribute("name")]
		public string Name;
		
		[XmlAttribute("id")]
		public string ID;

	    [XmlElement(ElementName = "vcount")]
		public Collada_Int_Array_String VCount;		

		[XmlElement(ElementName = "p")]
		public Collada_Int_Array_String P;		

		[XmlElement(ElementName = "input")]
		public Collada_Input_Shared[] Input;		
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
	}
}

