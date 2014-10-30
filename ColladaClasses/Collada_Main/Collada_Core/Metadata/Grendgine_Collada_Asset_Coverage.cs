using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Asset_Coverage
	{
	    [XmlElement(ElementName = "geographic_location")]
		public Collada_Geographic_Location Geographic_Location;
	}
}

