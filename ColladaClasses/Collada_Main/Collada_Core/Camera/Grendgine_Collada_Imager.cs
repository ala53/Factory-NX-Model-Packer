using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Imager
	{
		
		
	    [XmlElement(ElementName = "technique")]
		public Collada_Technique[] Technique;	
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
	}
}

