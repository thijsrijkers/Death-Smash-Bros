using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Drawables
{
    public class Image : Drawable
    {
        public Image(Texture2D _texture, Vector2 _position, Vector2 _scale) : base(_texture, _position, _scale) {}

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shownTexture, getRectangle(), Color.White);
        }

        public override void update()
        {
            shownTexture = mainTexture;
        }
    }
}
