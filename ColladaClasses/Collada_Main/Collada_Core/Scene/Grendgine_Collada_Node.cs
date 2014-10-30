using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_Node
	{
		[XmlAttribute("id")]
		public string ID;
		
		[XmlAttribute("sid")]
		public string sID;

		[XmlAttribute("name")]
		public string Name;				

		[XmlAttribute("type")]
		[System.ComponentModel.DefaultValueAttribute(Collada_Node_Type.NODE)]
		public Collada_Node_Type Type;				

		[XmlAttribute("layer")]
		public string Layer;				
		
		[XmlElement(ElementName = "lookat")]
		public Collada_Lookat[] Lookat;

		[XmlElement(ElementName = "matrix")]
		public Collada_Matrix[] Matrix;

		[XmlElement(ElementName = "rotate")]
		public Collada_Rotate[] Rotate;

		[XmlElement(ElementName = "scale")]
		public Collada_Scale[] Scale;

		[XmlElement(ElementName = "skew")]
		public Collada_Skew[] Skew;

		[XmlElement(ElementName = "translate")]
		public Collada_Translate[] Translate;
		
		[XmlElement(ElementName = "instance_camera")]
		public Collada_Instance_Camera[] Instance_Camera;
		
		[XmlElement(ElementName = "instance_controller")]
		public Collada_Instance_Controller[] Instance_Controller;
		
		[XmlElement(ElementName = "instance_geometry")]
		public Collada_Instance_Geometry[] Instance_Geometry;
		
		[XmlElement(ElementName = "instance_light")]
		public Collada_Instance_Light[] Instance_Light;
		
		[XmlElement(ElementName = "instance_node")]
		public Collada_Instance_Node[] Instance_Node;

		
		
		[XmlElement(ElementName = "asset")]
		public Collada_Asset Asset;
		
	    [XmlElement(ElementName = "node")]
		public Collada_Node[] node;		
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;		

	}
}

