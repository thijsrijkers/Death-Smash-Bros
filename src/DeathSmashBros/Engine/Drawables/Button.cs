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
        private bool enlarged = false;
        public event EventHandler click;
        public string name { get; }

        public Button(string _name, Texture2D _texture, Vector2 _position, Vector2 _scale, Texture2D _hoverTexture) : base(_texture, _position, _scale)
        {
            hoverTexture = _hoverTexture;
            name = _name;
        }

        public Button(string _name, Texture2D _texture, Vector2 _position, Vector2 _scale) : base(_texture, _position, _scale) 
        {
            name = _name;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shownTexture, getRectangle(), Color.White);
        }

        public override void update()
        {
            
            if (mouseIntersects())
            {
                hover();

                if(clicked())
                {
                    click?.Invoke(this, new EventArgs());
                }
            }
            else
            {
                noHover();
            }         
        }

        private void hover()
        {
            if(hoverTexture != null)
            {
                shownTexture = hoverTexture;               
            }
            else
            {
                if (!enlarged)
                {
                    scale.X += 10;
                    scale.Y += 10;
                    enlarged = true;
                }
            }
        }

        private void noHover()
        {
            if(hoverTexture != null)
            {
                shownTexture = mainTexture;
            }
            else
            {
                if (enlarged)
                {
                    scale.X -= 10;
                    scale.Y -= 10;
                    enlarged = false;
                }
            }
        }
    }
}
