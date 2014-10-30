using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="mass_frame", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Mass_Frame
	{

		[XmlElement(ElementName = "rotate")]
		public Collada_Rotate[] Rotate;
		

		[XmlElement(ElementName = "translate")]
		public Collada_Translate[] Translate;		
	}
}

