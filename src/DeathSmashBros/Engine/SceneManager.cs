﻿using DeathSmashBros.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine
{
    public class SceneManager
    {
        private List<Scene> scenes;

        //Make list of scenes
        public SceneManager()
        {
            this.scenes = new List<Scene>();
        }

        //Adds scenes to list
        public void RegisterScene(Scene scene)
        {
            this.scenes.Add(scene);
        }

        //Gets the scene
        public Scene GetScene(string name)
        {
            return this.scenes.First(x => x.Name == name);
        }
    }
}
