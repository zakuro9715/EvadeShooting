using System;

namespace Evade
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリー ポイントです。
        /// </summary>
        static void Main(string[] args)
        {
            using (EvadeShootingGame game = new EvadeShootingGame())
            {
                game.Run();
            }
        }
    }
#endif
}

