using System.Collections.Generic;

namespace HackeRank
{
    public static class SockMerchant
    {
        public static int sockMerchant(int n, List<int> ar)
        {
            int[] trackingArray = new int[100];
            int totalPairsOfSockets = 0;

            foreach (int socket in ar)
            {
                if (trackingArray[socket - 1].Equals(0))
                {
                    trackingArray[socket - 1] = 1; // first time we find this socket
                }
                else // new pair of sockets, incresae counter and restart this pair
                {
                    totalPairsOfSockets += 1;
                    trackingArray[socket - 1] = 0;
                }
            }

            return totalPairsOfSockets;
        }
    }
}
