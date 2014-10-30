using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Orthographic
	{

		[XmlElement(ElementName = "xmag")]
		public Collada_SID_Float XMag;				
				
		[XmlElement(ElementName = "ymag")]
		public Collada_SID_Float YMag;				

		[XmlElement(ElementName = "aspect_ratio")]
		public Collada_SID_Float Aspect_Ratio;				

		[XmlElement(ElementName = "znear")]
		public Collada_SID_Float ZNear;				

		[XmlElement(ElementName = "zfar")]
		public Collada_SID_Float ZFar;				
		
	}
}

