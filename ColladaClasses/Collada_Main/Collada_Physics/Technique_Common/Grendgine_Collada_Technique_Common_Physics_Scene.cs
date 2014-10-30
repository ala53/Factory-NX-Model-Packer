using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Technique_Common_Physics_Scene : Collada_Technique_Common
	{
		
		[XmlElement(ElementName = "gravity")]
		public Collada_SID_Float_Array_String Gravity;	

		[XmlElement(ElementName = "time_step")]
		public Collada_SID_Float Time_Step;		
	}
}

