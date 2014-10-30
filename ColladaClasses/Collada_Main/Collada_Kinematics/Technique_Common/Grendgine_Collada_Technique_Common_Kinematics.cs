using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{

	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="technique_common", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Technique_Common_Kinematics : Collada_Technique_Common
	{
		[XmlElement(ElementName = "axis_info")]
		public Collada_Axis_Info_Kinematics[] Axis_Info;	
		
		[XmlElement(ElementName = "frame_origin")]
		public Collada_Frame_Origin Frame_Origin;
		
		[XmlElement(ElementName = "frame_tip")]
		public Collada_Frame_Tip Frame_Tip;
		
		[XmlElement(ElementName = "frame_tcp")]
		public Collada_Frame_TCP Frame_TCP;
		
		[XmlElement(ElementName = "frame_object")]
		public Collada_Frame_Object Frame_Object;
		
		
		
	}
}

