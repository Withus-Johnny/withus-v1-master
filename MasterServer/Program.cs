using MasterServer.Environments;
using Shared.Networks;

namespace MasterServer
{
    public class Program
    {
        public static Envir Envir { get; private set; }
        static void Main(string[] args)
        {
            Settings.LoadClientVersion();

            Packet.IsServer = true;
            Envir = new Envir();
            Envir.Start();

            Console.WriteLine("WITHUS SERVER END");
            Console.ReadKey();
        }
    }
}