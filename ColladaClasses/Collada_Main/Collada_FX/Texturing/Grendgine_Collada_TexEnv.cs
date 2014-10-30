using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="texenv", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_TexEnv
	{
		[XmlAttribute("operator")]
		public Collada_TexEnv_Operator Operator;

		[XmlAttribute("sampler")]
		public string Sampler;		
		
		[XmlElement(ElementName = "constant")]
		public Collada_Constant_Attribute Constant;		
	}
}

