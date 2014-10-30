using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Surface
	{
		[XmlAttribute("name")]
		public string Name;
		
		[XmlAttribute("sid")]
		public string sID;
		

		[XmlElement(ElementName = "cone")]
		public Collada_Cone Cone;
		
	    [XmlElement(ElementName = "plane")]
		public Collada_Plane Plane;
		
	    [XmlElement(ElementName = "cylinder")]
		public Collada_Cylinder_B_Rep Cylinder;
		
	    [XmlElement(ElementName = "nurbs_surface")]
		public Collada_Nurbs_Surface Nurbs_Surface;
		
	    [XmlElement(ElementName = "sphere")]
		public Collada_Sphere Sphere;
		
	    [XmlElement(ElementName = "torus")]
		public Collada_Torus Torus;
		
	    [XmlElement(ElementName = "swept_surface")]
		public Collada_Swept_Surface Swept_Surface;
	

		
		[XmlElement(ElementName = "orient")]
		public Collada_Orient[] Orient;		
		
	    [XmlElement(ElementName = "origin")]
		public Collada_Origin Origin;

	}
}

