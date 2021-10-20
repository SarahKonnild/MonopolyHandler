using System;
using System.Net.Sockets;
using System.Threading;
using Monopoly.Game;

namespace Monopoly
{
    class Program
    {
        public static Monopoly.Game.Game game;
        public static DataAccess.DataAccess dataAccess;

        

        

        static void Main(string[] args)
        {
            
        }
    }

    public class Server {
        private TcpListener listener;
        private int port = 5000;
        public Server() {
            //try {
              //  listener = new TcpListener(port);
                //listener.Start();
                //Console.WriteLine("Server is running on port: " + port);
                //Thread thread = new Thread(new ThreadStart());
            //}
            //catch () { 
            //
            //}
        }

        public void StartServer() {
            int startPos = 0;
        }
    }
}
