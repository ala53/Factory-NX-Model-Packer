using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Morph
	{

		[XmlAttribute("source")]
		public string Source_Attribute;
		
		[XmlAttribute("method")]
		public string Method;			
		
		[XmlArray("targets")]
		public Collada_Input_Shared[] Targets;		
	
	    [XmlElement(ElementName = "source")]
		public Collada_Source[] Source;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			
	}
}

