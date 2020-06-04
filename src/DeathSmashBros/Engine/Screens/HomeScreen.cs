using DeathSmashBros.Engine.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Screens
{
    public class HomeScreen : Screen
    {

        public HomeScreen() : base() 
        {
            name = "home";
        }

        public override void loadContent()
        {
            int bgHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            int bgWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            background = new Image(Loader.getTexture("homescreen-background"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));

            Button startButton = new Button(Loader.getTexture("homescreen-startbutton"), new Vector2(100, 300), new Vector2(200, 100));
            Button quitButton = new Button(Loader.getTexture("homescreen-quitbutton"), new Vector2(400, 300), new Vector2(200, 100));

            drawables.Add(background);
            drawables.Add(startButton);
            drawables.Add(quitButton);
        }
    }
}
