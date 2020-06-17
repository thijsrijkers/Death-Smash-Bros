using DeathSmashBros.Engine.Characters;
using DeathSmashBros.Engine.Drawables;
using DeathSmashBros.Engine.Players;
using DeathSmashBros.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Screens
{
    public class FightScreen : Screen
    {
        private Rectangle stageHitbox;
        private SceneManager sceneManager;
        private Scene currentScene;
        private Player PlayerOne;
        private Player PlayerTwo;
        private GameTimer gameTimer;
        private List<Image> stocksPlayerOne;
        private List<Image> stocksPlayerTwo;

        private PlayerDamage playerDamage;

        public FightScreen(ScreenManager _screenManager, SceneManager _sceneManager) : base(_screenManager)
        {
            name = "fight";
            this.sceneManager = _sceneManager;
            this.playerDamage = new PlayerDamage();
        }

        //Load content on screen
        public override void LoadContent(ScreenData data)
        {
            base.LoadContent(data);

            //Players spawn in air
            PlayerOne = new HumanPlayer(GetNewCharacter(data.SelectedCharacter), true);
            PlayerOne.character.setPosition(new Vector2(200, 100));
            PlayerTwo = new BotPlayer(GetNewCharacter(data.SelectedBotCharacter), false);
            PlayerTwo.character.setPosition(new Vector2(500, 100));

            //Gets scene
            this.currentScene = sceneManager.GetScene(screenData.SelectedStage);

            int bgHeight = MainGame.RENDER_HEIGHT;
            int bgWidth = MainGame.RENDER_WIDTH;
            Image background = new Image(currentScene.stageBackground, new Vector2(0, 0), new Vector2(bgWidth, bgHeight));
            Image stage = new Image(currentScene.stage, new Vector2(0,0), new Vector2(bgWidth, bgHeight));

            Image playerOneFrame = new Image(Loader.getTexture($"frames/{data.SelectedCharacter}_player"), new Vector2(100, 325), new Vector2(250, 200));
            Image playerTwoFrame = new Image(Loader.getTexture($"frames/{data.SelectedBotCharacter}_enemy"), new Vector2(450, 325), new Vector2(250, 200));

            //Makes list for Character lives
            stocksPlayerOne = new List<Image>();
            stocksPlayerTwo = new List<Image>();

            getStocks();

            //Creates timer
            this.gameTimer = new GameTimer();

            drawables.Add(background);
            drawables.Add(stage);
            drawStocks();
            drawables.Add(playerOneFrame);
            drawables.Add(playerTwoFrame);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.PlayerOne.Update(PlayerTwo, gameTime, currentScene);
            this.PlayerTwo.Update(PlayerOne, gameTime, currentScene);
            this.gameTimer.Update(gameTime);

            // End the fight when the time is up
            if(gameTimer.timeSpan < TimeSpan.Zero)
            {   
                //Check wich character has most damage
                if(this.PlayerTwo.character.stocksLeft > this.PlayerOne.character.stocksLeft)
                {
                    screenData.Loser = "player";
                    screenData.Winner = "bot";
                }
                else if(this.PlayerTwo.character.stocksLeft < this.PlayerOne.character.stocksLeft)
                {
                    screenData.Loser = "bot";
                    screenData.Winner = "player";
                }
                else if (this.PlayerTwo.character.damageTaken < this.PlayerOne.character.damageTaken)
                {
                    screenData.Loser = "player";
                    screenData.Winner = "bot";
                }
                else
                {
                    screenData.Loser = "bot";
                    screenData.Winner = "player";
                }
                    this.screenManager.ChangeScreen("end");
            }

            //Updating character lives
            playerDamage.Update(PlayerOne, PlayerTwo);
            updateStocks();

            //Check if character is out of lives
            if(PlayerOne.character.getStocks() < 1)
            {
                screenData.Loser = "player";
                screenData.Winner = "bot";
                   this.screenManager.ChangeScreen("end");
            }
            else if(PlayerTwo.character.getStocks() < 1)
            {
                screenData.Loser = "bot";
                screenData.Winner = "player";
                this.screenManager.ChangeScreen("end");
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            PlayerOne.Draw(spritebatch);
            PlayerTwo.Draw(spritebatch);
            gameTimer.Draw(spritebatch);
            playerDamage.Draw(spritebatch);
        }

        //Creates character
        public Character GetNewCharacter(string name)
        {
            switch(name.ToLower())
            {
                default:
                case "voidking":
                    return new Voidking();
                case "wraith":
                    return new Wraith();
                case "rabfist":
                    return new Rabfist();
            }
        }

        //Get the character lives
        public void getStocks()
        { 
            stocksPlayerOne.Clear();
            stocksPlayerTwo.Clear();
            int x = 70;
            int y = 405;
            
            for (int i =0; i < PlayerOne.character.stocksLeft; i++)
			{
                Image stock = new Image(Loader.getTexture("stock"), new Vector2(x, y), new Vector2(15, 15));
                stocksPlayerOne.Add(stock);
                x += 20;
            }
            x = 660;
            
            for (int i = 0; i < PlayerTwo.character.stocksLeft; i++)
            {
                Image stock = new Image(Loader.getTexture("stock"), new Vector2(x, y), new Vector2(15, 15));
                stocksPlayerTwo.Add(stock);
                x += 20;
            }
        }

        //Draw the character lives
        public void drawStocks()
		{
            foreach (Image stock in stocksPlayerOne)
            {
                drawables.Add(stock);
            }
            foreach (Image stock in stocksPlayerTwo)
            {
                drawables.Add(stock);
            }
        }

        //Updating character lives
        public void updateStocks()
        {
            drawables.RemoveAll(x => stocksPlayerOne.Contains(x));
            drawables.RemoveAll(x => stocksPlayerTwo.Contains(x));
            getStocks();
            drawStocks();
        }
    }
}
