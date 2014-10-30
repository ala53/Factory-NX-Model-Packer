using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Axis_Info_Motion : Collada_Axis_Info
	{
		
		[XmlElement(ElementName = "bind")]
		public Collada_Bind[] Bind;	

		[XmlElement(ElementName = "newparam")]
		public Collada_New_Param[] New_Param;	

		[XmlElement(ElementName = "setparam")]
		public Collada_New_Param[] Set_Param;	
		
		[XmlElement(ElementName = "speed")]
		public Collada_Common_Float_Or_Param_Type Speed;	

		[XmlElement(ElementName = "acceleration")]
		public Collada_Common_Float_Or_Param_Type Acceleration;	

		[XmlElement(ElementName = "deceleration")]
		public Collada_Common_Float_Or_Param_Type Deceleration;	

		[XmlElement(ElementName = "jerk")]
		public Collada_Common_Float_Or_Param_Type Jerk;	

		
		
	}
}

