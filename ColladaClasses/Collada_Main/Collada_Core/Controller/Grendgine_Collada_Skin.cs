using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Skin
	{
		[XmlAttribute("sid")]
		public string sID;

	    [XmlElement(ElementName = "bind_shape_matrix")]
		public Collada_Float_Array_String Bind_Shape_Matrix;		
				
	    [XmlElement(ElementName = "source")]
		public Collada_Source[] Source;		

	    [XmlElement(ElementName = "joints")]
		public Collada_Joints Joints;		

	    [XmlElement(ElementName = "vertex_weights")]
		public Collada_Vertex_Weights Vertex_Weights;		
				
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;		
	}
}

