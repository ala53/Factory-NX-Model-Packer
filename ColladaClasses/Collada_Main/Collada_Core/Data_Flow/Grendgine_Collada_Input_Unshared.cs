using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Input_Unshared
	{
		[XmlAttribute("semantic")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Input_Semantic.NORMAL)]
		public Collada_Input_Semantic Semantic;	

		[XmlAttribute("source")]
		public string source;

	}
}

