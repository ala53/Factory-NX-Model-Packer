using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Param
	{
		[XmlAttribute("ref")]
		public string Ref;
		
		[XmlAttribute("sid")]
		public string sID;		

		[XmlAttribute("name")]
		public string Name;		

		[XmlAttribute("semantic")]
		public string Semantic;			

		[XmlAttribute("type")]
		public string Type;		
		
		[XmlAnyElement]
		public XmlElement[] Data;	
		
		//TODO: this is used in a few contexts
	}
}

