using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Players
{
    public class HumanPlayer : Player
    {
        public override void Update(Player otherPlayer)
        {
            var keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.W))
            {
                //FIRE!!!
            }else if (keyboardState.IsKeyDown(Keys.A))
            {

            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {

            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {

            }
            else if (keyboardState.IsKeyDown(Keys.Q))
            {

            }
            else if (keyboardState.IsKeyDown(Keys.Space))
            {

            }
            else if (keyboardState.IsKeyDown(Keys.E))
            {

            }
        }
    }
}
