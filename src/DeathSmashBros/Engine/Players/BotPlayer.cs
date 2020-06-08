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
                Random rnd = new Random();
                int num = rnd.Next(3);

                //Walk-distance check. Rabfist is momenteel de bot/AI
                if (character.getPosition.X < character.getPosition.X)
                {
                    double DistanceCheck = character.getPosition.X - character.getPosition.X;
                    if (DistanceCheck > 100)
                    {
                        character.walkLeft();
                    }
                }
                else if(character.getPosition.X > character.getPosition.X)
                {
                    double DistanceCheck = character.getPosition.X - character.getPosition.X;
                    if (DistanceCheck > 100)
                    {
                        character.walkRight();
                    }
                }
                else if (character.getPosition.Y < character.getPosition.Y)
                {
                    character.jump();
                }

                //Attack check and distance check.
                if (character.getPosition.X < character.getPosition.X)
                {
                    double DistanceCheck = character.getPosition.X - character.getPosition.X;
                    if (DistanceCheck <= 100)
                    {
                        if(num != 1)
                        {
                            character.specialAttack();
                        }
                        else
                        {
                            character.regularAttack();
                        }
                    }
                }
                else if (character.getPosition.X > character.getPosition.X)
                {
                    double DistanceCheck = character.getPosition.X - character.getPosition.X;
                    if (DistanceCheck <= 100)
                    {
                        if (num != 1)
                        {
                            character.specialAttack();
                        }
                        else
                        {
                            character.regularAttack();
                        }
                    }
                }
                else if (character.getPosition.Y <= character.getPosition.Y || character.getPosition.Y >= character.getPosition.Y)
                {
                    double DistanceCheck = character.getPosition.Y - character.getPosition.Y;
                    if (DistanceCheck <= 100)
                    {
                        character.jumpAttack();
                    }
                }

                //The tread timer.
                Thread.Sleep(600);
                // TODO andere oplossing
            }
        }
    }
}
