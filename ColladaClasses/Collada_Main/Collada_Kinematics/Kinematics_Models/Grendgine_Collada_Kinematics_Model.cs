using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="kinematics_model", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Kinematics_Model
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;	
		
		
		[XmlElement(ElementName = "technique_common")]
		public Collada_Technique_Common_Kinematics_Model Technique_Common;
	    
		[XmlElement(ElementName = "technique")]
		public Collada_Technique[] Technique;			
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra; 
	}
}

