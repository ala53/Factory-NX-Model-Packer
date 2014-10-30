using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Nurbs_Surface
	{
		[XmlAttribute("degree_u")]
		public int Degree_U;
		[XmlAttribute("closed_u")]
		public bool Closed_U;		
		[XmlAttribute("degree_v")]
		public int Degree_V;
		[XmlAttribute("closed_v")]
		public bool Closed_V;		
		
		[XmlElement(ElementName = "source")]
		public Collada_Source[] Source;		
		
		[XmlElement(ElementName = "control_vertices")]
		public Collada_Control_Vertices Control_Vertices;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			
	}
}

