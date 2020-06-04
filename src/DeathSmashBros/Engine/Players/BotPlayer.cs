using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Players
{
    public class BotPlayer : Player
    {
        public override void Update()
        {
            while (true)
            {

                Thread.Sleep(1000);
            }
        }
    }
}
