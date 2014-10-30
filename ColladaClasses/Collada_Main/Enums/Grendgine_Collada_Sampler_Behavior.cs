using System;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.collada.org/2005/11/COLLADASchema" )]
	public enum Collada_Sampler_Behavior
	{

		UNDEFINED,
		CONSTANT,
		GRADIENT, 
		CYCLE,
		OSCILLATE, 
		CYCLE_RELATIVE
	}
}

