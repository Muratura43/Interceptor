using Interceptor.Interfaces;
using System;
using System.Runtime.Remoting.Messaging;

namespace Interceptor.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor |
					AttributeTargets.Method |
					AttributeTargets.Property, AllowMultiple = true)]
	public class ProcessAttribute : Attribute
	{
		private readonly IProcessor _processor;

		public ProcessAttribute(IProcessor processor)
		{
			_processor = processor;
		}

		public ProcessAttribute(Type processorType)
		{
			_processor = Activator.CreateInstance(processorType) as IProcessor;

			if (_processor == null)
			{
				throw new ArgumentException($"The type '{processorType.Name}' does not implement interface IProcessor");
			}
		}

		internal void PreProcess(ref IMethodCallMessage msg)
        {
            _processor.Process(ref msg);
        }

		internal void PostProcess(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            _processor.Process(callMsg, ref retMsg);
		}
	}
}
