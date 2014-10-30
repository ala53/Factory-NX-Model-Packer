using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Nurbs
	{
		[XmlAttribute("degree")]
		public int Degree;
		[XmlAttribute("closed")]
		public bool Closed;		
		
		[XmlElement(ElementName = "source")]
		public Collada_Source[] Source;		
		
		[XmlElement(ElementName = "control_vertices")]
		public Collada_Control_Vertices Control_Vertices;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;		
	}
}

