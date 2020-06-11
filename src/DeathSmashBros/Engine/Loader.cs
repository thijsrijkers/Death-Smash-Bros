using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public static class Loader
    {
        private static MainGame game;

        public static void Init(MainGame _game)
        {
            game = _game;
        }

        public static Texture2D getTexture(string path)
        {
            // Laadt een texture in van de content pipeline.
            // TODO caching
            return game.Content.Load<Texture2D>(path);
        }

        public static void Exit()
        {
            game.Exit();
        }

        public static bool MousePressed { get; private set; }
        private static MouseState previousState;
        public static void UpdateMouse()
        {
            var currentState = Mouse.GetState();

            if(currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed)
            {
                MousePressed = true;
            }
            else
            {
                MousePressed = false;
            }
            previousState = currentState;
        }
    }
}
