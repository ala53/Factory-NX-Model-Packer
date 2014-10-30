using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Sampler
	{
		[XmlAttribute("id")]
		public string ID;
	
		[XmlAttribute("pre_behavior")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Sampler_Behavior.UNDEFINED)]
		public Collada_Sampler_Behavior Pre_Behavior;

		[XmlAttribute("post_behavior")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Sampler_Behavior.UNDEFINED)]
		public Collada_Sampler_Behavior Post_Behavior;
		
		
		[XmlElement(ElementName = "input")]
		public Collada_Input_Unshared[] Input;			
	}
}

