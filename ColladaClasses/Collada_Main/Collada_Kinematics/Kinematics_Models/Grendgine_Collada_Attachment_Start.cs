using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="attachment_start", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Attachment_Start
	{
		[XmlAttribute("joint")]
		public string Joint;
		
		[XmlElement(ElementName = "translate")]
		public Collada_Translate[] Translate;

		[XmlElement(ElementName = "rotate")]
		public Collada_Rotate[] Rotate;	
	}
}

