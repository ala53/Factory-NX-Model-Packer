using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Animation_Clip
	{

		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;	
		
		
		[XmlAttribute("start")]
		public double Start;	

		[XmlAttribute("end")]
		public double End;	
		
		
	    [XmlElement(ElementName = "instance_animation")]
		public Collada_Instance_Animation[] Instance_Animation;	
		
	    [XmlElement(ElementName = "instance_formula")]
		public Collada_Instance_Formula[] Instance_Formula;	
		

		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
	}
}

