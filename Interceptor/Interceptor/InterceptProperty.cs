using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace Interceptor
{
    public class InterceptProperty : IContextProperty, IContributeObjectSink
	{
		public string Name => "Intercept";

		public InterceptProperty() 
			: base()
		{
		}

		public bool IsNewContextOK(Context newCtx)
		{
			return newCtx.GetProperty("Intercept") is InterceptProperty;
		}

		public void Freeze(Context newContext)
		{
			//
		}

		public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
		{
			return new InterceptSink(nextSink);
		}
	}
}
