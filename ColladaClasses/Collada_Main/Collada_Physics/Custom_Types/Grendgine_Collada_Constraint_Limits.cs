using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="limits", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Constraint_Limits
	{
		
		[XmlElement(ElementName = "swing_cone_and_twist")]
		public Collada_Constraint_Limit_Detail Swing_Cone_And_Twist;		
		
		[XmlElement(ElementName = "linear")]
		public Collada_Constraint_Limit_Detail Linear;		
		

	}
}

