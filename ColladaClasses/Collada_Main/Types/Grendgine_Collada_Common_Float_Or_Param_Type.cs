using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Common_Float_Or_Param_Type : Collada_Common_Param_Type
	{
		[XmlTextAttribute()]
	    public string Value_As_String;				
	}
}

