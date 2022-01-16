using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;

namespace Interceptor.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
	public class InterceptAttribute : ContextAttribute
	{
		public InterceptAttribute() 
			: base("Intercept")
		{
		}

		public override void Freeze(Context newContext)
		{
			//
		}

		public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
			ctorMsg.ContextProperties.Add(new InterceptProperty());
		}

		public override bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
		{
			return ctx.GetProperty("Intercept") is InterceptProperty;
		}

		public override bool IsNewContextOK(Context newCtx)
		{
			return newCtx.GetProperty("Intercept") is InterceptProperty;
		}
	}
}
