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
    class Rabfist : Character
    {
        public Rabfist() : base()
        {
            //Character info
            this.gravity = 2;
            this.power = 1;
            this.speed = 5;
            this.jumpCount = 1;
            this.jumpMax = 1;
            this.scale = new Vector2(240, 240);
            this.renderOffset = new Vector2(400, 430);

            //Annimations added
            this.animations.Add("idle", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Rabfist/idle/idle", 4));
            this.animations.Add("attack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Rabfist/regularattack/regularattack", 4));
            this.animations.Add("specialattack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Rabfist/specialattack/specialattack", 8));
            this.animations.Add("jumpattack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Rabfist/jumpattack/jumpattack", 8));
            this.animations.Add("jump", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Rabfist/jump/jump", 6));
            this.animations.Add("walkleft", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Rabfist/sprintleft/sprintleft", 3));
            this.animations.Add("walkright", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Rabfist/sprintright/sprintright", 3));
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
    }
}