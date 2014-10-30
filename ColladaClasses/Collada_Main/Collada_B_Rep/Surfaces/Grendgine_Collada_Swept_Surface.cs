using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Swept_Surface
	{
		
		[XmlElement(ElementName = "curve")]
		public Collada_Curve Curve;
		
		[XmlElement(ElementName = "origin")]
		public Collada_Origin Origin;
		
		[XmlElement(ElementName = "direction")]
		public Collada_Float_Array_String Direction;

		[XmlElement(ElementName = "axis")]
		public Collada_Float_Array_String Axis;

		[XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

