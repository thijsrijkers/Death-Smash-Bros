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
            this.gravity = 3;
            this.power = 1;
            this.speed = 5;
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