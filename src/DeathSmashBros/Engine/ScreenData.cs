using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public class ScreenData
    {
        public string SelectedCharacter = "";
        public string SelectedBotCharacter = "";
        public string SelectedStage = "";

        public string Winner = "";
        public string Loser = "";

        public int HumanPlayerStocks = 3;
        public int BotPlayerStocks = 3;

        public string PreviousScreen = "";
    }
}
