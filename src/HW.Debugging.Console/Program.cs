using System;

namespace HW.Debugging.Console
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                string key = KeyGen.GetKey();
                System.Console.WriteLine("key: ");
                System.Console.WriteLine(key);

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                
            }
            System.Console.ReadKey();
        }

    }
}
