using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Polygons : Collada_Geometry_Common_Fields
	{

		[XmlElement(ElementName = "ph")]
		public Collada_Poly_PH[] PH;		
	
	}
}

