using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]

	public partial class Collada_Axis_Info_Kinematics : Collada_Axis_Info
	{
		[XmlElement(ElementName = "newparam")]
		public Collada_New_Param[] New_Param;	
		
		[XmlElement(ElementName = "active")]
		public Collada_Common_Bool_Or_Param_Type Active;	
		
		[XmlElement(ElementName = "locked")]
		public Collada_Common_Bool_Or_Param_Type Locked;	
		
		[XmlElement(ElementName = "index")]
		public Collada_Kinematics_Axis_Info_Index[] Index;	
		
		[XmlElement(ElementName = "limits")]
		public Collada_Kinematics_Axis_Info_Limits Limits;	
		
		[XmlElement(ElementName = "formula")]
		public Collada_Formula[] Formula;	
		
		[XmlElement(ElementName = "instance_formula")]
		public Collada_Instance_Formula[] Instance_Formula;	
	}
}

