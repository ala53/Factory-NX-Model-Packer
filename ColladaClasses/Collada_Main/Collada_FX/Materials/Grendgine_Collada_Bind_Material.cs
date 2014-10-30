using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="bind_material", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Bind_Material
	{
	    
		[XmlElement(ElementName = "param")]
		public Collada_Param[] Param;			

		[XmlElement(ElementName = "technique_common")]
		public Collada_Technique_Common_Bind_Material Technique_Common;
	    
		[XmlElement(ElementName = "technique")]
		public Collada_Technique[] Technique;			
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

