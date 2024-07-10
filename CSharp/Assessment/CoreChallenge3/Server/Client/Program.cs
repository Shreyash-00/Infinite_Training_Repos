// Program.cs in RemotingClient project
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using RemotingServer; // Make sure to add reference to RemotingServer project

namespace RemotingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a HTTP channel on port 8002
            HttpChannel c = new HttpChannel(8002);
            ChannelServices.RegisterChannel(c);

            // Get a proxy object for RemoteServices hosted on the server
            RemoteServices rserviceproxy = (RemoteServices)Activator.GetObject(
                typeof(RemoteServices),   // RemoteServices class type
                "http://localhost:86/OurRemoteServices"  // URI of the remote object
            );

            // Invoke the methods of the remote object through the proxy object
            Console.WriteLine("The max number is: " + rserviceproxy.WriteMessage(28, 7));

            Console.WriteLine("Press Enter to exit...");
            Console.Read();
        }
    }
}
