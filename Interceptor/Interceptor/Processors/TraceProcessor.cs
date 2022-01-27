using Interceptor.Interfaces;
using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class TraceProcessor : IProcessor
    {
        private ILogger _logger;

        public TraceProcessor()
            : this(null)
        {

        }

        public TraceProcessor(ILogger logger)
        {
            _logger = logger;
        }

        void IPreProcessor.Process(ref IMethodCallMessage msg)
        {
            string preMessage = $"PreProcessing: {msg.MethodName}";

            if (_logger == null)
            {
                Console.WriteLine(preMessage);
                return;
            }

            _logger.Log(preMessage);
        }

        void IPostProcessor.Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            string postMessage = $"PostProcessing: {callMsg.MethodName} - Returns: {retMsg.ReturnValue}";

            if (_logger == null)
            {
                Console.WriteLine(postMessage);
                return;
            }

            _logger.Log(postMessage);
        }
    }
}
