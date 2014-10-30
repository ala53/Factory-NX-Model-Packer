using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	
	/// <summary>
	/// This is the core <technique>
	/// </summary>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Technique
	{
		[XmlAttribute("profile")]
		public string profile;
		[XmlAttribute("xmlns")]
		public string xmlns;

		[XmlAnyElement]
		public XmlElement[] Data;	

	}
}

