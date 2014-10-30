using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Collada_B_Rep
	{
		
				
		[XmlElement(ElementName = "curves")]
		public Collada_Curves Curves;
				
		[XmlElement(ElementName = "surface_curves")]
		public Collada_Surface_Curves Surface_Curves;
				
		[XmlElement(ElementName = "surfaces")]
		public Collada_Surfaces Surfaces;
		
		[XmlElement(ElementName = "source")]
		public Collada_Source[] Source;
		
		[XmlElement(ElementName = "vertices")]
		public Collada_Vertices Vertices;
		
		
		[XmlElement(ElementName = "edges")]
		public Collada_Edges Edges;
		
		[XmlElement(ElementName = "wires")]
		public Collada_Wires Wires;
		
		[XmlElement(ElementName = "faces")]
		public Collada_Faces Faces;
		
		[XmlElement(ElementName = "pcurves")]
		public Collada_PCurves PCurves;
		
		[XmlElement(ElementName = "shells")]
		public Collada_Shells Shells;
		
		[XmlElement(ElementName = "solids")]
		public Collada_Solids Solids;

		
		
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;					
		
	}
}

