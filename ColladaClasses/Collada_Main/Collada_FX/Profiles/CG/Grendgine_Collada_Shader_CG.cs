using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="shader", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Shader_CG : Collada_Shader
	{

	    [XmlElement(ElementName = "bind_uniform")]
		public Collada_Bind_Uniform[] Bind_Uniform;	
		
	    [XmlElement(ElementName = "compiler")]
		public Collada_Compiler[] Compiler;		
	}
}

