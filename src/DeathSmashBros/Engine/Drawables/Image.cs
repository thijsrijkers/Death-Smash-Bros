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
        public Image(int x, int y, Texture2D texture) : base(x, y, texture)
        {
        }
    }
}
