using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Extra
	{

		[XmlAttribute("id")]
		public string ID;
		[XmlAttribute("name")]
		public string Name;
		[XmlAttribute("type")]
		public string Type;		
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;		
		
		[XmlElement(ElementName = "technique")]
		public Collada_Technique[] Technique;		
	}
}

