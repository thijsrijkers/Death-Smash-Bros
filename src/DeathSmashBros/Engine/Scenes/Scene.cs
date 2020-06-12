using DeathSmashBros.Engine.Drawables;
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
        public Texture2D stage { get; protected set; }
        public Texture2D stageBackground { get; protected set; }
        public List<Rectangle> hitboxes { get; protected set; }
        public string Name { get; private set; }

        public Scene(string name)
        {
            this.Name = name;
        }
    }
}
