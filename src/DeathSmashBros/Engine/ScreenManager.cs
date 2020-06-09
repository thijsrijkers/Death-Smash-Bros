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
            ScreenData data;
            // Unload the previous screen
            if(this.current != "")
            {
                data = screens.First(x => x.name == current).UnloadContent();
            }
            else
            {
                data = new ScreenData();
            }
                          
            // Load the new screen
            this.current = name;
            screens.First(x => x.name == current).LoadContent(data);
        }
        
        public void UpdateScreen()
        {
            screens.First(x => x.name == current).Update();
        }

        public void DrawScreen(SpriteBatch spriteBatch)
        {
            screens.First(x => x.name == current).Draw(spriteBatch);
        }
    }
}
