using Interceptor.Interfaces;
using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class TracePreProcessor : IPreProcessor
	{
		public TracePreProcessor()
		{ 
		}

		public void Process(ref IMethodCallMessage msg)
		{
			Console.WriteLine($"PreProcessing:{msg.MethodName}");
		}
	}
}
