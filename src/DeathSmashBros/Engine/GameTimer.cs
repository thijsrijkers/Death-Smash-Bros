using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    class GameTimer 
    {
        public TimeSpan timeSpan { private set; get; }
        private SpriteFont font;
        private string timerString = "";

        public GameTimer()
        {
            font = Loader.getFont("debugtext");
            timeSpan = TimeSpan.FromMinutes(8);           
        }

        public void Update(GameTime gameTime)
        {
            timeSpan -= gameTime.ElapsedGameTime;
            timerString = timeSpan.ToString(); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, timerString, Vector2.Zero, Color.White);
        }
    }
}
