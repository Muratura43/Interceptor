﻿using System;

namespace Interceptor
{
    [AttributeUsage(AttributeTargets.Constructor | 
					AttributeTargets.Method | 
					AttributeTargets.Property, AllowMultiple = true)]
	public class PreProcessAttribute : Attribute
	{
		public IPreProcessor Processor { get; }

		public PreProcessAttribute(Type preProcessorType)
		{
			Processor = Activator.CreateInstance(preProcessorType) as IPreProcessor;

			if (Processor == null)
			{ 
				throw new ArgumentException($"The type '{preProcessorType.Name}' does not implement interface IPreProcessor"); 
			}
		}
	}
}
