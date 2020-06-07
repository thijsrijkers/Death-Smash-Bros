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
    public class SceneSelectScreen : Screen
    {
        public SceneSelectScreen() : base()
        {
            name = "sceneselect";
        }

        public override void loadContent()
        {
            int bgHeight = GraphicsDeviceManager.DefaultBackBufferHeight;
            int bgWidth = GraphicsDeviceManager.DefaultBackBufferWidth;
            background = new Image(Loader.getTexture("backgroundCharacterWorldMenu"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));
            drawables.Add(background);

            int minX = 150;
            int maxX = 600;
            int minY = 100;
            int maxY = 400;
            int x = minX;
            int y = minY;

            while (y <= maxY)
            {
                Console.WriteLine("x and y are " + x + "and " + y);
                while (x <= maxX)
                {
                    
                    Button stageItem = new Button(Loader.getTexture("CloudStageButton"), new Vector2(x, y), new Vector2(200, 100));
                    drawables.Add(stageItem);
                    Console.WriteLine("x and y are " + x + "and " + y);

                    x += 200;
                }
                x = minX;
                y += 125;
            }

            

            Button back = new Button(Loader.getTexture("backbutton"), new Vector2(25, 10), new Vector2(100, 75));

            
            drawables.Add(back);
            

        }
    }
}
