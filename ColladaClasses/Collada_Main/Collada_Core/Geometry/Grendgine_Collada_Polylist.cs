using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Polylist : Collada_Geometry_Common_Fields
	{
		

		[XmlElement(ElementName = "vcount")]
		public Collada_Int_Array_String VCount;			
		
		
	}
}

