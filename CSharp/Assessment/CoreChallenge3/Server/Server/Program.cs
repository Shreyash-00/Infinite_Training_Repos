// Program.cs in RemotingServer project
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace RemotingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a HTTP channel on port 86
            HttpChannel hc = new HttpChannel(86);
            ChannelServices.RegisterChannel(hc);

            // Register the RemoteServices class as a well-known service type
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteServices),   // RemoteServices class type
                "OurRemoteServices",     // URI for the remote object
                WellKnownObjectMode.Singleton  // Singleton mode
            );

            Console.WriteLine("Server Services started at Port No. 86.......");
            Console.WriteLine("Press any key to stop the server");
            Console.Read();
        }
    }
}
