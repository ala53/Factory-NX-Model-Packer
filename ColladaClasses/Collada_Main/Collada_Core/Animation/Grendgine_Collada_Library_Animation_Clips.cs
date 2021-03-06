using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Library_Animation_Clips
	{

		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;	
		
		
	    [XmlElement(ElementName = "animation_clip")]
		public Collada_Animation_Clip[] Animation_Clip;	
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
	}
}

