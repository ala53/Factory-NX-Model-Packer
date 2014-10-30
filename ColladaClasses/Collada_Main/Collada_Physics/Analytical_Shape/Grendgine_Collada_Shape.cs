using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="shape", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Shape
	{
		[XmlElement(ElementName = "hollow")]
		public Collada_SID_Bool Hollow;				
				
		[XmlElement(ElementName = "mass")]
		public Collada_SID_Float Mass;			
				
		[XmlElement(ElementName = "density")]
		public Collada_SID_Float Density;	


		[XmlElement(ElementName = "physics_material")]
		public Collada_Physics_Material Physics_Material;	

		[XmlElement(ElementName = "instance_physics_material")]
		public Collada_Instance_Physics_Material Instance_Physics_Material;	
		
		
		[XmlElement(ElementName = "instance_geometry")]
		public Collada_Instance_Geometry Instance_Geometry;	
		
		[XmlElement(ElementName = "plane")]
		public Collada_Plane Plane;	
		[XmlElement(ElementName = "box")]
		public Collada_Box Box;	
		[XmlElement(ElementName = "sphere")]
		public Collada_Sphere Sphere;	
		[XmlElement(ElementName = "cylinder")]
		public Collada_Cylinder Cylinder;	
		[XmlElement(ElementName = "capsule")]
		public Collada_Capsule Capsule;	
		
		
		
		[XmlElement(ElementName = "translate")]
		public Collada_Translate[] Translate;

		[XmlElement(ElementName = "rotate")]
		public Collada_Rotate[] Rotate;		
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			
	}
}

