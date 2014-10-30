using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="texture_pipeline", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Texture_Pipeline
	{
		
		[XmlAttribute("sid")]
		public string sID;		
		
		
	    [XmlElement(ElementName = "texcombiner")]
		public Collada_TexCombiner[] TexCombiner;	
		
	    [XmlElement(ElementName = "texenv")]
		public Collada_TexEnv[] TexEnv;	
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;			

	}
}

