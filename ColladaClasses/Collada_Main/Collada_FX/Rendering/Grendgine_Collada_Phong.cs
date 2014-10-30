using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="phong", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Phong
	{
		[XmlElement(ElementName = "emission")]
		public Collada_FX_Common_Color_Or_Texture_Type Eission;		
		
		[XmlElement(ElementName = "ambient")]
		public Collada_FX_Common_Color_Or_Texture_Type Ambient;		
		
		[XmlElement(ElementName = "diffuse")]
		public Collada_FX_Common_Color_Or_Texture_Type Diffuse;		
		
		[XmlElement(ElementName = "specular")]
		public Collada_FX_Common_Color_Or_Texture_Type Specular;		
		
		[XmlElement(ElementName = "transparent")]
		public Collada_FX_Common_Color_Or_Texture_Type Transparent;		
		
		[XmlElement(ElementName = "reflective")]
		public Collada_FX_Common_Color_Or_Texture_Type Reflective;		

	
	
		[XmlElement(ElementName = "shininess")]
		public Collada_FX_Common_Float_Or_Param_Type Shininess;		
		
		[XmlElement(ElementName = "reflectivity")]
		public Collada_FX_Common_Float_Or_Param_Type Reflectivity;		
		
		[XmlElement(ElementName = "transparency")]
		public Collada_FX_Common_Float_Or_Param_Type Transparency;		
		
		[XmlElement(ElementName = "index_of_refraction")]
		public Collada_FX_Common_Float_Or_Param_Type Index_Of_Refraction;		
	}
}

