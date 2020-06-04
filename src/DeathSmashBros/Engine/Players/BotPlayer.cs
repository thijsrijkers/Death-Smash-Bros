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
        Player player;
        public override void Update()
        {
            while (true)
            {
                Random rnd = new Random();
                int num = rnd.Next(3);

                //Walk-distance check. Rabfist is momenteel de bot/AI
                if (player.character.rabfist.getPosition.X < player.character.wraith.getPosition.X)
                {
                    double DistanceCheck = player.character.wraith.getPosition.X - player.character.rabfist.getPosition.X;
                    if (DistanceCheck > 100)
                    {
                        player.character.rabfist.walkLeft();
                    }
                }
                else if(player.character.rabfist.getPosition.X > player.character.wraith.getPosition.X)
                {
                    double DistanceCheck = player.character.rabfist.getPosition.X - player.character.wraith.getPosition.X;
                    if (DistanceCheck > 100)
                    {
                        player.character.rabfist.walkRight();
                    }
                }
                else if (player.character.rabfist.getPosition.Y < player.character.wraith.getPosition.Y)
                {
                    player.character.rabfist.jump();
                }

                //Attack check and distance check.
                if (player.character.rabfist.getPosition.X < player.character.wraith.getPosition.X)
                {
                    double DistanceCheck = player.character.wraith.getPosition.X - player.character.rabfist.getPosition.X;
                    if (DistanceCheck <= 100)
                    {
                        if(num != 1)
                        {
                            player.character.rabfist.specialAttack();
                        }
                        else
                        {
                            player.character.rabfist.regularAttack();
                        }
                    }
                }
                else if (player.character.rabfist.getPosition.X > player.character.wraith.getPosition.X)
                {
                    double DistanceCheck = player.character.rabfist.getPosition.X - player.character.wraith.getPosition.X;
                    if (DistanceCheck <= 100)
                    {
                        if (num != 1)
                        {
                            player.character.rabfist.specialAttack();
                        }
                        else
                        {
                            player.character.rabfist.regularAttack();
                        }
                    }
                }
                else if (player.character.rabfist.getPosition.Y <= player.character.wraith.getPosition.Y || player.character.rabfist.getPosition.Y >= player.character.wraith.getPosition.Y)
                {
                    double DistanceCheck = player.character.wraith.getPosition.Y - player.character.rabfist.getPosition.Y;
                    if (DistanceCheck <= 100)
                    {
                        player.character.rabfist.jumpAttack();
                    }
                }

                //The tread timer.
                Thread.Sleep(600);
            }
        }
    }
}
