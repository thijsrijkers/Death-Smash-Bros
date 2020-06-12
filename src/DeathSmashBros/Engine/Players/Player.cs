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

        public virtual void Update(Player otherPlayer, GameTime gameTime)
        {
            this.character.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.character.Draw(spriteBatch);
        }
    }
}
