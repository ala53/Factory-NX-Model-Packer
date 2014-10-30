using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Technique_Common_Rigid_Constraint : Collada_Technique_Common
	{
		
		[XmlElement(ElementName = "enabled")]
		public Collada_SID_Bool Enabled;
		
		[XmlElement(ElementName = "interpenetrate")]
		public Collada_SID_Bool Interpenetrate;		
		
		[XmlElement(ElementName = "limits")]
		public Collada_Constraint_Limits Limits;		
		
		
		[XmlElement(ElementName = "spring")]
		public Collada_Constraint_Spring Spring;		
		
		
	}
}

