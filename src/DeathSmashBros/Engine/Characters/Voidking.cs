using DeathSmashBros.Engine.Scenes;
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
            //Character info
            this.gravity = 4;
            this.power = 3;
            this.speed = 3;
            this.jumpCount = 2;
            this.jumpMax = 2;
            this.scale = new Vector2(240, 240);
            this.renderOffset = new Vector2(400, 430);

            //Animations added
            this.animations.Add("idle", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/idle/idle", 9));
            this.animations.Add("attack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/regularattack/regularattack", 12));
            this.animations.Add("specialattack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/specialattack/specialattack", 10));
            this.animations.Add("jumpattack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/jumpattack/jumpattack", 10));
            this.animations.Add("jump", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/jump/jump", 8));
            this.animations.Add("walkleft", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/sprintleft/sprintleft", 4));
            this.animations.Add("walkright", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Voidking/sprintright/sprintright", 4));
            this.animations.Add("blast", new Animation(TimeSpan.FromMilliseconds(1000), "blastLeft/blastleft", 4));
        }

        public override void Update(GameTime gametime, Scene scene)
        {
            base.Update(gametime, scene);
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

        public override void blast()
        {
            base.blast();
        }
    }
}
