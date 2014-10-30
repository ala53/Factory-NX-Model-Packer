using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="evaluate", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Effect_Technique_Evaluate
	{

	    [XmlElement(ElementName = "color_target")]
		public Collada_Color_Target Color_Target;	

		[XmlElement(ElementName = "depth_target")]
		public Collada_Depth_Target Depth_Target;	
	    
		[XmlElement(ElementName = "stencil_target")]
		public Collada_Stencil_Target Stencil_Target;	
	    
		[XmlElement(ElementName = "color_clear")]
		public Collada_Color_Clear Color_Clear;	
	    
		[XmlElement(ElementName = "depth_clear")]
		public Collada_Depth_Clear Depth_Clear;	
	    
		[XmlElement(ElementName = "stencil_clear")]
		public Collada_Stencil_Clear Stencil_Clear;	
	    
		[XmlElement(ElementName = "draw")]
		public Collada_Draw Draw;	

		
	}
}

