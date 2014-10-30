using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Spot
	{
		[XmlElement(ElementName = "color")]
		public Collada_Color Color;				
		
		[XmlElement(ElementName = "constant_attenuation")]
	    [System.ComponentModel.DefaultValueAttribute(typeof(float), "1.0")]
		public Collada_SID_Float Constant_Attenuation;				
				
		[XmlElement(ElementName = "linear_attenuation")]
	    [System.ComponentModel.DefaultValueAttribute(typeof(float), "0.0")]
		public Collada_SID_Float Linear_Attenuation;				

		[XmlElement(ElementName = "quadratic_attenuation")]
	    [System.ComponentModel.DefaultValueAttribute(typeof(float), "0.0")]
		public Collada_SID_Float Quadratic_Attenuation;

		[XmlElement(ElementName = "falloff_angle")]
	    [System.ComponentModel.DefaultValueAttribute(typeof(float), "180.0")]
		public Collada_SID_Float Falloff_Angle;

		[XmlElement(ElementName = "falloff_exponent")]
	    [System.ComponentModel.DefaultValueAttribute(typeof(float), "0.0")]
		public Collada_SID_Float Falloff_Exponent;

	
	}
}

