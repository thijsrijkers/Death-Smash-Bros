using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public class ScreenManager
    {
        private List<Screen> screens;
        private string current = "";

        public ScreenManager()
        {
            this.screens = new List<Screen>();
        }

        public void ChangeScreen(string name)
        {
            this.current = name;
        }
        
        public void UpdateScreen(GameTime gameTime)
        {
            //screens.First(x => x.name == current) Update method??
        }

        public void DrawScreen(SpriteBatch spriteBatch)
        {
            //screens.First(x => x.name == current) Draw method??
        }
    }
}
