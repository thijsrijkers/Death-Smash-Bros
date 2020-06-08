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

        public static Rectangle Hitbox;

        public int gravity;
        public int power;
        public int speed;
        public double damageTaken = 0.0;
        public int stocksLef = 3;

        public int width;
        public int height;

        private Dictionary<string, Animation> animations;
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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.animations[currentAnimation].Draw(spriteBatch, new Vector2(0, 0), new Vector2(750, 750));
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

        // virtual base methods voor animations
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