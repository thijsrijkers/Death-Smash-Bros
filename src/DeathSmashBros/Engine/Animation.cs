﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public class Animation
    {
        private List<Texture2D> frames;
        private TimeSpan animationTime;
        private int currentFrame;
        public bool AnimationEnded = false;

        public Animation(TimeSpan animationTime, params Texture2D[] frames)
        {
            this.animationTime = animationTime;
            this.frames = frames.ToList();
            this.currentFrame = 0;
        }

        public Animation(TimeSpan animationTime, string texturename, int framecount)
        {
            this.animationTime = animationTime;
            this.frames = new List<Texture2D>();
            for (int i = 1; i < framecount; i++)
            {
                this.frames.Add(Loader.getTexture($"{texturename}{i}"));
            }
        }

        public void Update(GameTime gameTime)
        {
            if (this.frames.Count > 0)
            {
                var timer = gameTime.TotalGameTime.TotalMilliseconds % animationTime.TotalMilliseconds;
                var progress = (100 / animationTime.TotalMilliseconds) * timer;
                this.currentFrame = (int)Math.Abs((frames.Count * progress) / 100);

                if(this.currentFrame == this.frames.Count - 1)
                {
                    AnimationEnded = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 postion, Vector2 size)
        {
            spriteBatch.Draw(frames[currentFrame], new Rectangle(postion.ToPoint(), size.ToPoint()), Color.White);
        }
    }
}
