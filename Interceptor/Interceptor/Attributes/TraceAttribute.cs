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
            : base(new TraceProcessor())
        {

        }
    }
}
