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
    public class Button : Drawable
    {

        private Texture2D hoverTexture;
        public Button(Texture2D _texture, Vector2 _position, Vector2 _scale, Texture2D _hoverTexture) : base(_texture, _position, _scale)
        {
            hoverTexture = _hoverTexture;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shownTexture, getRectangle(), Color.White);
        }

        public override void update()
        {
            if(mouseIntersects())
            {
                shownTexture = hoverTexture;
            }
            else
            {
                shownTexture = mainTexture;
            }         
        }

        //Checks if the mouse is on the button
        private bool mouseIntersects()
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePoint = new Point(mouseState.X, mouseState.Y);
            
            if (getRectangle().Contains(mousePoint))
            {
                return true;
            }
            return false;
        }

        //TODO: Werken met de onclick event
    }
}
