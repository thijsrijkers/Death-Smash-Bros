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

        public Player(Character character)
        {
            this.character = character;
        }

        public virtual void Update(Player otherPlayer, GameTime gameTime, Scene scene)
        {
            this.character.Update(gameTime, scene);

            if(this.character.Hitbox.Intersects(otherPlayer.character.AttackHitbox))
            {
                this.character.damageTaken += 15; // TODO: ((thidelijk hardcoded?))
                otherPlayer.character.AttackHitbox = new Rectangle(0, 0, 0, 0); // attack hit, weg met hitbox
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.character.Draw(spriteBatch);
        }
    }
}
