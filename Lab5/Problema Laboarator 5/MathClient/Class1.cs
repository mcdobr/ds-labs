using System;
using System.Runtime.Remoting;
using MathLibrary;

namespace MathClient
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		private static SimpleMath math;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// Load the configuration file
			RemotingConfiguration.Configure("MathClient.exe.config");

			// Get a proxy to the remote object		
			math = new SimpleMath();
			System.Diagnostics.Debug.Assert(RemotingServices.IsTransparentProxy(math), "math is not a transparent proxy");
			
			System.Timers.Timer t = new System.Timers.Timer();
			t.Interval = 5000;
			t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
			t.Start();

			// Ask user to press Enter
			Console.WriteLine("Press enter to end");

			Console.ReadLine();
		}

		private static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				Console.WriteLine("5 + 2 = {0}", math.Add(5,2));
				Console.WriteLine("5 - 2 = {0}", math.Subtract(5,2));
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
