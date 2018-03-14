using System;

namespace MathLibrary
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class SimpleMath : MarshalByRefObject
	{
		public SimpleMath()
		{
			Console.WriteLine("SimpleMath ctor called");
		}

		public int Add(int n1, int n2)
		{
			Console.WriteLine("SimpleMath.Add({0}, {1}) called on instance {2}", n1, n2, this.GetHashCode());
			return n1 + n2;
		}
		public int Subtract(int n1, int n2)
		{
			Console.WriteLine("SimpleMath.Subtract({0}, {1}) called on instance {2}", n1, n2, this.GetHashCode());
			return n1 - n2;
		} 
	}

}
