using System.Runtime.Remoting.Messaging;

namespace Interceptor
{
    public class InterceptSink : IMessageSink
    {
        public IMessageSink NextSink { get; }

        public InterceptSink(IMessageSink nextSink)
        {
            NextSink = nextSink;
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMethodCallMessage mcm = msg as IMethodCallMessage;

            PreProcess(ref mcm);

            IMessage rtnMsg = NextSink.SyncProcessMessage(msg);
            IMethodReturnMessage mrm = rtnMsg as IMethodReturnMessage;

            PostProcess(msg as IMethodCallMessage, ref mrm);

            return mrm;
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            // Not implemented...

            IMessageCtrl rtnMsgCtrl = NextSink.AsyncProcessMessage(msg, replySink);
            return rtnMsgCtrl;
        }

        private void PreProcess(ref IMethodCallMessage msg)
        {
            var attrs = (PreProcessAttribute[])msg.MethodBase.GetCustomAttributes(typeof(PreProcessAttribute), true);

            foreach (var attr in attrs)
            {
                attr.Processor.Process(ref msg);
            }
        }

        private void PostProcess(IMethodCallMessage callMsg, ref IMethodReturnMessage rtnMsg)
        {
            var attrs = (PostProcessAttribute[])callMsg.MethodBase.GetCustomAttributes(typeof(PostProcessAttribute), true);

            foreach (var attr in attrs)
            {
                attr.Processor.Process(callMsg, ref rtnMsg);
            }
        }
    }
}
