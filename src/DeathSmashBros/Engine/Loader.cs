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

        public static SpriteFont getFont(string path)
        {
            return game.Content.Load<SpriteFont>(path);
        }

        //if exit the game exits
        public static void Exit()
        {
            game.Exit();
        }

        //Check mousePressed
        public static bool MousePressed { get; private set; }
        private static MouseState previousState;
        public static void UpdateMouse()
        {
            var currentState = Mouse.GetState();
            //Check if released, so you wont click more than once
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
