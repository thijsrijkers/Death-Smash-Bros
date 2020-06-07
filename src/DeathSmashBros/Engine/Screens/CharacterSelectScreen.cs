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
    public class CharacterSelectScreen : Screen
    {
        public CharacterSelectScreen() : base()
        {
            name = "characterSelect";
        }

        public override void loadContent()
        {
            int bgHeight = GraphicsDeviceManager.DefaultBackBufferHeight;
            int bgWidth = GraphicsDeviceManager.DefaultBackBufferWidth;
            background = new Image(Loader.getTexture("backgroundCharacterWorldMenu"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));
            drawables.Add(background);

            int minX = 100;
            int maxX = 600;
            int minY = 50;
            int maxY = 400;
            int x = minX;
            int y = minY;

            while (y <= maxY)
            {
                Console.WriteLine("x and y are " + x + "and " + y);
                Button rabfist = new Button(Loader.getTexture("playerframe-rabfist"), new Vector2(x, y), new Vector2(300, 200));
                x += 200;
                Button voidking = new Button(Loader.getTexture("voidking_player"), new Vector2(x, y), new Vector2(300, 200));
                x += 200;
                Button wraith = new Button(Loader.getTexture("wraith_player"), new Vector2(x, y), new Vector2(300, 200));
                drawables.Add(rabfist);
                drawables.Add(voidking);
                drawables.Add(wraith);


                x = minX;
                y += 125;
            }



            Button back = new Button(Loader.getTexture("backbutton"), new Vector2(25, 10), new Vector2(100, 75));


            drawables.Add(back);

        }
    }
}
