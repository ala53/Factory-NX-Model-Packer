using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="modifier", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Modifier
	{
		[XmlTextAttribute()]
		[System.ComponentModel.DefaultValueAttribute(Collada_Modifier_Value.CONST)]
	    public Collada_Modifier_Value Value;
	}
}

