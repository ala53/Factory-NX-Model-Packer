using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="effect", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Effect
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("name")]
		public string Name;		
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;	
		
		[XmlElement(ElementName = "annotate")]
		public Collada_Annotate[] Annotate;
		
	    [XmlElement(ElementName = "newparam")]
		public Collada_New_Param[] New_Param;

		[XmlElement(ElementName = "profile_BRIDGE")]
		public Collada_Profile_BRIDGE[] Profile_BRIDGE;
		
		[XmlElement(ElementName = "profile_CG")]
		public Collada_Profile_CG[] Profile_CG;
		
		[XmlElement(ElementName = "profile_GLES")]
		public Collada_Profile_GLES[] Profile_GLES;
		
		[XmlElement(ElementName = "profile_GLES2")]
		public Collada_Profile_GLES2[] Profile_GLES2;
		
		[XmlElement(ElementName = "profile_GLSL")]
		public Collada_Profile_GLSL[] Profile_GLSL;
		
		[XmlElement(ElementName = "profile_COMMON")]
		public Collada_Profile_COMMON[] Profile_COMMON;
				
	}
}

