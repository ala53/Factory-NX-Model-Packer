using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="convex_mesh", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Convex_Mesh
	{

		[XmlAttribute("convex_hull_of")]
		public string Convex_Hull_Of;		
		
	    [XmlElement(ElementName = "source")]
		public Collada_Source[] Source;		
		
	    [XmlElement(ElementName = "lines")]
		public Collada_Lines[] Lines;		
	    
		[XmlElement(ElementName = "linestrips")]
		public Collada_Linestrips[] Linestrips;		

	    [XmlElement(ElementName = "polygons")]
		public Collada_Polygons[] Polygons;		

	    [XmlElement(ElementName = "polylist")]
		public Collada_Polylist[] Polylist;		
		
	    [XmlElement(ElementName = "triangles")]
		public Collada_Triangles[] Triangles;		
		
	    [XmlElement(ElementName = "trifans")]
		public Collada_Trifans[] Trifans;		
		
	    [XmlElement(ElementName = "tristrips")]
		public Collada_Tristrips[] Tristrips;
		
		
	    [XmlElement(ElementName = "vertices")]
		public Collada_Vertices Vertices;		
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

