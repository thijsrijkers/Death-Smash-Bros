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
