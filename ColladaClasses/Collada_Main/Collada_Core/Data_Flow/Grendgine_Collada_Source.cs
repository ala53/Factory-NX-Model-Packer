using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Source
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;			
		

		[XmlElement(ElementName = "bool_array")]
		public Collada_Bool_Array Bool_Array;
		[XmlElement(ElementName = "float_array")]
		public Collada_Float_Array Float_Array;
		[XmlElement(ElementName = "IDREF_array")]
		public Collada_IDREF_Array IDREF_Array;
		[XmlElement(ElementName = "int_array")]
		public Collada_Int_Array Int_Array;
		[XmlElement(ElementName = "Name_array")]
		public Collada_Name_Array Name_Array;
		[XmlElement(ElementName = "SIDREF_array")]
		public Collada_SIDREF_Array SIDREF_Array;
		[XmlElement(ElementName = "token_array")]
		public Collada_Token_Array Token_Array;
		
		
		[XmlElement(ElementName = "technique_common")]
		public Collada_Technique_Common_Source Technique_Common;
	    
		[XmlElement(ElementName = "technique")]
		public Collada_Technique[] Technique;			
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;	
	}
}

