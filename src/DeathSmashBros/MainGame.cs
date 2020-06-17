using DeathSmashBros.Engine;
using DeathSmashBros.Engine.Drawables;
using DeathSmashBros.Engine.Scenes;
using DeathSmashBros.Engine.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DeathSmashBros
{
    public class MainGame : Game
    {
        public const int RENDER_WIDTH = 800;
        public const int RENDER_HEIGHT = 480;

        public static Point MousePositions;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScreenManager screenManager;
        SceneManager sceneManager;

        // 800x480 rendering, scaled
        RenderTarget2D renderTarget;

        SpriteFont debugFont;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Loader.Init(this);
            debugFont = Content.Load<SpriteFont>("debugtext");
            sceneManager = new SceneManager();
            sceneManager.RegisterScene(new CloudStage());
            sceneManager.RegisterScene(new GrasslandStage());

            // Generate screens
            screenManager = new ScreenManager();
            screenManager.AddScreen(new HomeScreen(screenManager));
            screenManager.AddScreen(new SceneSelectScreen(screenManager));
            screenManager.AddScreen(new CharacterSelectScreen(screenManager));
            screenManager.AddScreen(new FightScreen(screenManager, sceneManager));
            screenManager.AddScreen(new EndScreen(screenManager));

            screenManager.ChangeScreen("home"); // initiele screen

            renderTarget = new RenderTarget2D(GraphicsDevice, RENDER_WIDTH, RENDER_HEIGHT);
        }

        protected override void UnloadContent()
        {
        }

        KeyboardState previous = new KeyboardState();
        protected override void Update(GameTime gameTime)
        {
            var newstate = Keyboard.GetState();
            if(newstate.IsKeyDown(Keys.F1) && previous.IsKeyUp(Keys.F1))
            {
                if (!this.graphics.IsFullScreen)
                {
                    this.Window.IsBorderless = true;
                }
                else
                {
                    this.Window.IsBorderless = false;
                }
                this.graphics.ToggleFullScreen();
            }
            previous = newstate;

            Loader.UpdateMouse();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Mouse position calculations
            var mousestate = Mouse.GetState();
            var mouseX = mousestate.X;
            var mouseY = mousestate.Y; // Positions relative to window
            mouseX = (int)(((float)mouseX / Window.ClientBounds.Width) * RENDER_WIDTH);
            mouseY = (int)(((float)mouseY / Window.ClientBounds.Height) * RENDER_HEIGHT);
            MousePositions = new Point(mouseX, mouseY);
            // misschien een mogelijkheid ergens deze waardes zonder statics door te voeren naar de desbetreffende classes?


            screenManager.UpdateScreen(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Renderen game zelf naar rendertarget
            GraphicsDevice.SetRenderTarget(renderTarget);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            screenManager.DrawScreen(spriteBatch);
            spriteBatch.End();

            // rendertarget renderen naar window
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(renderTarget, new Rectangle(0,0,Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            //spriteBatch.DrawString(debugFont, $"mouse x {MousePositions.X} mouse y {MousePositions.Y}", Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
