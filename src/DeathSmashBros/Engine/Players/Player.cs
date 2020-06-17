using DeathSmashBros.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public Texture2D playerTag;

        public Player(Character character, bool playerOne)
        {
            this.character = character;
            this.playerTag = playerTag;
            if(playerOne)
            {
                this.playerTag = Loader.getTexture("playertag");
            }
            else
            {
                this.playerTag = Loader.getTexture("bottag");
            }
        }

        public virtual void UpdateAsync(Player otherPlayer, GameTime gameTime, Scene scene)
        {
            this.character.Update(gameTime, scene);

            //Check if hitbox is hit
            if(this.character.Hitbox.Intersects(otherPlayer.character.AttackHitbox))
            {
                //Deals damage to opponnent, calculated by character power
                this.character.damageTaken += (3 + otherPlayer.character.power); 
                if(this.character.Hitbox.X > otherPlayer.character.Hitbox.X)
                {
                    this.character.Hitbox.X = this.character.Hitbox.X + (int)(2 * this.character.damageTaken);
                    this.character.Hitbox.Y = this.character.Hitbox.Y - (int)(1 * this.character.damageTaken / 2);
                }
                else
                {
                    this.character.Hitbox.X = this.character.Hitbox.X - (int)(2 * this.character.damageTaken);
                    this.character.Hitbox.Y = this.character.Hitbox.Y - (int)(1 * this.character.damageTaken / 2);
                }
                otherPlayer.character.AttackHitbox = new Rectangle(0, 0, 0, 0); // attack hit, hitbox gone
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.character.Draw(spriteBatch);
            spriteBatch.Draw(this.playerTag, new Rectangle(this.character.Hitbox.X+10, this.character.Hitbox.Y - 70, 50, 50), Color.White);
        }
    }
}
