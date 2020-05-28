using Microsoft.Xna.Framework.Graphics;
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
        public Button(int x, int y, Texture2D texture, Texture2D hoverTexture) : base(x, y, texture)
        {
        }

        // TODO override draw method to take hover texture into consideration
    }
}
