using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="kinematics", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Kinematics
	{
		
		[XmlElement(ElementName = "instance_kinematics_model")]
		public Collada_Instance_Kinematics_Model[] Instance_Kinematics_Model;

		
		[XmlElement(ElementName = "technique_common")]
		public Collada_Technique_Common_Kinematics Technique_Common;
	    
		[XmlElement(ElementName = "technique")]
		public Collada_Technique[] Technique;			
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
	}
}

