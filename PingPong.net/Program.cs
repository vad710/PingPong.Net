using System;

namespace PingPong.net
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PingPongGame game = new PingPongGame())
            {
                game.Run();
            }
        }
    }
#endif
}

