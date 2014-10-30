using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Vertex_Weights
	{
		[XmlAttribute("count")]
		public int Count;

	    [XmlElement(ElementName = "vcount")]
		public Collada_Int_Array_String VCount;		

		[XmlElement(ElementName = "v")]
		public Collada_Int_Array_String V;		

		[XmlElement(ElementName = "input")]
		public Collada_Input_Shared[] Input;		
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
	}
}

