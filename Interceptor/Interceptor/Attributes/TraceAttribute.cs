using Interceptor.Interfaces;
using Interceptor.Processors;
using System;

namespace Interceptor.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor |
                    AttributeTargets.Method |
                    AttributeTargets.Property, AllowMultiple = true)]
    public class TraceAttribute : ProcessAttribute
    {
        public TraceAttribute()
            : this(null)
        {

        }

        public TraceAttribute(ILogger logger)
            : base(new TraceProcessor(logger))
        {

        }
    }
}
