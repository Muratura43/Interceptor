using System.Runtime.Remoting.Messaging;

namespace Interceptor.Interfaces
{
    public interface IPreProcessor
    {
        void Process(ref IMethodCallMessage msg);
    }
}
