using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Common_Param_Type
	{
		[XmlElement(ElementName = "param")]
		public Collada_Param Param;	
	}
}

