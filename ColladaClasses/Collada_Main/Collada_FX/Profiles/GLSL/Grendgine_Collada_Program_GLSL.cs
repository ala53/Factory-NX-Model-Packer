using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="program", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Program_GLSL
	{

	    [XmlElement(ElementName = "shader")]
		public Collada_Shader_GLSL[] Shader;	
		
	    [XmlElement(ElementName = "bind_attribute")]
		public Collada_Bind_Attribute[] Bind_Attribute;			

	    [XmlElement(ElementName = "bind_uniform")]
		public Collada_Bind_Uniform[] Bind_Uniform;	
	}
}

