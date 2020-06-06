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
        public static Rectangle Hitbox;

        public Vector2 getPosition
        {
            get
            {
                return new Vector2(Hitbox.X, Hitbox.Y);
            }
        }
        public abstract void regularAttack();
        public abstract void specialAttack();
        public abstract void jumpAttack();
        public abstract void jump();
        public abstract void walkLeft();
        public abstract void walkRight();

    }
}