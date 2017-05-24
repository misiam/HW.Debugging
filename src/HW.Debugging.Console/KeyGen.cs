using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HW.Debugging.Console
{
    class KeyGen
    {
        public static string GetKey()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();
            var networkInterface = interfaces.FirstOrDefault();
            if (networkInterface == null)
            {
                throw new ApplicationException("NetworkInterface.GetAllNetworkInterfaces should return at least one interface");

            }
            else
            {
                byte[] addressBytes = networkInterface.GetPhysicalAddress().GetAddressBytes();

                var dateBytes = BitConverter.GetBytes(DateTime.Now.Date.ToBinary());


                int length = Math.Min(addressBytes.Length, dateBytes.Length);

                var queue = new Queue<int>();
                for (int i = 0; i < length; i++)
                {
                    int value = (dateBytes[i] ^ addressBytes[i]) * 10;
                    queue.Enqueue(value);

                }

                string key = string.Join("-", queue);
                return key;
            }
        }

    }
}
