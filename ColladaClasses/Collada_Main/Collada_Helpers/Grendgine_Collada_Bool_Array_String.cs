using System;

namespace ColladaDotNet
{

	public partial class Collada_Bool_Array_String
	{
		public bool[] Value(){
			return Collada_Parse_Utils.String_To_Bool(this.Value_As_String);
		}


	}
}