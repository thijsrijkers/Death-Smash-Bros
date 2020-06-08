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
        protected ScreenManager screenManager;
        protected List<Drawable> drawables; 

        public Screen(ScreenManager _screenManager)
        {
            drawables = new List<Drawable>();
            screenManager = _screenManager;
        }

        public abstract void loadContent();

        public void unloadContent()
        {
            drawables.Clear();
        }

        public virtual void update()
        {
            for(int i = 0; i < drawables.Count; i++)
            {
                drawables[i].update();
            }
        }

        public virtual void draw(SpriteBatch spritebatch)
        {
            for(int i = 0; i < drawables.Count; i++)
            {
                drawables[i].draw(spritebatch);
            }
        }
    }
}
