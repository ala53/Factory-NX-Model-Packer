using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="argument", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Argument_Alpha
	{
		[XmlAttribute("source")]
		public Collada_Argument_Source Source;

		[XmlAttribute("operand")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Argument_Alpha_Operand.SRC_ALPHA)]
		public Collada_Argument_Alpha_Operand Operand;
				
		[XmlAttribute("sampler")]
		public string Sampler;
		
	}
}

