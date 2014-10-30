using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Parabola
	{
	    [XmlElement(ElementName = "focal")]
		public float Focal;

		[XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

