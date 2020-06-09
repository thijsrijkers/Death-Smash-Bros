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
        public CharacterSelectScreen(ScreenManager _screenManager) : base(_screenManager)
        {
            name = "characterSelect";
        }

        public override void LoadContent(ScreenData data)
        {
            int bgHeight = MainGame.RENDER_HEIGHT;
            int bgWidth = MainGame.RENDER_WIDTH;
            Image background = new Image(Loader.getTexture("backgroundCharacterWorldMenu"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));
            drawables.Add(background);

            int minX = 150;
            int minY = 100;
            int maxY = 400;
            int x = minX;
            int y = minY;

            while (y <= maxY)
            {
                Button rabfist = new Button("rabfist", Loader.getTexture("rabfist_playerselect"), new Vector2(x, y), new Vector2(200, 100));
                rabfist.click += Character_Click;
                x += 210;
                Button voidking = new Button("voidking", Loader.getTexture("voidking_playerselect"), new Vector2(x, y), new Vector2(200, 100));
                rabfist.click += Character_Click;
                x += 210;
                Button wraith = new Button("wraith", Loader.getTexture("wraith_playerselect"), new Vector2(x, y), new Vector2(200, 100));
                rabfist.click += Character_Click;
                drawables.Add(rabfist);
                drawables.Add(voidking);
                drawables.Add(wraith);

                x = minX;
                y += 125;
            }

            Button back = new Button("back", Loader.getTexture("backbutton"), new Vector2(25, 10), new Vector2(100, 75));
            back.click += Back_click;
            drawables.Add(back);

            base.LoadContent(data);
        }

        private void Back_click(object sender, EventArgs e)
        {
            screenManager.ChangeScreen("home");
        }

        private void Character_Click(object sender, EventArgs e)
        {
            // TODO: naar scene select navigeren en de naam van de character meegeven
        }
    }
}
