using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="usertype", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_UserType
	{
		[XmlAttribute("typename")]
		public string TypeName;	
		
		[XmlAttribute("source")]
		public string Source;			
		
	    [XmlElement(ElementName = "setparam")]
		public Collada_Set_Param[] SetParam;		
	}
}

