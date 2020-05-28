﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public abstract class Screen
    {
        private string name;
        private Texture2D background;
        private List<object> drawables; // TODO drawable object

        public Screen(string name, Texture2D background)
        {
            this.name = name;
            this.drawables = new List<object>();
            this.background = background;
        }

        // TODO methods
    }
}
