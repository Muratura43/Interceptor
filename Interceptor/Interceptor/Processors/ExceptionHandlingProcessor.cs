using Interceptor.Interfaces;
using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Processors
{
    public class ExceptionHandlingProcessor : IPostProcessor
	{
		public ExceptionHandlingProcessor()
		{
		}

		public void Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
		{
			var e = retMsg.Exception;

			if (e != null)
			{
				HandleException(e);

				var newException = GetNewException(e);

				if (!ReferenceEquals(e, newException))
				{
					retMsg = new ReturnMessage(newException, callMsg);
				}
			}
		}

		public virtual void HandleException(Exception e)
        {
			Console.WriteLine(e.Message);
        }

		public virtual Exception GetNewException(Exception oldException)
		{
			return oldException;
		}
	}
}
