using Exercise;
//using Solution;

namespace Program
{
    class IPCServer
    {
        static void Main(string[] args)
        {
            //new IPCNamedServer().ipcServerCommunicate();
            new IPCNamedServer2().ipcServerCommunicate();
             //SolutionIPCNamedServer server = new SolutionIPCNamedServer("MessageReversePipe");
             //server.prepareServer();
             //server.communicate();

        }
    }
}