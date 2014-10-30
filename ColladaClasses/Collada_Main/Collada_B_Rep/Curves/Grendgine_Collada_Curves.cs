using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Curves
	{
		
	    [XmlElement(ElementName = "curve")]
		public Collada_Curve[] Curve;		
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

