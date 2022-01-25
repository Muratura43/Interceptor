using Interceptor.Interfaces;
using System;
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

		private class CodeTimer
		{
			private DateTime start;
			private string operation;

			public void Start(string op)
			{
				operation = op;
				start = DateTime.Now;
			}

			public void Finish()
			{
				var ts = DateTime.Now.Subtract(start);
				Console.WriteLine("Total time for {0}: {1}ms", operation, ts.TotalMilliseconds);
			}
		}
	}
}
