using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="revolute", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Revolute
	{
		[XmlAttribute("sid")]
		public string sID;	
		
	    [XmlElement(ElementName = "axis")]
		public Collada_SID_Float_Array_String Axis;	

		[XmlElement(ElementName = "limits")]
		public Collada_Kinematics_Limits Limits;		
	}
}

