using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="alpha", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Alpha
	{
		[XmlAttribute("operator")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Alpha_Operator.ADD)]		
		public Collada_Alpha_Operator Operator;

		[XmlAttribute("scale")]
		public float Scale;		
		
	    [XmlElement(ElementName = "argument")]
		public Collada_Argument_Alpha[] Argument;			
	}
}

