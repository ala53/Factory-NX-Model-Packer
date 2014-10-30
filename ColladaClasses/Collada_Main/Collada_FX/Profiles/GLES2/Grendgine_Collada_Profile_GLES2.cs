using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="profile_GLES2", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Profile_GLES2 : Collada_Profile
	{
		[XmlAttribute("platform")]
		public string Platform;
		
		[XmlAttribute("language")]
		public string Language;	
				
	    [XmlElement(ElementName = "newparam")]
		public Collada_New_Param[] New_Param;

		[XmlElement(ElementName = "technique")]
		public Collada_Technique_GLES2[] Technique;	
				
	    [XmlElement(ElementName = "code")]
		public Collada_Code[] Code;
				
	    [XmlElement(ElementName = "include")]
		public Collada_Include[] Include;
	}
}

