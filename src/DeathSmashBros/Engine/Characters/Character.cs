using DeathSmashBros.Engine.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public abstract class Character
    {
        // TODO positions

        public Rectangle Hitbox;

        public int gravity;
        public int power;
        public int speed;
        public double damageTaken = 0.0;
        public int stocksLef = 3;

        public int width;
        public int height;

        protected Dictionary<string, Animation> animations;
        protected Vector2 scale;
        protected Vector2 renderOffset;
        private string currentAnimation = "idle";

        public Character()
        {
            this.animations = new Dictionary<string, Animation>(); // Lijst voor animaties

            // In de aparte (inherited) constructors moeten nog animations ingeladen worden.
            // IDs voor animations:

            // idle
            // attack
            // specialattack
            // jumpattack
            // jump
            // walkleft
            // walkright
        }

        public Vector2 getPosition
        {
            get
            {
                return new Vector2(Hitbox.X, Hitbox.Y);
            }
        }

        public void setPosition(Vector2 pos)
        {
            this.Hitbox.X = (int)pos.X;
            this.Hitbox.Y = (int)pos.Y;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            var offset = new Vector2();
            // calculating new render pos with offset
            var tex = this.animations.First().Value.frames.First();
            offset.X = ((scale.X / tex.Width) * renderOffset.X);
            offset.Y = ((scale.Y / tex.Height) * renderOffset.Y);

            this.animations[currentAnimation].Draw(spriteBatch, new Vector2(Hitbox.X, Hitbox.Y) - offset, this.scale);
        }

        public virtual void Update(GameTime gameTime)
        {
            this.animations[currentAnimation].Update(gameTime);

            if(this.animations[currentAnimation].AnimationEnded)
            {
                this.animations[currentAnimation].AnimationEnded = false;
                this.currentAnimation = "idle";
            }
        }

        // virtual base methods voor animations en common actions
        public virtual void regularAttack()
        {
            this.currentAnimation = "attack";
        }

        public virtual void specialAttack()
        {
            this.currentAnimation = "special";
        }

        public virtual void jumpAttack()
        {
            this.currentAnimation = "jumpattack";
        }

        public virtual void jump()
        {
            this.currentAnimation = "jump";
        }

        public virtual void walkLeft()
        {
            this.currentAnimation = "walkleft";
        }

        public virtual void walkRight()
        {
            this.currentAnimation = "walkright";
        }

    }
}