using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="physics_model", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Physics_Model
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;		
		
	    [XmlElement(ElementName = "rigid_body")]
		public Collada_Rigid_Body[] Rigid_Body;			
		
	    [XmlElement(ElementName = "rigid_constraint")]
		public Collada_Rigid_Constraint[] Rigid_Constraint;			
		
	    [XmlElement(ElementName = "instance_physics_model")]
		public Collada_Instance_Physics_Model[] Instance_Physics_Model;			
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;		
	}
}

