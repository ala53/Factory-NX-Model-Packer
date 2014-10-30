using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="rigid_body", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Rigid_Body
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("sid")]
		public string sID;

		[XmlAttribute("name")]
		public string Name;	
		
		
		[XmlElement(ElementName = "technique_common")]
		public Collada_Technique_Common_Rigid_Body Technique_Common;
	    
		[XmlElement(ElementName = "technique")]
		public Collada_Technique[] Technique;			
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

