using Interceptor.Interfaces;
using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public abstract class ExceptionHandlingProcessor : IPostProcessor
	{
		public void Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
		{
			var e = retMsg.Exception;

			if (e != null)
			{
				HandleException(callMsg, e);

				var newException = GetNewException(callMsg, e);

				if (!ReferenceEquals(e, newException))
				{
					retMsg = new ReturnMessage(newException, callMsg);
				}
			}
		}

		protected abstract void HandleException(IMethodCallMessage callMsg, Exception e);

		protected virtual Exception GetNewException(IMethodCallMessage callMsg, Exception oldException)
		{
			return oldException;
		}
	}
}
