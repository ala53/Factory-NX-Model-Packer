using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="shader", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Shader
	{
		[XmlAttribute("stage")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Shader_Stage.VERTEX)]
		public Collada_Shader_Stage Stage;		

	    [XmlElement(ElementName = "sources")]
		public Collada_Shader_Sources Sources;	



	}
}

