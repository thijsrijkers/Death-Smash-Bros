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
            int bgHeight = MainGame.RENDER_HEIGHT;
            int bgWidth = MainGame.RENDER_WIDTH;
            background = new Image(Loader.getTexture("backgroundCharacterWorldMenu"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));
            drawables.Add(background);

            int minX = 150;
            int minY = 100;
            int maxY = 400;
            int x = minX;
            int y = minY;

            while (y <= maxY)
            {
                Button rabfist = new Button(Loader.getTexture("rabfist_playerselect"), new Vector2(x, y), new Vector2(200, 100));
                x += 210;
                Button voidking = new Button(Loader.getTexture("voidking_playerselect"), new Vector2(x, y), new Vector2(200, 100));
                x += 210;
                Button wraith = new Button(Loader.getTexture("wraith_playerselect"), new Vector2(x, y), new Vector2(200, 100));
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
