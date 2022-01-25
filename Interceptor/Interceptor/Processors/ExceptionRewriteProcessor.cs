using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class ExceptionRewriteProcessor : ExceptionHandlingProcessor
    {
        protected override void HandleException(IMethodCallMessage callMsg, Exception e)
        {
            //
        }

        protected override Exception GetNewException(IMethodCallMessage callMsg, Exception oldException)
        {
            return new ApplicationException($"Method {callMsg.MethodName} threw and exception.", oldException);
        }
    }
}
