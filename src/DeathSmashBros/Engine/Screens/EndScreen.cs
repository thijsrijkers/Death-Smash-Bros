using DeathSmashBros.Engine.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Screens
{
    public class EndScreen : Screen
    {
        public EndScreen() : base()
        {
            name = "end";
        }

        public override void loadContent()
        {
            //TODO: winnaar en verliezer laten zien op basis van een echte uitslag en dus niet hardcoded sprites

            int bgHeight = GraphicsDeviceManager.DefaultBackBufferHeight;
            int bgWidth = GraphicsDeviceManager.DefaultBackBufferWidth;

            background = new Image(Loader.getTexture("homescreen-background"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));

            Image winnerSprite = new Image(Loader.getTexture("rabfist"), new Vector2(0, 0), new Vector2(400, bgHeight));

            Image winnerFrame = new Image(Loader.getTexture("playerframe-rabfist"), new Vector2(350, 25), new Vector2(450, 300));
            Image loserFrame = new Image(Loader.getTexture("playerframe-enemy-voidking"), new Vector2(350, 150), new Vector2(450, 300));

            drawables.Add(background);
            drawables.Add(winnerSprite);
            drawables.Add(winnerFrame);
            drawables.Add(loserFrame);
        }
    }
}
