using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Curve
	{
		[XmlAttribute("sid")]
		public string sID;
		
		[XmlAttribute("name")]
		public string Name;			
		
		[XmlElement(ElementName = "line")]
		public Collada_Line Line;
		
		[XmlElement(ElementName = "circle")]
		public Collada_Circle Circle;
		
		[XmlElement(ElementName = "ellipse")]
		public Collada_Ellipse Ellipse;
		
		[XmlElement(ElementName = "parabola")]
		public Collada_Parabola Parabola;
		
		[XmlElement(ElementName = "hyperbola")]
		public Collada_Hyperbola Hyperbola;
		
		[XmlElement(ElementName = "nurbs")]
		public Collada_Nurbs Nurbs;
		
		
	    [XmlElement(ElementName = "orient")]
		public Collada_Orient[] Orient;			
		
		[XmlElement(ElementName = "origin")]
		public Collada_Origin Origin;
	}
}

