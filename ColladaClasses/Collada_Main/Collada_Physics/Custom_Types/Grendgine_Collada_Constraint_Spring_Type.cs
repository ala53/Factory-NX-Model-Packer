using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Constraint_Spring_Type
	{

		[XmlElement(ElementName = "stiffness")]
		public Collada_SID_Float Stiffness;	
		
		[XmlElement(ElementName = "damping")]
		public Collada_SID_Float Damping;	
		
		[XmlElement(ElementName = "target_value")]
		public Collada_SID_Float Target_Value;			
	}
}

