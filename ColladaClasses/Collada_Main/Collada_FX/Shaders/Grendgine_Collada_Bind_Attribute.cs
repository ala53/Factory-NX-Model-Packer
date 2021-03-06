using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="bind_attribute", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Bind_Attribute
	{
		[XmlAttribute("symbol")]
		public string Symbol;	
		
		[XmlElement(ElementName = "semantic")]
		public Collada_Semantic Semantic;		
	}
}

