using Interceptor.Interfaces;
using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class TracePostProcessor : IPostProcessor
	{
		public TracePostProcessor()
		{ 
		}

		public void Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
		{
			Console.WriteLine($"PostProcessing:{callMsg.MethodName} - Returns:{retMsg.ReturnValue}");
		}
	}
}
