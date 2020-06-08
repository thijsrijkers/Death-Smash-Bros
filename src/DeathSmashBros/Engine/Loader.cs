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
        private static MainGame game;

        public static void Init(MainGame _game)
        {
            game = _game;
        }

        public static Texture2D getTexture(string path)
        {
            // Laadt een texture in van de content pipeline.
            // TODO caching
            return _game.Content.Load<Texture2D>(path);
        }
    }
}
