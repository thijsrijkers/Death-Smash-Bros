using DeathSmashBros.Engine.Characters;
using DeathSmashBros.Engine.Drawables;
using DeathSmashBros.Engine.Players;
using DeathSmashBros.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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

        public FightScreen(ScreenManager _screenManager, SceneManager _sceneManager) : base(_screenManager)
        {
            name = "fight";
            this.sceneManager = _sceneManager;
        }

        public override void LoadContent(ScreenData data)
        {
            base.LoadContent(data);

            // TODO characters meenemen van ScreenData
            PlayerOne = new HumanPlayer(new Voidking());
            PlayerOne.character.setPosition(new Vector2(200, 100));
            PlayerTwo = new BotPlayer(new Voidking());

            this.currentScene = sceneManager.GetScene(screenData.SelectedStage);

            int bgHeight = MainGame.RENDER_HEIGHT;
            int bgWidth = MainGame.RENDER_WIDTH;
            Image background = new Image(currentScene.stageBackground, new Vector2(0, 0), new Vector2(bgWidth, bgHeight));
            Image stage = new Image(currentScene.stage, new Vector2(0,0), new Vector2(bgWidth, bgHeight));

            drawables.Add(background);
            drawables.Add(stage);
        }

        // PlayerTwo tijdelijk uitgecomment om eerst te focusen op de human player
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.PlayerOne.Update(PlayerTwo, gameTime);
            //this.PlayerTwo.Update(PlayerOne, gameTime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            PlayerOne.Draw(spritebatch);
            //PlayerTwo.Draw(spritebatch);
        }
    }
}
