using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="instance_effect", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Instance_Effect
	{
		[XmlAttribute("sid")]
		public string sID;
		
		[XmlAttribute("name")]
		public string Name;		
		
		[XmlAttribute("url")]
		public string URL;		

		[XmlElement(ElementName = "setparam")]
		public Collada_Set_Param[] Set_Param;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			
		
	    [XmlElement(ElementName = "technique_hint")]
		public Collada_Technique_Hint[] Technique_Hint;			
		
	}
}

