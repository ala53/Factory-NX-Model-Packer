using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Constraint_Limit_Detail
	{
		
		[XmlElement(ElementName = "min")]
		public Collada_SID_Float_Array_String Min;	
		
		
		[XmlElement(ElementName = "max")]
		public Collada_SID_Float_Array_String Max;			
	}
}

