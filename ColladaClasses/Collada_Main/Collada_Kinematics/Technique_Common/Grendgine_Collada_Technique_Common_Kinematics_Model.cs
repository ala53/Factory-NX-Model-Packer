using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="technique_common", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Technique_Common_Kinematics_Model : Collada_Technique_Common
	{
		[XmlElement(ElementName = "newparam")]
		public Collada_New_Param[] New_Param;	

		[XmlElement(ElementName = "joint")]
		public Collada_Joint[] Joint;	

		[XmlElement(ElementName = "instance_joint")]
		public Collada_Instance_Joint[] Instance_Joint;	

		[XmlElement(ElementName = "link")]
		public Collada_Link[] Link;	

		[XmlElement(ElementName = "formula")]
		public Collada_Formula[] Formula;	
		
		[XmlElement(ElementName = "instance_formula")]
		public Collada_Instance_Formula[] Instance_Formula;	
		
	}
}

