using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;

namespace Exercise
{
    public class IPCNamedServer
    {
        public virtual void ipcServerCommunicate()
        {
            Console.WriteLine("Pipe Server is being executed ...");
            Console.WriteLine("[Server] Enter a message to be reversed by the client (press ENTER to exit)");

            //Client
            var client = new NamedPipeClientStream("PipesOfConcurrency1");
            client.Connect();

            StreamWriter writer = new StreamWriter(client);

            while (true)
            {
                String input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                    break;
                else
                {
                    writer.WriteLine(input);
                    writer.Flush();
                }
            }
        }
    }
    public class IPCNamedServer2 : IPCNamedServer
    {
        public override void ipcServerCommunicate()
        {
            Console.WriteLine("Creating Server pipe...");
            var Receiverpipe = new NamedPipeServerStream("secretPipe");
            var Senderpipe = new NamedPipeServerStream("secretPipe2");
            Console.WriteLine("Connecting Server pipe...");
            Receiverpipe.WaitForConnection();
            Senderpipe.WaitForConnection();
            Console.WriteLine("Server pipe connected");
            Console.WriteLine("...");   
            Console.WriteLine("Creating reader and writer...");
            StreamWriter writer = new StreamWriter(Senderpipe);
            StreamReader reader = new StreamReader(Receiverpipe);

            Console.WriteLine("Server pipe ready");



            while (true)
            {
                if (Console.KeyAvailable){
                    
                    String msg = Console.ReadLine();
                    if (String.IsNullOrEmpty(msg)) // Finish if nothing is entered
                        break;
                    else
                    {
                        writer.WriteLine(msg); // Print the message received
                        writer.Flush(); // Print the reverse of the received message
                    }
                }
                else {
                    String text = reader.ReadLine();
                    Console.WriteLine(text);
                    
                }
                Thread.Sleep(100);
            }
        }
    }
}