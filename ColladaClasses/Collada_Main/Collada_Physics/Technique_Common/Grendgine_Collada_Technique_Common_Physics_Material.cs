using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Technique_Common_Physics_Material : Collada_Technique_Common
	{
		
		[XmlElement(ElementName = "dynamic_friction")]
		public Collada_SID_Float Dynamic_Friction;	
		
		[XmlElement(ElementName = "restitution")]
		public Collada_SID_Float Restitution;	
		
		[XmlElement(ElementName = "static_friction")]
		public Collada_SID_Float Static_Friction;			
	}
}

