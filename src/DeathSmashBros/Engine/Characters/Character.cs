using DeathSmashBros.Engine.Characters;
using DeathSmashBros.Engine.Scenes;
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
        public Scene scene;

        public int gravity;
        public int power;
        public int speed;
        public double damageTaken = 0.0;
        public int stocksLeft = 3;

        public int width;
        public int height;

        public Rectangle AttackHitbox;
        public DateTime AttackTime;

        protected Dictionary<string, Animation> animations;
        protected Vector2 scale;
        protected Vector2 renderOffset;
        private string currentAnimation = "idle";
        private bool looksRight = true;

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

        public int getStocks()
		{
            return stocksLeft;
		}

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            var offset = new Vector2();
            // calculating new render pos with offset
            var tex = this.animations.First().Value.frames.First();
            offset.X = ((scale.X / tex.Width) * renderOffset.X);
            offset.Y = ((scale.Y / tex.Height) * renderOffset.Y);

            this.Hitbox.Width = (int)(this.scale.X - (offset.X * 2));
            this.Hitbox.Height = (int)(this.scale.Y - (offset.Y * 2));

            this.animations[currentAnimation].Draw(spriteBatch, new Vector2(Hitbox.X, Hitbox.Y) - offset, this.scale, this.looksRight);
        }

        public virtual void Update(GameTime gameTime, Scene scene)
        {
            if(DateTime.Now.Subtract(this.AttackTime).TotalMilliseconds > 500)
            {
                this.AttackHitbox = new Rectangle(0, 0, 0, 0); // tijd sinds attack is meer dan 500ms dus hitbox is zero
            }

            this.animations[currentAnimation].Update(gameTime);

            this.scene = scene;

            if(this.animations[currentAnimation].AnimationEnded)
            {
                this.animations[currentAnimation].AnimationEnded = false;
                this.currentAnimation = "idle";
            }

            // Make sure the character can stand on the stage of the scene
            if (this.Hitbox.Y < scene.hitboxes.First().Y - this.Hitbox.Height)
            {
                this.Hitbox.Y += gravity;
            }

            //Make sure the character falls of the stage
            if(this.Hitbox.X - 2 < scene.hitboxes.First().X - this.Hitbox.Width || 
                this.Hitbox.X + 2 > scene.hitboxes.First().Width)
            {
                this.Hitbox.Y += gravity;
            }

            if (this.Hitbox.X > 800 || this.Hitbox.X < 0 || this.Hitbox.Y < 0 || this.Hitbox.Y > 480)
            {
                this.stocksLeft -= 1;
            }
        }
        
        // TODO andere hitboxes, attack cooldown
        // virtual base methods voor animations en common actions
        public virtual void regularAttack()
        {
            this.currentAnimation = "attack";
            this.AttackTime = DateTime.Now;
            // hitbox spawnen naast character
            if(this.looksRight)
            {
                // hitbox rechts
                this.AttackHitbox = new Rectangle(this.Hitbox.X + this.Hitbox.Width, this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
            else
            {
                // hitbox links
                this.AttackHitbox = new Rectangle(this.Hitbox.X - (this.Hitbox.Width / 2), this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
        }

        public virtual void specialAttack()
        {
            this.currentAnimation = "specialattack";
            this.AttackTime = DateTime.Now;
            // hitbox spawnen naast character
            if (this.looksRight)
            {
                // hitbox rechts
                this.AttackHitbox = new Rectangle(this.Hitbox.X + this.Hitbox.Width, this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
            else
            {
                // hitbox links
                this.AttackHitbox = new Rectangle(this.Hitbox.X - (this.Hitbox.Width / 2), this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
        }

        public virtual void jumpAttack()
        {
            this.currentAnimation = "jumpattack";
            this.AttackTime = DateTime.Now;
            // hitbox spawnen naast character
            if (this.looksRight)
            {
                // hitbox rechts
                this.AttackHitbox = new Rectangle(this.Hitbox.X + this.Hitbox.Width, this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
            else
            {
                // hitbox links
                this.AttackHitbox = new Rectangle(this.Hitbox.X - (this.Hitbox.Width / 2), this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
        }

        public virtual void jump()
        {
            this.currentAnimation = "jump";
            this.Hitbox.Y -= this.speed * 4;
        }

        public virtual void walkLeft()
        {
            if (this.Hitbox.X > scene.hitboxes.First().X - this.Hitbox.Width)
            {
                this.currentAnimation = "walkright";
                this.Hitbox.X -= this.speed;
                this.looksRight = false;
            }
            else
            {
                this.currentAnimation = "walkright";
                this.looksRight = false;
            }
        }

        public virtual void walkRight()
        {
            if(this.Hitbox.X < scene.hitboxes.First().X - this.Hitbox.Width)
            {
                this.currentAnimation = "walkright";
                looksRight = true;
            }
            else
            {
                this.currentAnimation = "walkright";
                this.Hitbox.X += this.speed;
                looksRight = true;
            }
        }

    }
}