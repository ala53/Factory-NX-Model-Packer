using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="technique", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Technique_GLES2 : Collada_Effect_Technique
	{
		
		[XmlElement(ElementName = "annotate")]
		public Collada_Annotate[] Annotate;		
		
		[XmlElement(ElementName = "pass")]
		public Collada_Pass_GLES2[] Pass;		
	}
}

