using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Accessor
	{
		[XmlAttribute("count")]
		public uint Count;

		[XmlAttribute("offset")]
		public uint Offset;		
		
		[XmlAttribute("source")]
		public string Source;		
		
		[XmlAttribute("stride")]
		public uint Stride;		
		
	    [XmlElement(ElementName = "param")]
		public Collada_Param[] Param;				
	}
}

