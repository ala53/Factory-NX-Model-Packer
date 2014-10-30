using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Visual_Scene
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;	
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			
		
	    [XmlElement(ElementName = "evaluate_scene")]
		public Collada_Evaluate_Scene[] Evaluate_Scene;			

		
	    [XmlElement(ElementName = "node")]
		public Collada_Node[] Node;			
		
	}
}

