using System;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.collada.org/2005/11/COLLADASchema" )]
	public enum Collada_FX_Opaque_Channel
	{
		A_ONE,
		RGB_ZERO,
		A_ZERO,
		RGB_ONE
	}
}

