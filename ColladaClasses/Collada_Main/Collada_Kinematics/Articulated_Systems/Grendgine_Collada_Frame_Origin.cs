using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="frame_origin", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public class Collada_Frame_Origin
	{
		[XmlAttribute("link")]
		public string Link;
		
		[XmlElement(ElementName = "translate")]
		public Collada_Translate[] Translate;

		[XmlElement(ElementName = "rotate")]
		public Collada_Rotate[] Rotate;	
	}
}

