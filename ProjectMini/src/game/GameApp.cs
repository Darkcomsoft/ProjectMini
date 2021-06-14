using Microsoft.Xna.Framework;
using ProjectMini.src.assets;
using ProjectMini.src.world;
using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.game
{
    public class GameApp : ClassBase
    {
        public static AssetsManager v_assetsManager;
        public static WorldManager v_worldManager;

        public GameApp()
        {
            v_assetsManager = new AssetsManager();
            v_worldManager = new WorldManager();
        }

        protected override void OnDispose()
        {
            v_worldManager.Dispose();
            v_worldManager = null;

            v_assetsManager.Dispose();
            v_assetsManager = null;
            base.OnDispose();
        }

        public void Load()
        {
            v_assetsManager.LoadContent();
        }

        public void Tick(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
