using System;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.collada.org/2005/11/COLLADASchema" )]
	public enum Collada_Alpha_Operator
	{
		REPLACE,
		MODULATE,
		ADD,
		ADD_SIGNED,
		INTERPOLATE,
		SUBTRACT		
	}
}

