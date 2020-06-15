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
    class Wraith : Character
    {
        public Wraith() : base()
        {
            this.gravity = 1;
            this.power = 5;
            this.speed = 1;

            this.scale = new Vector2(240, 240);
            this.renderOffset = new Vector2(400, 430);

            // TODO animation times evt
            this.animations.Add("idle", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Wraith/idle/idle", 5));
            this.animations.Add("attack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Wraith/regularattack/regularattack", 5));
            this.animations.Add("specialattack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Wraith/specialattack/specialattack", 8));
            this.animations.Add("jumpattack", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Wraith/jumpattack/jumpattack", 6));
            this.animations.Add("jump", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Wraith/jump/jump", 6));
            this.animations.Add("walkleft", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Wraith/sprintleft/sprintleft", 6));
            this.animations.Add("walkright", new Animation(TimeSpan.FromMilliseconds(1300), "characters/Wraith/sprintright/sprintright", 6));
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