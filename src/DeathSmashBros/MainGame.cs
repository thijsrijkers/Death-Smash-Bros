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

        // 1920x1080 rendering, scaled
        RenderTarget2D renderTarget;

        SpriteFont debugFont;

        // Test voor animation
        //Animation voidking_idle;

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

            // Generate screens
            screenManager = new ScreenManager();
            screenManager.AddScreen(new HomeScreen(screenManager));
            screenManager.AddScreen(new SceneSelectScreen(screenManager));
            screenManager.AddScreen(new CharacterSelectScreen(screenManager));
            screenManager.AddScreen(new FightScreen(screenManager, sceneManager));
            screenManager.AddScreen(new EndScreen(screenManager));

            screenManager.ChangeScreen("home"); // initiele screen

            renderTarget = new RenderTarget2D(GraphicsDevice, RENDER_WIDTH, RENDER_HEIGHT);

            /*
             
            // Test animation load
            List<Texture2D> voidk = new List<Texture2D>();
            for(int i = 1; i < 9; i++)
            {
                voidk.Add(Loader.getTexture($"characters/Voidking/idle/idle{i}"));
            }
            voidking_idle = new Animation(TimeSpan.FromMilliseconds(1300), voidk.ToArray());

            */

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Loader.UpdateMouse();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            // Mouse position calculations
            var mousestate = Mouse.GetState();
            var mouseX = mousestate.X;
            var mouseY = mousestate.Y; // Positions relative to window
            mouseX = (int)(((float)mouseX / Window.ClientBounds.Width) * RENDER_WIDTH);
            mouseY = (int)(((float)mouseY / Window.ClientBounds.Height) * RENDER_HEIGHT);
            MousePositions = new Point(mouseX, mouseY);
            // misschien een mogelijkheid ergens deze waardes zonder statics door te voeren naar de desbetreffende classes?


            screenManager.UpdateScreen();

            //voidking_idle.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here

            // Renderen game zelf naar rendertarget
            GraphicsDevice.SetRenderTarget(renderTarget);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            screenManager.DrawScreen(spriteBatch);
            spriteBatch.End();

            // rendertarget renderen naar window
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(renderTarget, new Rectangle(0,0,Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            //voidking_idle.Draw(spriteBatch, new Vector2(15, 15), new Vector2(300, 300));
            spriteBatch.DrawString(debugFont, $"mouse x {MousePositions.X} mouse y {MousePositions.Y}", Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
