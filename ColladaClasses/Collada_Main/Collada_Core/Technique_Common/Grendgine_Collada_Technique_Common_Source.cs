using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Technique_Common_Source : Collada_Technique_Common
	{
	
		
		
		[XmlElement(ElementName = "accessor")]
		public Collada_Accessor Accessor;	
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;	
	}
}

