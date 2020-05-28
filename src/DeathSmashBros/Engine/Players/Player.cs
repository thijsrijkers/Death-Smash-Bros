using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public abstract class Player
    {
        public Character character;

        public abstract void Update();
        public virtual void KeyPressed()
        {
            // TODO
        }
    }
}
