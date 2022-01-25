using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class ExceptionSilencerProcessor : ExceptionHandlingProcessor
    {
        protected override void HandleException(IMethodCallMessage callMsg, Exception e)
        {
            Console.WriteLine($"Method {callMsg.MethodName} threw an exception and was silenced.");
        }

        protected override Exception GetNewException(IMethodCallMessage callMsg, Exception oldException)
        {
            return null;
        }
    }
}
