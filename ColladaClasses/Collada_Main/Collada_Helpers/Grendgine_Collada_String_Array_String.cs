using System;

namespace ColladaDotNet
{

	public partial class Collada_String_Array_String
	{
		public string[] Value(){
			return this.Value_Pre_Parse.Split(' ');
		}		
	}
}
