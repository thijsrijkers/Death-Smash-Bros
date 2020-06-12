using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Scenes
{
    public class CloudStage : Scene
    {
        public CloudStage() : base("cloud")
        {
            this.stage = Loader.getTexture("stages/CloudStageStage");
            this.stageBackground = Loader.getTexture("stages/CloudStageBackround");
            this.hitboxes = new List<Rectangle>();
            // stage hitboxes for physics and collision
            hitboxes.Add(new Rectangle(154, 341, 640, 479));
        }
    }
}
