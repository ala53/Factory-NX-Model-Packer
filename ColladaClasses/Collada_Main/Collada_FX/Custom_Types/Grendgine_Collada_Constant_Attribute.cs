using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Constant_Attribute
	{
		[XmlAttribute("value")]
		public string Value_As_String;		
		//TODO: needs to be 4 float array
				
		[XmlAttribute("param")]
		public string Param_As_String;
		//TODO: needs to be 4 float array
	}
}

