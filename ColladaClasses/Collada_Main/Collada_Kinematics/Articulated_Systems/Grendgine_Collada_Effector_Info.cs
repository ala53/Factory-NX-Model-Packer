using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="effector_info", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Effector_Info
	{
		[XmlAttribute("sid")]
		public string sID;
		
		[XmlAttribute("name")]
		public string Name;	
		
		[XmlElement(ElementName = "bind")]
		public Collada_Bind[] Bind;			
		
	    [XmlElement(ElementName = "newparam")]
		public Collada_New_Param[] New_Param;

		[XmlElement(ElementName = "setparam")]
		public Collada_Set_Param[] Set_Param;			
		
		[XmlElement(ElementName = "speed")]
		public Collada_Common_Float2_Or_Param_Type Speed;			
		
		[XmlElement(ElementName = "acceleration")]
		public Collada_Common_Float2_Or_Param_Type Acceleration;			

		[XmlElement(ElementName = "deceleration")]
		public Collada_Common_Float2_Or_Param_Type Deceleration;			

		[XmlElement(ElementName = "jerk")]
		public Collada_Common_Float2_Or_Param_Type Jerk;			
		
	}
}

