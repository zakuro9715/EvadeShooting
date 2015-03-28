using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evade
{
    public static class GameState
    {
        public enum GameLevel
        {
            Easy,
            Nomal,
            Hard
        }
        public static GameLevel Level = GameLevel.Nomal;
        public static bool isEvadeAll = false;
        public static bool isDebugMode = false;
        public static bool IsExtraStage = false;
    }
}
