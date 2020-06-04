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
        TimeSpan _duration;
        private int _currentframe;
        List<Texture2D> _textures;
        public int gravity = 3;
        public int power = 1;
        public int speed = 5;
        public double damageTaken = 0.0;
        public int stocksLef = 3;
        public static Rectangle Hitbox;

        public int width { get; private set; }
        public int height { get; private set; }

        public void update(GameTime gametime)
        {
            if (this._textures.Count > 1)
            {
                var timer = gametime.TotalGameTime.TotalMilliseconds % _duration.TotalMilliseconds;
                var progress = (100 / _duration.TotalMilliseconds) * timer;
                this._currentframe = (int)Math.Abs((_textures.Count * progress) / 100);
            }
        }

        public void addTexture(Texture2D texture)
        {
            this._textures.Add(texture);
        }

        public void draw(SpriteBatch sb, int x, int y, int width = -1, int height = -1, Color? light = null)
        {
            int rwidth = width == -1 ? this.width : width;
            int rheight = height == -1 ? this.height : height;

            sb.Draw(_textures[_currentframe], new Rectangle(x, y, rwidth, rheight), light ?? Color.White);
        }

        public Vector2 getPosition
        {
            get
            {
                return new Vector2(Hitbox.X, Hitbox.Y);
            }
        }

        public void regularAttack()
        {

        }

        public void specialAttack()
        {

        }

        public void jumpAttack()
        {

        }

        public void jump()
        {

        }

        public void walkLeft()
        {

        }

        public void walkRight()
        {

        }
    }
}