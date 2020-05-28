using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Drawables
{
    public abstract class Drawable
    {
        private Texture2D texture;
        private int x;
        private int y;

        public delegate void OnClickDelegate(Drawable drawable);
        public event OnClickDelegate OnClick;

        public Drawable(int x, int y, Texture2D texture)
        {

        }

        // TODO implement methods
    }
}
