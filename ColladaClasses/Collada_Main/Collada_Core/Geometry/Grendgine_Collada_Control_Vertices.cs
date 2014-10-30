using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Control_Vertices
	{
		
	    [XmlElement(ElementName = "input")]
		public Collada_Input_Unshared[] Input;	

			
		[XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
	}
}

