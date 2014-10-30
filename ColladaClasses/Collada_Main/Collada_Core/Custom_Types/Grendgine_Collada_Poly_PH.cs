using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Poly_PH
	{

	    [XmlElement(ElementName = "p")]
		public Collada_Int_Array_String P;

		[XmlElement(ElementName = "h")]
		public Collada_Int_Array_String[] H;		


	}
}

