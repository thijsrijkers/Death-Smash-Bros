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

        public HomeScreen(ScreenManager _screenManager) : base(_screenManager) 
        {
            name = "home";
        }

        public override void LoadContent(ScreenData data)
        {
            int bgHeight = MainGame.RENDER_HEIGHT;
            int bgWidth = MainGame.RENDER_WIDTH;
            Image background = new Image(Loader.getTexture("homescreen-background"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));

            Button startButton = new Button("start", Loader.getTexture("homescreen-startbutton"), new Vector2(150, 300), new Vector2(200, 100));
            Button quitButton = new Button("quit", Loader.getTexture("homescreen-quitbutton"), new Vector2(440, 300), new Vector2(200, 100));

            // Events
            startButton.click += StartButton_click;
            quitButton.click += QuitButton_click;

            drawables.Add(background);
            drawables.Add(startButton);
            drawables.Add(quitButton);

            base.LoadContent(data);
        }

        private void StartButton_click(Button button)
        {
            screenManager.ChangeScreen("sceneSelect");
        }

        private void QuitButton_click(Button button)
        {
            Loader.Exit();
        }

    }
}
