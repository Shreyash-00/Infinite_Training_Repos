// RemoteServices.cs in RemotingServer project
using System;

namespace RemotingServer
{
    // Service class
    public class RemoteServices : MarshalByRefObject
    {
        public int WriteMessage(int n1, int n2)
        {
            int maxval = Math.Max(n1, n2);
            Console.WriteLine("Remote Call Executed...");
            return maxval;
        }
    }
}
