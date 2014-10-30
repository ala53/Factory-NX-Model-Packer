using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Geographic_Location
	{


	    [XmlElement(ElementName = "longitude")]
		public float Longitude;
	    
		[XmlElement(ElementName = "latitude")]
		public float Latitude;
		
	    [XmlElement(ElementName = "altitude")]
		public Collada_Geographic_Location_Altitude Altitude;		
		
	}
}

