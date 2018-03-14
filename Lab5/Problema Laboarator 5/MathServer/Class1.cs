using System;
using System.Runtime.Remoting;

namespace MathServer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{         // Read remoting info from config file.
			RemotingConfiguration.Configure("MathServer.exe.config");

			// Keep the server alive until Enter is pressed.
			Console.WriteLine("Server started. Press Enter to end ...");
			Console.ReadLine();

		}
	}
}
