using Interceptor.Interfaces;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class CodeTimerProcessor : IProcessor
	{
		private CodeTimer _timer;

        void IPreProcessor.Process(ref IMethodCallMessage msg)
		{
			_timer = new CodeTimer();
			msg.Properties.Add("codeTimer", _timer);
			_timer.Start(msg.MethodName);
		}

		void IPostProcessor.Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
		{
			_timer = (CodeTimer)callMsg.Properties["codeTimer"];
			_timer.Finish();
		}
	}
}
