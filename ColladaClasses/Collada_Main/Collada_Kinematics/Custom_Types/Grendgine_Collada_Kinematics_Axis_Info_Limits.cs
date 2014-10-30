using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Kinematics_Axis_Info_Limits
	{
	    [XmlElement(ElementName = "min")]
		public Collada_Common_Float_Or_Param_Type Min;	
	    [XmlElement(ElementName = "max")]
		public Collada_Common_Float_Or_Param_Type Max;
	}
}

