using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Format_Hint
	{
		[XmlAttribute("channels")]
		public Collada_Format_Hint_Channels Channels;	
		
		[XmlAttribute("range")]
		public Collada_Format_Hint_Range Range;	
		
		[XmlAttribute("precision")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Format_Hint_Precision.DEFAULT)]
		public Collada_Format_Hint_Precision Precision;			
		
		[XmlAttribute("space")]
		public string Hint_Space;
		
	}
}

