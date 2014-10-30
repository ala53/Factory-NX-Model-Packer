using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Input_Shared : Collada_Input_Unshared
	{
		[XmlAttribute("offset")]
		public int Offset;
		
		[XmlAttribute("set")]
		public int Set;				
		
	}
}

