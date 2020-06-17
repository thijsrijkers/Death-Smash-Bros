using DeathSmashBros.Engine.Characters;
using DeathSmashBros.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeathSmashBros.Engine
{
    public abstract class Character
    {
        public Rectangle Hitbox;
        public Scene scene;

        public int gravity;
        public int power;
        public int speed;
        public int jumpCount;
        public int jumpMax;
        public Boolean inAir;
        public double damageTaken = 0.0;
        public int stocksLeft = 3;

        public int width;
        public int height;

        public bool dead = false;

        double timer = 1;
        const double TIMER = 1;

        public Rectangle AttackHitbox;
        public DateTime AttackTime;

        protected Dictionary<string, Animation> animations;
        protected Vector2 scale;
        protected Vector2 renderOffset;
        private string currentAnimation = "idle";
        private bool looksRight = true;

        public Character()
        {
            this.animations = new Dictionary<string, Animation>(); 
        }

        public Vector2 getPosition
        {
            get
            {
                return new Vector2(Hitbox.X, Hitbox.Y);
            }
        }

        //Position is set
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
                this.AttackHitbox = new Rectangle(0, 0, 0, 0); //Time is more than 500ms so hitbox is zero
            }

            if(dead == true)
            {
                this.currentAnimation = "blast";
            }

            this.animations[currentAnimation].Update(gameTime);

            this.scene = scene;

            if(this.animations[currentAnimation].AnimationEnded)
            {
                this.animations[currentAnimation].AnimationEnded = false;
                if(dead == false)
                {
                    this.currentAnimation = "idle";
                }
            }

            // Make sure the character can stand on the stage of the scene
            if (this.Hitbox.Y < scene.hitboxes.First().Y - this.Hitbox.Height)
            {
                if (dead == false)
                {
                    this.Hitbox.Y += gravity;
                }
            }

            //Make sure the character falls of the stage
            if(this.Hitbox.X - 2 < scene.hitboxes.First().X - this.Hitbox.Width || 
                this.Hitbox.X + 2 > scene.hitboxes.First().Width)
            {
                if(dead == false)
                {
                    this.Hitbox.Y += gravity;
                }
            }

            if (this.dead == true)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                timer -= elapsed;
            }

            //Player dies if he is out of the map
            if (this.Hitbox.X > 750 || this.Hitbox.X < 0 || this.Hitbox.Y < 0 || this.Hitbox.Y > 480)
            {
                if(dead == false)
                {
                    this.dead = true;
                    blast();
                }

                if (timer < 0.0)
                {
                    this.dead = false;
                    this.currentAnimation = "idle";
                    this.stocksLeft -= 1;
                    this.Hitbox.X = 300;
                    this.Hitbox.Y = 80;
                    this.damageTaken = 0;
                    timer = TIMER;   //Reset Timer

                }
            }
        }
        
        // virtual base methods for animations and common actions
        public virtual void regularAttack()
        {
            this.currentAnimation = "attack";
            this.AttackTime = DateTime.Now;
            // hitbox spawn near character
            if(this.looksRight)
            {
                // hitbox right
                this.AttackHitbox = new Rectangle(this.Hitbox.X + this.Hitbox.Width, this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
            else
            {
                // hitbox left
                this.AttackHitbox = new Rectangle(this.Hitbox.X - (this.Hitbox.Width / 2), this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
        }

        public virtual void specialAttack()
        {
            this.currentAnimation = "specialattack";
            this.AttackTime = DateTime.Now;
            // hitbox spawn near character
            if (this.looksRight)
            {
                // hitbox right
                this.AttackHitbox = new Rectangle(this.Hitbox.X + this.Hitbox.Width, this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
            else
            {
                // hitbox left
                this.AttackHitbox = new Rectangle(this.Hitbox.X - (this.Hitbox.Width / 2), this.Hitbox.Y + this.Hitbox.Height / 2,
                    this.Hitbox.Width / 2, this.Hitbox.Height / 2);
            }
        }

        public virtual void jumpAttack()
        {
                this.currentAnimation = "jumpattack";
                this.AttackTime = DateTime.Now;
                // hitbox spawn near character
                if (this.looksRight)
                {
                    // hitbox right
                    this.AttackHitbox = new Rectangle(this.Hitbox.X + this.Hitbox.Width, this.Hitbox.Y + this.Hitbox.Height / 2,
                        this.Hitbox.Width / 2, this.Hitbox.Height / 2);
                }
                else
                {
                    // hitbox left
                    this.AttackHitbox = new Rectangle(this.Hitbox.X - (this.Hitbox.Width / 2), this.Hitbox.Y + this.Hitbox.Height / 2,
                        this.Hitbox.Width / 2, this.Hitbox.Height / 2);
                }
        }

        //Character jump calculated by speed
        public virtual void jump()
        {
            this.currentAnimation = "jump";
            this.Hitbox.Y -= this.speed * 40;
        }

        //Character can walk left
        public virtual void walkLeft()
        {
            if (this.Hitbox.X < 800)
            {
                if(this.Hitbox.X > scene.hitboxes.First().X - this.Hitbox.Width && this.Hitbox.X > 300 && this.Hitbox.Y > 280)
                {
                    this.currentAnimation = "walkright";
                    this.looksRight = false;
                }
                else
                {
                    this.currentAnimation = "walkright";
                    this.Hitbox.X -= this.speed;
                    this.looksRight = false;
                }
            }
            else
            {
                this.currentAnimation = "walkright";
                this.looksRight = false;
            }
        }

        //Character can walk right
        public virtual void walkRight()
        {
            if(this.Hitbox.X < 800)
            {
                if(this.Hitbox.X > scene.hitboxes.First().X - this.Hitbox.Width && this.Hitbox.X < 300 && this.Hitbox.Y > 280)
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
            else
            {
                this.currentAnimation = "walkright";
                looksRight = true;
            }
        }

        public virtual void blast()
        {
            if (this.Hitbox.X < 0)
            {
                //left
                this.looksRight = true;
            }
            else if (this.Hitbox.X > 750)
            {
                //left
                this.looksRight = false;
            }
        }

    }
}