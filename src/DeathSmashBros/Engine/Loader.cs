using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public static class Loader
    {
        private static MainGame _game;

        public static void Init(MainGame game)
        {
            _game = game;
        }

        public static Texture2D getTexture(string path)
        {
            // TODO
            return null;
        }
    }
}
