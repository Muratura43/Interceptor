using Interceptor.Interfaces;
using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class TraceProcessor : IProcessor
    {
        void IPreProcessor.Process(ref IMethodCallMessage msg)
        {
            string preMessage = $"PreProcessing: {msg.MethodName}";

            Console.WriteLine(preMessage);
        }

        void IPostProcessor.Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            string postMessage = $"PostProcessing: {callMsg.MethodName} - Returns: {retMsg.ReturnValue}";
            Console.WriteLine(postMessage);
        }
    }
}
