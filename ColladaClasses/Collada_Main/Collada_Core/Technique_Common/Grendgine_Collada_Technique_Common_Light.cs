using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Technique_Common_Light : Collada_Technique_Common
	{
		[XmlElement(ElementName = "ambient")]
		public Collada_Ambient Ambient;		
		
		[XmlElement(ElementName = "directional")]
		public Collada_Directional Directional;		
		
		[XmlElement(ElementName = "point")]
		public Collada_Point Point;		
		
		[XmlElement(ElementName = "spot")]
		public Collada_Spot Spot;		
		
		
		
		
		
		
	}
}

