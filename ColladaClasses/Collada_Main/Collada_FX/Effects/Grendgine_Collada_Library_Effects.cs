using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="library_effects", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Library_Effects
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;		
		
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			
		
	    [XmlElement(ElementName = "effect")]
		public Collada_Effect[] Effect;			
		
	}
}

