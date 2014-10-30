using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="constant", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Constant
	{
		[XmlElement(ElementName = "emission")]
		public Collada_FX_Common_Color_Or_Texture_Type Eission;		
		
		[XmlElement(ElementName = "reflective")]
		public Collada_FX_Common_Color_Or_Texture_Type Reflective;
		
		[XmlElement(ElementName = "reflectivity")]
		public Collada_FX_Common_Float_Or_Param_Type Reflectivity;		
		

		
		[XmlElement(ElementName = "transparent")]
		public Collada_FX_Common_Color_Or_Texture_Type Transparent;
		
		[XmlElement(ElementName = "transparency")]
		public Collada_FX_Common_Float_Or_Param_Type Transparency;			
		
		[XmlElement(ElementName = "index_of_refraction")]
		public Collada_FX_Common_Float_Or_Param_Type Index_Of_Refraction;			
	}
}

