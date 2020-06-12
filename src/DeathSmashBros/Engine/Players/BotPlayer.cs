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

        public override void Update(Player otherPlayer, GameTime gameTime)
        {
            base.Update(otherPlayer, gameTime);
            if (gameTime.TotalGameTime.TotalMilliseconds % 600 == 0)
            {
                Random rnd = new Random();
                int num = rnd.Next(3);

                //Walk-distance check. Rabfist is momenteel de bot/AI
                if (this.character.getPosition.X < otherPlayer.character.getPosition.X)
                {
                    double DistanceCheck = this.character.getPosition.X - otherPlayer.character.getPosition.X;
                    if (DistanceCheck > 100)
                    {
                        this.character.walkLeft();
                    }
                }
                else if (this.character.getPosition.X > otherPlayer.character.getPosition.X)
                {
                    double DistanceCheck = this.character.getPosition.X - otherPlayer.character.getPosition.X;
                    if (DistanceCheck > 100)
                    {
                        this.character.walkRight();
                    }
                }
                else if (this.character.getPosition.Y < otherPlayer.character.getPosition.Y)
                {
                    this.character.jump();
                }

                //Attack check and distance check.
                if (this.character.getPosition.X < otherPlayer.character.getPosition.X)
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
            }
        }
    }
}
