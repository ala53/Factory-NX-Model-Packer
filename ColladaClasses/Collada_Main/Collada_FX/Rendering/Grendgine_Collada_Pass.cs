using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="pass", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Pass
	{
		[XmlAttribute("sid")]
		public string sID;
		
		[XmlElement(ElementName = "annotate")]
		public Collada_Annotate[] Annotate;		
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;		
		
	    [XmlElement(ElementName = "states")]
		public Collada_States States;		
		
	    [XmlElement(ElementName = "evaluate")]
		public Collada_Effect_Technique_Evaluate Evaluate;		
	}
}

