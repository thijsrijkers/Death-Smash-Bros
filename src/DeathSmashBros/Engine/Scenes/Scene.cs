using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Scenes
{
    public abstract class Scene
    {
        private Texture2D stage;
        private List<Rectangle> hitboxes;

        public Scene(Texture2D stage)
        {
            this.stage = stage;
            this.hitboxes = new List<Rectangle>();
        }
    }
}
