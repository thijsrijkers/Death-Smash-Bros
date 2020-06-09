using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Drawables
{
    public abstract class Drawable
    {
        protected Texture2D mainTexture;
        protected Texture2D shownTexture;
        protected Vector2 position;
        protected Vector2 scale;

        public Drawable(Texture2D _texture, Vector2 _position, Vector2 _scale)
        {
            mainTexture = _texture;
            shownTexture = mainTexture;
            position = _position;
            scale = _scale;
        }

        public abstract void draw(SpriteBatch spriteBatch);

        public abstract void update();

        //Checks if the mouse is on the drawable
        protected bool mouseIntersects()
        {
            Point mousePoint = MainGame.MousePositions;

            if (getRectangle().Contains(mousePoint))
            {
                return true;
            }
            return false;
        }

        //Checks if the drawable was clicked
        protected bool clicked()
        {
            return Loader.MousePressed;
        }

        // Creates a rectangle to wrap the texture in
        public Rectangle getRectangle()
        {
            Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, (int)scale.X, (int)scale.Y);
            return rectangle;
        }
    }
}
