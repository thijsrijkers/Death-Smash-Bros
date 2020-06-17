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
        public HumanPlayer(Character character, bool playerOne) : base(character, playerOne)
        {
        }

        //timer for cooldown attack
        double timer = 0.8;         
        const double TIMER = 0.8;
        bool attackPossible = true;

        public override void UpdateAsync(Player otherPlayer, GameTime gameTime, Scene scene)
        {
            //Check if it is possible to attack
            base.UpdateAsync(otherPlayer, gameTime, scene);
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer -= elapsed;
            if (timer < 0.0)
            {
                //Timer expired, execute action
                timer = TIMER;   //Reset Timer
                attackPossible = true;
            }
            var keyboardState = Keyboard.GetState();

            //JumpAttack
            if(keyboardState.IsKeyDown(Keys.W))
            {
                if (attackPossible == true)
                {
                    this.character.jumpAttack();
                    attackPossible = false;
                }
            }
            //WalkLeft
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                if (this.character.dead == false)
                {
                    this.character.walkLeft();
                }
            }
            //WalkRight
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                if (this.character.dead == false)
                {
                    this.character.walkRight();
                }
            }
            //RegularAttack
            else if (keyboardState.IsKeyDown(Keys.Q))
            {
                if (attackPossible == true)
                {
                    this.character.regularAttack();
                    attackPossible = false;
                }
            }
            //Jump
            else if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (attackPossible == true)
                {
                    if (this.character.dead == false)
                    {
                        this.character.jump();
                        attackPossible = false;
                    }
                }
            }
            //SpecialAttack
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
