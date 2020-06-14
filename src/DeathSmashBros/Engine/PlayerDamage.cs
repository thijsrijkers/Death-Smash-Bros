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

        public void Update(PlayerDamage playerDamage)
        {
        //    if (//if player one gets damage)
        //    {
        //        damagePlayerOne += 20;
        //    }
        //    else if (//if player two gets damage)
        //    {
        //        damagePlayerTwo += 20;
        //    }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            string tempStr1 = damagePlayerOne + "%";
            spriteBatch.DrawString(font, tempStr1, new Vector2(250, 410), Color.White);

            string tempStr2 = damagePlayerTwo + "%";
            spriteBatch.DrawString(font, tempStr2, new Vector2(600, 410), Color.White);
        }
    }
}
