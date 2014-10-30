using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="binary", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Binary
	{
		[XmlElement(ElementName = "ref")]
		public string Ref;
		
		[XmlElement(ElementName = "hex")]
		public Collada_Hex Hex;		
	}
}

