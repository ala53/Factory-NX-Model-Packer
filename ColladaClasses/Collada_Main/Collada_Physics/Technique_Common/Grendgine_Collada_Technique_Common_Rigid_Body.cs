using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Technique_Common_Rigid_Body : Collada_Technique_Common
	{
		
		[XmlElement(ElementName = "dynamic")]
		public Collada_SID_Bool Dynamic;
		
		[XmlElement(ElementName = "mass")]
		public Collada_SID_Float Mass;		
		
		[XmlElement(ElementName = "inertia")]
		public Collada_SID_Float_Array_String Inertia;		
		
		[XmlElement(ElementName = "mass_frame")]
		public Collada_Mass_Frame Mass_Frame;		
		
		
		[XmlElement(ElementName = "physics_material")]
		public Collada_Physics_Material Physics_Material;		
		
		[XmlElement(ElementName = "instance_physics_material")]
		public Collada_Instance_Physics_Material Instance_Physics_Material;		
		
		
		[XmlElement(ElementName = "shape")]
		public Collada_Shape[] Shape;		
	}
}

