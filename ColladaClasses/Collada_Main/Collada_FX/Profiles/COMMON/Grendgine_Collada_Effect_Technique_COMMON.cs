using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="technique", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Effect_Technique_COMMON : Collada_Effect_Technique
	{
		
		[XmlElement(ElementName = "blinn")]
		public Collada_Blinn Blinn;
		
		[XmlElement(ElementName = "constant")]
		public Collada_Constant Constant;
		
		[XmlElement(ElementName = "lambert")]
		public Collada_Lambert Lambert;
		
		[XmlElement(ElementName = "phong")]
		public Collada_Phong Phong;		
	}
}

