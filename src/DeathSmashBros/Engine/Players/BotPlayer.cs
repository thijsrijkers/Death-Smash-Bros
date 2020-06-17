using DeathSmashBros.Engine.Scenes;
using Microsoft.Xna.Framework;
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
        public BotPlayer(Character character) : base(character)
        {
        }

        DateTime previoustick = DateTime.Now;
        public override void Update(Player otherPlayer, GameTime gameTime, Scene scene)
        {
            base.Update(otherPlayer, gameTime, scene);

            //Walk-distance check.
            //Follows character
            if (this.character.getPosition.X < otherPlayer.character.getPosition.X)
            {
                double DistanceCheck = this.character.getPosition.X - otherPlayer.character.getPosition.X;
                if (DistanceCheck < -100)
                {
                    this.character.walkRight();
                }
            }
            else if (this.character.getPosition.X > otherPlayer.character.getPosition.X)
            {
                double DistanceCheck = this.character.getPosition.X - otherPlayer.character.getPosition.X;
                if (DistanceCheck > 100)
                {
                    this.character.walkLeft();
                }
            }
            //Let bot jump if character is higher than him
            else if (this.character.getPosition.Y > otherPlayer.character.getPosition.Y)
            {
                this.character.jump();
            }
            else if (this.character.getPosition.Y > 280)
            {
                this.character.jump();
            }

            if (DateTime.Now.Subtract(previoustick).TotalMilliseconds > 1000)
            {
                //Random number for choosing attack
                Random rnd = new Random();
                int num = rnd.Next(3);

                //Attack check and distance check.
                if (this.character.getPosition.X < otherPlayer.character.getPosition.X)
                {
                    //if bot is close to player, bot attacks
                    double DistanceCheck = this.character.getPosition.X - otherPlayer.character.getPosition.X;
                    if (DistanceCheck <= 100)
                    {
                        if (num != 1)
                        {
                            this.character.specialAttack();
                        }
                        else
                        {
                            this.character.regularAttack();
                        }
                    }
                }
                else if (this.character.getPosition.X > otherPlayer.character.getPosition.X)
                {
                    double DistanceCheck = this.character.getPosition.X - otherPlayer.character.getPosition.X;
                    if (DistanceCheck <= 100)
                    {
                        if (num != 1)
                        {
                            this.character.specialAttack();
                        }
                        else
                        {
                            this.character.regularAttack();
                        }
                    }
                }
                else if (this.character.getPosition.Y <= otherPlayer.character.getPosition.Y || this.character.getPosition.Y >= otherPlayer.character.getPosition.Y)
                {
                    double DistanceCheck = this.character.getPosition.Y - otherPlayer.character.getPosition.Y;
                    if (DistanceCheck <= 100)
                    {
                        this.character.jumpAttack();
                    }
                }
                previoustick = DateTime.Now;
            }
        }
    }
}
