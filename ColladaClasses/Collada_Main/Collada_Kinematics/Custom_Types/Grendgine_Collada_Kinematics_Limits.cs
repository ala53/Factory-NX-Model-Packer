using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="limits", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Kinematics_Limits
	{
	    [XmlElement(ElementName = "min")]
		public Collada_SID_Name_Float Min;	
	    [XmlElement(ElementName = "max")]
		public Collada_SID_Name_Float Max;			
	}
}

