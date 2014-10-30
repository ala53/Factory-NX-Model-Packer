using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="create_2d", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Create_2D
	{
		
		[XmlElement(ElementName = "size_exact")]
		public Collada_Size_2D Size_Exact;	
	
		
		[XmlElement(ElementName = "size_ratio")]
		public Collada_Size_Ratio Size_Ratio;	
		
		[XmlElement(ElementName = "mips")]
		public Collada_Mips_Attribute Mips;	
	
		

		[XmlElement(ElementName = "unnormalized")]
		public XmlElement Unnormalized;	
		
		[XmlElement(ElementName = "array")]
		public Collada_Array_Length Array_Length;		
		
		
		[XmlElement(ElementName = "format")]
		public Collada_Format Format;		
		
		[XmlElement(ElementName = "init_from")]
		public Collada_Init_From[] Init_From;		
				
		
	}
}

