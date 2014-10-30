using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="instance_material", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Instance_Material_Rendering
	{
		[XmlAttribute("url")]
		public string URL;	
		
	    [XmlElement(ElementName = "technique_override")]
		public Collada_Technique_Override Technique_Override;	
		
	    [XmlElement(ElementName = "bind")]
		public Collada_Bind_FX[] Bind;	
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

