using System.Runtime.Remoting.Messaging;

namespace Interceptor
{
    public interface IPreProcessor
    {
        void Process(ref IMethodCallMessage msg);
    }
}
