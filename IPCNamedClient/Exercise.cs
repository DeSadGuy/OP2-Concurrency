using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;

namespace Exercise
{
    public class IPCNamedClient
    {
        public virtual void ipcClientCommunicate()
        {
            Console.WriteLine("Pipe Client is being executed ...");
            Console.WriteLine("[Client] waiting to receive a message");

            var server = new NamedPipeServerStream("PipesOfConcurrency");
            server.WaitForConnection();

            StreamReader reader = new StreamReader(server);

            while (true)
            {
                String msg = reader.ReadLine();
                if (String.IsNullOrEmpty(msg)) // Finish if nothing is entered
                    break;
                else
                {
                    Console.WriteLine(msg); // Print the message received
                    Console.WriteLine(String.Join("", msg.Reverse())); // Print the reverse of the received message

                }
            }
        }
        

    }
    
    public class IPCNamedClient2 : IPCNamedClient
    {
        public override void ipcClientCommunicate()
        {
            
            Console.WriteLine("Creating client pipe...");
            var Receiverpipe = new NamedPipeClientStream("secretPipe2");
            var Senderpipe = new NamedPipeClientStream("secretPipe");
            Console.WriteLine("Connecting client pipe...");
            Receiverpipe.Connect();
            Senderpipe.Connect();
            Console.WriteLine("Client pipe connected");
            Console.WriteLine("...");   
            Console.WriteLine("Creating reader and writer...");
            StreamWriter writer = new StreamWriter(Senderpipe);
            StreamReader reader = new StreamReader(Receiverpipe);

            Console.WriteLine("Client pipe ready");
            while (true)
            {
                
                Console.WriteLine("key pressed");
                String msg = Console.ReadLine();
                if (String.IsNullOrEmpty(msg)) // Finish if nothing is entered
                    break;
                else
                {
                    writer.WriteLine(msg); // Print the message received
                    writer.Flush(); // Print the reverse of the received message
                }
                
            }
        
        }
    }
}