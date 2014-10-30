using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Animation
	{

		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;			
		
				
		[XmlElement(ElementName = "animation")]
		public Collada_Animation[] Animation;
		
		[XmlElement(ElementName = "channel")]
		public Collada_Channel[] Channel;
		
		[XmlElement(ElementName = "source")]
		public Collada_Source[] Source;

		[XmlElement(ElementName = "sampler")]
		public Collada_Sampler[] Sampler;
		
		
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
		
	}
}

