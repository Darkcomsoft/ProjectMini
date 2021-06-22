using Microsoft.Xna.Framework;
using ProjectMini.src.assets;
using ProjectMini.src.engine;
using ProjectMini.src.game;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.terrain
{
    public class Chunk : GameObject
    {
        public const int v_chunkSize = 10;

        public TileVoxel[,] v_voxelArray { get; private set; }

        public Chunk(Vector2 position)
        {
            v_position = position;
            v_activated = true;

            v_voxelArray = new TileVoxel[v_chunkSize, v_chunkSize];

            PopulateVoxelData();
        }

        protected override void OnDraw()
        {
            for (int x = 0; x < v_chunkSize; x++)
            {
                for (int y = 0; y < v_chunkSize; y++)
                {
                    if (v_voxelArray[x, y].v_tileID == 0)
                    {
                        Application.Draw(AssetsManager.v_spritesAtlas01, new Vector2((v_voxelArray[x, y].x + 1), (v_voxelArray[x, y].y +1)), new Rectangle(0,48,16,16), new Color(95, 211, 86, 255), 0, Vector2.Zero, new Vector2(-0.064f, -0.064f), Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
                    }
                    else
                    {
                        Application.Draw(AssetsManager.v_spritesAtlas01, new Vector2((v_voxelArray[x, y].x +1 ), (v_voxelArray[x, y].y +1 )), new Rectangle(0, 48, 16, 16), Color.Red, 0, Vector2.Zero, new Vector2(-0.064f, -0.064f), Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
                    }
                }
            }
            base.OnDraw();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
        }

        public void PopulateVoxelData()
        {
            System.Random rand = new Random(Application.instance.GetHashCode() + DateTime.Now.GetHashCode());

            for (int x = 0; x < v_chunkSize; x++)
            {
                for (int y = 0; y < v_chunkSize; y++)
                {
                    v_voxelArray[x, y].x = x + (int)v_position.X;
                    v_voxelArray[x, y].y = y + (int)v_position.Y;

                    v_voxelArray[x, y].v_tileID = (byte)rand.Next(0,3);
                }
            }
        }
    }
}
