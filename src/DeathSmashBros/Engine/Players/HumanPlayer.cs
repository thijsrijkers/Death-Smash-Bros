using DeathSmashBros.Engine.Scenes;
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
        public HumanPlayer(Character character) : base(character)
        {
        }

        double timer = 0.6;         
        const double TIMER = 0.6;
        bool attackPossible = true;

        public override void Update(Player otherPlayer, GameTime gameTime, Scene scene)
        {
            base.Update(otherPlayer, gameTime, scene);
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer -= elapsed;
            if (timer < 0.0)
            {
                //Timer expired, execute action
                timer = TIMER;   //Reset Timer
                attackPossible = true;
            }
            var keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.W))
            {
                if (attackPossible == true)
                {
                    this.character.jumpAttack();
                    attackPossible = false;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                this.character.walkLeft();
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                this.character.walkRight();
            }
            else if (keyboardState.IsKeyDown(Keys.Q))
            {
                if (attackPossible == true)
                {
                    this.character.regularAttack();
                    attackPossible = false;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (attackPossible == true)
                {
                    this.character.jump();
                    attackPossible = false;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.E))
            {
                if (attackPossible == true)
                {
                    this.character.specialAttack();
                    attackPossible = false;
                }
            }
        }
    }
}
