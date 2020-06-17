using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    class PlayerDamage
    {
        public SpriteFont font;
        public int damagePlayerOne;
        public int damagePlayerTwo;

        public PlayerDamage()
        {
            font = Loader.getFont("debugtext");
            damagePlayerOne = 0;
            damagePlayerTwo = 0;
        }

        public void Update(Player playerone, Player playertwo)
        {
            //Adds damage to players
            damagePlayerOne = (int)playerone.character.damageTaken;
            damagePlayerTwo = (int)playertwo.character.damageTaken;
        }

        public void Draw(SpriteBatch spriteBatch)
        {  
            //Draws the damage on screen
            string tempStr1 = $"{damagePlayerOne}";
            spriteBatch.DrawString(font, tempStr1, new Vector2(240, 400), Color.White);

            string tempStr2 = $"{damagePlayerTwo}";
            spriteBatch.DrawString(font, tempStr2, new Vector2(590, 400), Color.White);
        }
    }
}
