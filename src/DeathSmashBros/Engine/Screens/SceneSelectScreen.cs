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
        public SceneSelectScreen(ScreenManager _screenManager) : base(_screenManager)
        {
            name = "sceneSelect";
        }

        public override void LoadContent(ScreenData data)
        {
            int bgHeight = GraphicsDeviceManager.DefaultBackBufferHeight;
            int bgWidth = GraphicsDeviceManager.DefaultBackBufferWidth;
            Image background = new Image(Loader.getTexture("backgroundCharacterWorldMenu"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));
            drawables.Add(background);

            int minX = 150;
            int maxX = 600;
            int minY = 100;
            int maxY = 400;
            int x = minX;
            int y = minY;

            while (y <= maxY)
            {
                while (x <= maxX)
                {
                    Button stageItem = new Button("cloud", Loader.getTexture("CloudStageButton"), new Vector2(x, y), new Vector2(200, 100));
                    stageItem.click += Stage_click;
                    drawables.Add(stageItem);

                    x += 315;
                }
                x = minX;
                y += 375;
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

        private void Stage_click(object sender, EventArgs e)
        {
            screenManager.ChangeScreen("characterSelect");
        }
    }
}
