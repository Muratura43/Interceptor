using Interceptor.Attributes;
using Interceptor.Interfaces;
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
            var mcm = msg as IMethodCallMessage;

            PreProcess(ref mcm);

            var rtnMsg = NextSink.SyncProcessMessage(msg);
            var mrm = rtnMsg as IMethodReturnMessage;

            PostProcess(msg as IMethodCallMessage, ref mrm);

            return mrm;
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            // Not implemented...

            var rtnMsgCtrl = NextSink.AsyncProcessMessage(msg, replySink);
            return rtnMsgCtrl;
        }

        private void PreProcess(ref IMethodCallMessage msg)
        {
            var preAttrs = (PreProcessAttribute[])msg.MethodBase.GetCustomAttributes(typeof(PreProcessAttribute), true);

            foreach (var preAttr in preAttrs)
            {
                preAttr.Processor.Process(ref msg);
            }

            var attrs = (ProcessAttribute[])msg.MethodBase.GetCustomAttributes(typeof(ProcessAttribute), true);

            foreach (var attr in attrs)
            {
                attr.PreProcess(ref msg);
            }
        }

        private void PostProcess(IMethodCallMessage callMsg, ref IMethodReturnMessage rtnMsg)
        {
            var postAttrs = (PostProcessAttribute[])callMsg.MethodBase.GetCustomAttributes(typeof(PostProcessAttribute), true);

            foreach (var postAttr in postAttrs)
            {
                postAttr.Processor.Process(callMsg, ref rtnMsg);
            }

            var attrs = (ProcessAttribute[])callMsg.MethodBase.GetCustomAttributes(typeof(ProcessAttribute), true);

            foreach (var attr in attrs)
            {
                attr.PostProcess(callMsg, ref rtnMsg);
            }
        }
    }
}
