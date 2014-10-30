using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="texcombiner", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_TexCombiner
	{
		
		[XmlElement(ElementName = "constant")]
		public Collada_Constant_Attribute Constant;		
		
		[XmlElement(ElementName = "RGB")]
		public Collada_RGB RGB;		
		
		[XmlElement(ElementName = "alpha")]
		public Collada_Alpha Alpha;
	}
}

