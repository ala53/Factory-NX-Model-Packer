using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="create_cube", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Create_Cube
	{
		
		[XmlElement(ElementName = "size")]
		public Collada_Size_Width_Only Size;	
		
		[XmlElement(ElementName = "mips")]
		public Collada_Mips_Attribute Mips;	
		
		[XmlElement(ElementName = "array")]
		public Collada_Array_Length Array_Length;		
		
		[XmlElement(ElementName = "format")]
		public Collada_Format Format;		
		
		[XmlElement(ElementName = "init_from")]
		public Collada_Init_From[] Init_From;	
	}
}

