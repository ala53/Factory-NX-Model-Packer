using System;

namespace ColladaDotNet
{
	public partial class Collada_SID_Int_Array_String
	{
		public int[] Value(){
			return Collada_Parse_Utils.String_To_Int(this.Value_As_String);
		}

	}
}

