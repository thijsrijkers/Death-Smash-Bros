using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Characters
{
    class Voidking : Character
    {
        public Voidking() : base()
        {
            this.gravity = 5;
            this.power = 3;
            this.speed = 2;
            this.scale = new Vector2(240, 240);
            this.renderOffset = new Vector2(400, 430);

            // inladen animations
            // idle
            // attack
            // specialattack
            // jumpattack
            // jump
            // walkleft
            // walkright

            // TODO de juiste animations
            this.animations.Add("idle", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/idle/idle", 9));
            this.animations.Add("attack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/idle/idle", 9));
            this.animations.Add("specialattack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/idle/idle", 9));
            this.animations.Add("jumpattack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/idle/idle", 9));
            this.animations.Add("jump", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/idle/idle", 9));
            this.animations.Add("walkleft", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/idle/idle", 9));
            this.animations.Add("walkright", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/idle/idle", 9));
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }

        public override void regularAttack()
        {

            base.regularAttack();
        }

        public override void specialAttack()
        {

            base.specialAttack();
        }

        public override void jumpAttack()
        {

            base.jumpAttack();
        }

        public override void jump()
        {

            base.jump();
        }

        public override void walkLeft()
        {

            base.walkLeft();
        }

        public override void walkRight()
        {

            base.walkRight();
        }
    }
}
