using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class ExceptionTraceProcessor : ExceptionHandlingProcessor
    {
        protected override void HandleException(IMethodCallMessage callMsg, Exception e)
        {
            Console.WriteLine($"Method {callMsg.MethodName} threw an exception: {e.Message}.");
        }
    }
}
