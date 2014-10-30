using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Instance_Geometry
	{
		[XmlAttribute("sid")]
		public string sID;
		
		[XmlAttribute("name")]
		public string Name;	
		
		[XmlAttribute("url")]
		public string URL;	
		

	    [XmlElement(ElementName = "bind_material")]
		public Collada_Bind_Material[] Bind_Material;	
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			
	}
}

