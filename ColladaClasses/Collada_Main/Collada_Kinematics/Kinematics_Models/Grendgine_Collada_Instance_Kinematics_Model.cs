using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ColladaDotNet
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(ElementName="instance_kinematics_model", Namespace="http://www.collada.org/2005/11/COLLADASchema", IsNullable=true)]
	public partial class Collada_Instance_Kinematics_Model
	{
		[XmlAttribute("sid")]
		public string sID;

		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("url")]
		public string URL;	
		
	    [XmlElement(ElementName = "bind")]
		public Collada_Bind[] Bind;
		
	    [XmlElement(ElementName = "extra")]
		public Collada_Extra[] Extra;
		
	    [XmlElement(ElementName = "newparam")]
		public Collada_New_Param[] New_Param;

		[XmlElement(ElementName = "setparam")]
		public Collada_Set_Param[] Set_Param;		
	}
}

