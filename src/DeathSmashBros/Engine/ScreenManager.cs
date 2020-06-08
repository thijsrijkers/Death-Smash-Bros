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

        public void AddScreen(Screen screen)
        {
            this.screens.Add(screen);
        }

        public void ChangeScreen(string name)
        {
            // Unload the previous screen
            if(this.current != "")
            {
                screens.First(x => x.name == current).unloadContent();
            }
                          
            // Load the new screen
            this.current = name;
            screens.First(x => x.name == current).loadContent();
        }
        
        public void UpdateScreen()
        {
            screens.First(x => x.name == current).update();
        }

        public void DrawScreen(SpriteBatch spriteBatch)
        {
            screens.First(x => x.name == current).draw(spriteBatch);
        }
    }
}
