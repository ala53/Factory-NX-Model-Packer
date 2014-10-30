using System;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.collada.org/2005/11/COLLADASchema" )]
	public enum Collada_TexEnv_Operator
	{
		REPLACE,
		MODULATE,
		DECAL,
		BLEND,
		ADD
	}
}

