using DeathSmashBros.Engine.Drawables;
using Microsoft.Xna.Framework;
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
        protected ScreenData screenData;

        public Screen(ScreenManager _screenManager)
        {
            drawables = new List<Drawable>();
            screenManager = _screenManager;
        }

        public virtual void LoadContent(ScreenData data)
        {
            this.screenData = data;
        }

        //changed screendata before you go to next screen
        public ScreenData UnloadContent()
        {
            drawables.Clear();
            return this.screenData;
        }

        public virtual void Update(GameTime gameTime)
        {
            for(int i = 0; i < drawables.Count; i++)
            {
                drawables[i].update();
            }
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            for(int i = 0; i < drawables.Count; i++)
            {
                drawables[i].draw(spritebatch);
            }
        }
    }
}
