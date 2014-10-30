using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Technique_Common_Formula : Collada_Technique_Common
	{
		/// <summary>
		/// Need to determine the type and value of the Object(s)
		/// </summary>
		[XmlAnyElement]
		public XmlElement[] Data;	
		
	}
}

