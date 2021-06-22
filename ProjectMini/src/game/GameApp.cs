using Microsoft.Xna.Framework;
using ProjectMini.src.assets;
using ProjectMini.src.engine;
using ProjectMini.src.entitys;
using ProjectMini.src.world;
using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.game
{
    public class GameApp : ClassBase
    {
        public static GameApp instance { get; private set; }

        public static AssetsManager v_assetsManager;
        public static WorldManager v_worldManager;
        public static EntityManager v_entityManager;
        public static GameUpdateManager v_gameUpdateManager;

        private bool v_playing = false;

        private World v_currentWorld;

        public GameApp()
        {
            instance = null;

            v_assetsManager = new AssetsManager();
            v_worldManager = new WorldManager();
            v_entityManager = new EntityManager();
            v_gameUpdateManager = new GameUpdateManager();
        }

        protected override void OnDispose()
        {
            v_gameUpdateManager.Dispose();
            v_gameUpdateManager = null;

            v_worldManager.Dispose();
            v_worldManager = null;

            v_entityManager.Dispose();
            v_entityManager = null;

            v_assetsManager.Dispose();
            v_assetsManager = null;

            instance = null;
            base.OnDispose();
        }

        public void Load()
        {
            v_assetsManager.LoadContent();

            v_playing = false;
        }

        public void Tick(GameTime gameTime)
        {
            v_gameUpdateManager?.Tick();
            v_worldManager?.Tick();

            if (v_playing)
            {
                if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                {
                    Disconnect();
                }
            }
            else
            {
                if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
                {
                    Play();
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            v_worldManager?.Draw();
            v_gameUpdateManager?.Draw();
        }

        public void DrawGUI()
        {
            DrawMainMenu();
        }

        private void DrawMainMenu()
        {
            
        }

        public void Play()
        {
            v_playing = true;
            v_currentWorld = World.CreateWorld(new GreenWorld());
        }

        public void Disconnect()
        {
            v_playing = false;
            World.DestroyWorld(v_currentWorld);
            v_currentWorld = null;
        }

        public static Vector2 GetWorldPosition()
        {
            if (EntityPlayer.v_player != null)
            {
                return new Vector2(EntityPlayer.v_playerPosition.X , EntityPlayer.v_playerPosition.Y );
            }
            else
            {
                return new Vector2(Application.instance.Window.ClientBounds.Width / 2, Application.instance.Window.ClientBounds.Height / 2);
            }
        }
    }
}
