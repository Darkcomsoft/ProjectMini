using Microsoft.Xna.Framework;
using ProjectMini.src.entitys;
using ProjectMini.src.terrain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.world
{
    public class GreenWorld : World
    {
        public static GreenWorld instance;
        private Dictionary<Vector2, Chunk> v_chunkDictionary = new Dictionary<Vector2, Chunk>();
        private List<Chunk> v_chunkList = new List<Chunk>();

        private EntityPlayer v_playerentity;

        private int RenderDistance = 20;

        public GreenWorld()
        {
            instance = this;
            print("Hello from GreenWorld!");

            v_playerentity = (EntityPlayer)Entity.SpawnEntity(new EntityPlayer());
        }

        Vector2 PlayerP;
        int minX;
        int maxX;
        int minY;
        int maxY;

        protected override void OnTick()
        {
            PlayerP = new Vector2((int)(MathF.Round(EntityPlayer.v_playerPosition.X / Chunk.v_chunkSize) * Chunk.v_chunkSize), (int)(MathF.Round(EntityPlayer.v_playerPosition.Y / Chunk.v_chunkSize) * Chunk.v_chunkSize));
            minX = (int)PlayerP.X - RenderDistance;
            maxX = (int)PlayerP.X + RenderDistance;

            minY = (int)PlayerP.Y - RenderDistance;
            maxY = (int)PlayerP.Y + RenderDistance;

            foreach (var item in v_chunkDictionary)
            {
                if (item.Value.v_position.X > maxX || item.Value.v_position.X < minX || item.Value.v_position.Y > maxY || item.Value.v_position.Y < minY)
                {
                    if (v_chunkDictionary.ContainsKey(item.Value.v_position))
                    {
                        Chunk chunk = v_chunkDictionary[item.Value.v_position];

                        v_chunkList.Remove(chunk);
                        v_chunkDictionary.Remove(item.Value.v_position);

                        chunk.Dispose();
                    }
                }
            }

            for (int x = minX; x < maxX; x += Chunk.v_chunkSize)
            {
                for (int y = minY; y < maxY; y += Chunk.v_chunkSize)
                {
                    Vector2 pos = new Vector2(x, y);

                    if (!v_chunkDictionary.ContainsKey(pos))
                    {
                        Chunk chunk = new Chunk(pos);
                        v_chunkDictionary.Add(pos, chunk);
                        v_chunkList.Add(chunk);
                    }
                }
            }
            base.OnTick();
        }

        protected override void OnDraw()
        {
            for (int i = 0; i < v_chunkList.Count; i++)
            {
                v_chunkList[i].Draw();
            }
            base.OnDraw();
        }

        protected override void OnDispose()
        {
            Entity.DestroyEntity(v_playerentity);
            v_playerentity = null;
            base.OnDispose();
        }

        public TileVoxel GetTileAt(int x, int y)
        {
            Chunk chunk = GetChunkAt(x, y);

            if (chunk != null)
            {
                return chunk.v_voxelArray[x - (int)chunk.v_position.X, y - (int)chunk.v_position.Y];
            }
            return TileVoxel.Empty;
        }

        public TileVoxel GetTileAt(Vector2 pos)
        {
            Chunk chunk = GetChunkAt((int)pos.X, (int)pos.Y);

            if (chunk != null)
            {
                return chunk.v_voxelArray[(int)pos.X - (int)chunk.v_position.X, (int)pos.Y - (int)chunk.v_position.Y];
            }
            return TileVoxel.Empty;
        }

        public TileVoxel GetTileAt(float x, float y)
        {
            int mx = MathUtils.FloorToInt(x);
            int my = MathUtils.FloorToInt(y);

            Chunk chunk = GetChunkAt(mx, my);

            if (chunk != null)
            {
                return chunk.v_voxelArray[mx - (int)chunk.v_position.X, my - (int)chunk.v_position.Y];
            }
            return TileVoxel.Empty;
        }

        public Chunk GetChunkAt(int xx, int yy)
        {
            Vector2 chunkpos = new Vector2(MathUtils.FloorToInt(xx / (float)Chunk.v_chunkSize) * Chunk.v_chunkSize, MathUtils.FloorToInt(yy / (float)Chunk.v_chunkSize) * Chunk.v_chunkSize);
            
            if (v_chunkDictionary.ContainsKey(chunkpos))
            {
                return v_chunkDictionary[chunkpos];
            }
            else
            {
                return null;
            }
        }
    }
}
