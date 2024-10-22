﻿using DeathSmashBros.Engine.Drawables;
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
        private SpriteFont font;
        public EndScreen(ScreenManager _screenManager) : base(_screenManager)
        {
            font = Loader.getFont("debugtext");
            name = "end";
        }

        //Load content on screen
        public override void LoadContent(ScreenData data)
        {
            base.LoadContent(data);

            int bgHeight = MainGame.RENDER_HEIGHT;
            int bgWidth = MainGame.RENDER_WIDTH;
            string winner;
            string winnerName;
            string loserName;
            string loser;
            string winnerText;

            //Check who wins game
            if (screenData.Winner == "bot")
            {
                winner = "_enemy";
                loser = "_player";
                winnerText = "lost";
                winnerName = screenData.SelectedBotCharacter;
                loserName = screenData.SelectedCharacter;
            }
            else
            {
                winner = "_player";
                loser = "_enemy";
                winnerText = "win";
                loserName = screenData.SelectedBotCharacter;
                winnerName = screenData.SelectedCharacter;
            }
            //Back to homescreen button
            Button back = new Button("back", Loader.getTexture("backbutton"), new Vector2(25, 10), new Vector2(70, 70));
            back.click += Back_click;

            Image background = new Image(Loader.getTexture("WinnersBackground"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));

            //Big image on the left for the winner
            Image winnerSprite = new Image(Loader.getTexture("Characters/"+ winnerName + "/"+ winnerName), new Vector2(0, 0), new Vector2(400, bgHeight));

            //small images of the players on the right
            Image winnerFrame = new Image(Loader.getTexture("frames/" + winnerName + winner), new Vector2(350, 25), new Vector2(450, 300));
            Image loserFrame = new Image(Loader.getTexture("frames/" + loserName + loser), new Vector2(350, 150), new Vector2(450, 300));

            //Generate title win or lost
            Image endText = new Image(Loader.getTexture(winnerText), new Vector2(350, 30), new Vector2(395, 69));

            drawables.Add(background);
            drawables.Add(winnerSprite);
            drawables.Add(winnerFrame);
            drawables.Add(loserFrame);
            drawables.Add(endText);
            drawables.Add(back);
        }

        //Go back got homescreen
        private void Back_click(Button button)
        {
            screenManager.ChangeScreen("home");
        }
    }
}
