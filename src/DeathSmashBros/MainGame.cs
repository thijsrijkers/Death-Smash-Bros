using DeathSmashBros.Engine;
using DeathSmashBros.Engine.Drawables;
using DeathSmashBros.Engine.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DeathSmashBros
{
    public class MainGame : Game
    {
        public static Point MousePositions;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScreenManager screenManager;

        // 1920x1080 rendering, scaled
        RenderTarget2D renderTarget;

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
            // Generate screens
            this.screenManager = new ScreenManager();
            this.screenManager.AddScreen(new CharacterSelectScreen());
            this.screenManager.ChangeScreen("characterSelect"); // initiele screen

            renderTarget = new RenderTarget2D(GraphicsDevice, 1920, 1080);
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            // Mouse position calculations
            var mousestate = Mouse.GetState();
            var mouseX = mousestate.X;
            var mouseY = mousestate.Y; // Positions relative to window
            mouseX = (int)(((float)mouseX / Window.ClientBounds.Width) * 1920);
            mouseY = (int)(((float)mouseY / Window.ClientBounds.Height) * 1080);
            MousePositions = new Point(mouseX, mouseY);
            // misschien een mogelijkheid ergens deze waardes zonder statics door te voeren naar de desbetreffende classes?


            screenManager.UpdateScreen(gameTime);
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
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
