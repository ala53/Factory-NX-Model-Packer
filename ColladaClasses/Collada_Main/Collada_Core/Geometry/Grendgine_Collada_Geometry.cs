using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Geometry
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;	
		
		
		[XmlElement(ElementName = "brep")]
		public Collada_B_Rep B_Rep;

		[XmlElement(ElementName = "convex_mesh")]
		public Collada_Convex_Mesh Convex_Mesh;

		
		[XmlElement(ElementName = "spline")]
		public Collada_Spline Spline;

		[XmlElement(ElementName = "mesh")]
		public Collada_Mesh Mesh;
		
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
	}
}

