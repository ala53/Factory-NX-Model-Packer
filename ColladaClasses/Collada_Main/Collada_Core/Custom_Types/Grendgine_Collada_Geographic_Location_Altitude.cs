using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Geographic_Location_Altitude
	{

		[XmlTextAttribute()]
		public float Altitude;
		
		[XmlAttribute("mode")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Geographic_Location_Altitude_Mode.relativeToGround)]
		public Collada_Geographic_Location_Altitude_Mode Mode;	
		
	}
}

