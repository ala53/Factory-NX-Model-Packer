using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="texture", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Texture
	{
		[XmlAttribute("texture")]
		public string Texture;
		
		[XmlAttribute("texcoord")]
		public string TexCoord;

	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			
	}
}

