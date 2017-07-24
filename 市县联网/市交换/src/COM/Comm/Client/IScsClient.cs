using ZIT.Comm.Communication;
using ZIT.Comm.Communication.Messengers;

namespace ZIT.Comm.Client
{
    /// <summary>
    /// Represents a client to connect to server.
    /// </summary>
    public interface IScsClient : IMessenger, IConnectableClient
    {
        //Does not define any additional member
    }
}
