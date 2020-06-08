using DeathSmashBros.Engine.Drawables;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public abstract class Screen
    {
        public string name;
        protected Image background;
        protected List<Drawable> drawables; 

        public Screen()
        {
            drawables = new List<Drawable>();
        }

        public abstract void loadContent();

        public void unloadContent()
        {
            drawables.Clear();
        }

        public virtual void update()
        {
            foreach(Drawable drawable in drawables)
            {
                drawable.update();
            }
        }

        public virtual void draw(SpriteBatch spritebatch)
        {
            foreach(Drawable drawable in drawables)
            {
                drawable.draw(spritebatch);
            }
        }
    }
}
