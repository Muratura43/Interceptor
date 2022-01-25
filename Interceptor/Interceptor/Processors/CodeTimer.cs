using System;

namespace Interceptor.Processors
{
    internal class CodeTimer
	{
		private DateTime start;
		private string operation;

		public void Start(string op)
		{
			operation = op;
			start = DateTime.Now;
		}

		public void Finish()
		{
			var ts = DateTime.Now.Subtract(start);
			Console.WriteLine("Total time for {0}: {1}ms", operation, ts.TotalMilliseconds);
		}
	}
}
