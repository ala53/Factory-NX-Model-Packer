using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Cone
	{
	    [XmlElement(ElementName = "radius")]
		public float Radius;

	    [XmlElement(ElementName = "angle")]
		public float Angle;
		
		[XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

