using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="stencil_target", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Stencil_Target
	{
		[XmlAttribute("index")]
	    [System.ComponentModel.DefaultValueAttribute(typeof(int), "1")]
		public int Index;
		
		[XmlAttribute("slice")]
	    [System.ComponentModel.DefaultValueAttribute(typeof(int), "0")]
		public int Slice;

		[XmlAttribute("mip")]
	    [System.ComponentModel.DefaultValueAttribute(typeof(int), "0")]
		public int Mip;


		[XmlAttribute("face")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Face.POSITIVE_X)]
		public Collada_Face Face;

		
		[XmlElement(ElementName = "param")]
		public Collada_Param Param;	
		
			
		[XmlElement(ElementName = "instance_image")]
		public Collada_Instance_Image Instance_Image;	
			
	}
}

