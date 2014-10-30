using System;

namespace ColladaDotNet
{

	public partial class Collada_SID_Float_Array_String
	{
		public float[] Value(){
			return Collada_Parse_Utils.String_To_Float(this.Value_As_String);
		}

	}
}

