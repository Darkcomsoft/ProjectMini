using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMini.src.assets;
using ProjectMini.src.engine;
using ProjectMini.src.world;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.entitys
{
    public class EntityPlayer : Entity
    {
        public static EntityPlayer v_player;

        public static Vector2 v_playerPosition;

        private Camera v_camera;

        private float v_speed = 4.5f;

        private byte v_animationFrame = 0;

        private float v_animeSpeed = 0.2f;
        private float v_timestep;

        private AnimeSide v_animside;

        public EntityPlayer()
        {
            v_player = this;
            v_position = new Vector2(0, 0);

            v_camera = new Camera();
        }

        protected override void OnStart()
        {
            GameUpdateManager.AddTickObject(this);
            GameUpdateManager.AddDrawObject(this);
            base.OnStart();
        }

        protected override void OnTick()
        {
            Vector2 movement = Vector2.Zero;

            if (Input.GetKey(Keys.W))
            {
                movement.Y = 1;
                v_animside = AnimeSide.up;
                TickAnimation();
            }

            if (Input.GetKey(Keys.S))
            {
                movement.Y = -1;
                v_animside = AnimeSide.down;
                TickAnimation();
            }

            if (Input.GetKey(Keys.D))
            {
                movement.X = 1;
                v_animside = AnimeSide.right;
                TickAnimation();
            }

            if (Input.GetKey(Keys.A))
            {
                movement.X = -1;
                v_animside = AnimeSide.left;
                TickAnimation();
            }


            Application.instance.Window.Title = "FPS: " + (int)(1/Application.instance.DeltaTime) +" |  - - -TileID: " + GreenWorld.instance.GetTileAt(v_position.X, v_position.Y).v_tileID + "| Pos: " + new Vector2(MathUtils.FloorToInt(v_position.X), MathUtils.FloorToInt(v_position.Y)).ToString();

            v_position.X -= movement.X * v_speed * Application.instance.DeltaTime;
            v_position.Y -= movement.Y * v_speed * Application.instance.DeltaTime;

            v_playerPosition = v_position;
            v_camera?.UpdateMatrix(v_position);
            base.OnTick();
        }
        Vector2 origin = new Vector2();
        protected override void OnDraw()
        {
            origin = new Vector2(8,14);

            switch (v_animside)
            {
                case AnimeSide.up:
                    if (v_animationFrame == 1)
                    {
                        Application.DrawStatic(AssetsManager.v_spritesAtlas01, new Vector2(0, 0), new Rectangle(0, 16, 16, 16), Color.White, 0, origin, new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 0);
                    }
                    else if (v_animationFrame == 2)
                    {
                        Application.DrawStatic(AssetsManager.v_spritesAtlas01, new Vector2(0, 0), new Rectangle(0, 16, 16, 16), Color.White, 0, origin, new Vector2(0.1f, 0.1f), SpriteEffects.None, 0);
                    }
                    break;
                case AnimeSide.down:
                    if (v_animationFrame == 1)
                    {
                        Application.DrawStatic(AssetsManager.v_spritesAtlas01, new Vector2(0, 0), new Rectangle(0, 0, 16, 16), Color.White, 0, origin, new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 0);
                    }
                    else if (v_animationFrame == 2)
                    {
                        Application.DrawStatic(AssetsManager.v_spritesAtlas01, new Vector2(0, 0), new Rectangle(0, 0, 16, 16), Color.White, 0, origin, new Vector2(0.1f, 0.1f), SpriteEffects.None, 0);
                    }
                    break;
                case AnimeSide.left:
                    if (v_animationFrame == 1)
                    {
                        Application.DrawStatic(AssetsManager.v_spritesAtlas01, new Vector2(0, 0), new Rectangle(16, 32, 16, 16), Color.White, 0, origin, new Vector2(0.1f, 0.1f), SpriteEffects.None, 0);
                    }
                    else if (v_animationFrame == 2)
                    {
                        Application.DrawStatic(AssetsManager.v_spritesAtlas01, new Vector2(0, 0), new Rectangle(0, 32, 16, 16), Color.White, 0, origin, new Vector2(0.1f, 0.1f), SpriteEffects.None, 0);
                    }
                    break;
                case AnimeSide.right:
                    if (v_animationFrame == 1)
                    {
                        Application.DrawStatic(AssetsManager.v_spritesAtlas01, new Vector2(0, 0), new Rectangle(16, 32, 16, 16), Color.White, 0, origin, new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 0);
                    }
                    else if (v_animationFrame == 2)
                    {
                        Application.DrawStatic(AssetsManager.v_spritesAtlas01, new Vector2(0, 0), new Rectangle(0, 32, 16, 16), Color.White, 0, origin, new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 0);
                    }
                    break;
            }
            base.OnDraw();
        }

        protected override void OnDispose()
        {
            v_camera?.Dispose();
            v_camera = null;

            GameUpdateManager.RemoveTickObject(this);
            GameUpdateManager.RemoveDrawObject(this);
            v_player = null;
            base.OnDispose();
        }

        private void TickAnimation()
        {
            if (Application.instance.time > v_animeSpeed + v_timestep)
            {
                if (v_animationFrame >= 2)
                {
                    v_animationFrame = 1;
                }
                else
                {
                    v_animationFrame++;
                }
                v_timestep = Application.instance.time;
            }
        }
    }

    public enum AnimeSide : byte
    {
        up, down, left, right
    }
}
