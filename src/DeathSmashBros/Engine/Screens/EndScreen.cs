using DeathSmashBros.Engine.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Screens
{
    public class EndScreen : Screen
    {
        public EndScreen(ScreenManager _screenManager) : base(_screenManager)
        {
            name = "end";
        }

        public override void LoadContent(ScreenData data)
        {
            //TODO: winnaar en verliezer laten zien op basis van een echte uitslag en dus niet hardcoded sprites
            // Hoi, gebruik de ScreenData voor meenemen van data van/naar andere screens
            base.LoadContent(data);

            int bgHeight = MainGame.RENDER_HEIGHT;
            int bgWidth = MainGame.RENDER_WIDTH;
            string winner;
            string winnerName;
            string loserName;
            string loser;

            if (screenData.Winner == "bot")
            {
                winner = "_enemy";
                loser = "_player";
                winnerName = screenData.SelectedBotCharacter;
                loserName = screenData.SelectedCharacter;
            }
            else
            {
                winner = "_player";
                loser = "_enemy";
                loserName = screenData.SelectedBotCharacter;
                winnerName = screenData.SelectedCharacter;
            }
            Button back = new Button("back", Loader.getTexture("backbutton"), new Vector2(25, 10), new Vector2(70, 70));
            back.click += Back_click;

            Image background = new Image(Loader.getTexture("homescreen-background"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));

            Image winnerSprite = new Image(Loader.getTexture("Characters/"+ winnerName + "/"+ winnerName), new Vector2(0, 0), new Vector2(400, bgHeight));

            Image winnerFrame = new Image(Loader.getTexture("frames/" + winnerName + winner), new Vector2(350, 25), new Vector2(450, 300));
            Image loserFrame = new Image(Loader.getTexture("frames/" + loserName + loser), new Vector2(350, 150), new Vector2(450, 300));

            drawables.Add(background);
            drawables.Add(winnerSprite);
            drawables.Add(winnerFrame);
            drawables.Add(loserFrame);
            drawables.Add(back);
        }

        private void Back_click(Button button)
        {
            screenManager.ChangeScreen("home");
        }
    }
}
