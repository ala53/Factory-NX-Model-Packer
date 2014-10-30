using System;

namespace ColladaDotNet
{
	public partial class Collada_Common_Float2_Or_Param_Type
	{
		public float[] Value(){
			return Collada_Parse_Utils.String_To_Float(this.Value_As_String);
		}
	}
}
