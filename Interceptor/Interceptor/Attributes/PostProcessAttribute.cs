using Interceptor.Interfaces;
using System;

namespace Interceptor.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | 
					AttributeTargets.Method | 
					AttributeTargets.Property, AllowMultiple = true)]
	public class PostProcessAttribute : Attribute
	{
		public IPostProcessor Processor { get; }

        public PostProcessAttribute(IPostProcessor processor)
        {
			Processor = processor;
        }

		public PostProcessAttribute(Type postProcessorType)
		{
			Processor = Activator.CreateInstance(postProcessorType) as IPostProcessor;

			if (Processor == null)
			{
				throw new ArgumentException($"The type '{postProcessorType.Name}' does not implement interface IPostProcessor");
			}
		}
	}
}
