﻿using DeathSmashBros.Engine.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathSmashBros.Engine.Screens
{
    public class SceneSelectScreen : Screen
    {
        public SceneSelectScreen(ScreenManager _screenManager) : base(_screenManager)
        {
            name = "sceneSelect";
        }

        //Load content on screen
        public override void LoadContent(ScreenData data)
        {
            int bgHeight = GraphicsDeviceManager.DefaultBackBufferHeight;
            int bgWidth = GraphicsDeviceManager.DefaultBackBufferWidth;
            Image background = new Image(Loader.getTexture("backgroundCharacterWorldMenu"), new Vector2(0, 0), new Vector2(bgWidth, bgHeight));
            drawables.Add(background);

            //int minX = 150;
            //int maxX = 600;
            //int minY = 100;
            //int maxY = 400;
            //int x = minX;
            //int y = minY;

            //Draw buttons on screen
            Button stageItem = new Button("cloud", Loader.getTexture("CloudStageButton"), new Vector2(150, 100), new Vector2(200, 100));
            stageItem.click += Stage_click;
            drawables.Add(stageItem);
            Button stageItem2 = new Button("grassland", Loader.getTexture("GrasslandButton"), new Vector2(465, 100), new Vector2(200, 100));
            stageItem2.click += Stage_click;
            drawables.Add(stageItem2);

            Button back = new Button("back", Loader.getTexture("backbutton"), new Vector2(25, 10), new Vector2(100, 75));
            back.click += Back_click;
            drawables.Add(back);

            base.LoadContent(data);
        }

        //Go back to homescreen
        private void Back_click(Button button)
        {
            screenManager.ChangeScreen("home");
        }

        //if you choose a stage, you go to character select
        private void Stage_click(Button button)
        {
            screenData.SelectedStage = button.name;
            screenManager.ChangeScreen("characterSelect");
        }
    }
}
