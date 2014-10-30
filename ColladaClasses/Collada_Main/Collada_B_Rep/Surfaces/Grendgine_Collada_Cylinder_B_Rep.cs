using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]

	public partial class Collada_Cylinder_B_Rep
	{
	    [XmlElement(ElementName = "radius")]
		public Collada_Float_Array_String Radius;

		[XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

