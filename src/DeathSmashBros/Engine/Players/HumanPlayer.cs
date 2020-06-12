using Microsoft.Xna.Framework;
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
        public override void Update(Player otherPlayer, GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.W))
            {
                //FIRE!!!
                this.character.jumpAttack();
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                this.character.walkLeft();
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                // doot doot
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                this.character.walkRight();
            }
            else if (keyboardState.IsKeyDown(Keys.Q))
            {
                this.character.regularAttack();
            }
            else if (keyboardState.IsKeyDown(Keys.Space))
            {
                this.character.jump();
            }
            else if (keyboardState.IsKeyDown(Keys.E))
            {
                this.character.specialAttack();
            }
        }
    }
}
