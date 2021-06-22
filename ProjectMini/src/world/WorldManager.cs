using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.world
{
    public class WorldManager : ClassBase
    {
        public static WorldManager instance { get; private set; }

        private List<World> v_worldList;

        public WorldManager()
        {
            instance = this;
            v_worldList = new List<World>();
        }

        protected override void OnDispose()
        {
            foreach (var item in v_worldList)
            {
                DestroyWorld(item);
            }

            v_worldList.Clear();
            v_worldList = null;
            instance = null;
            base.OnDispose();
        }

        public void Tick()
        {
            for (int i = 0; i < v_worldList.Count; i++)
            {
                v_worldList[i].Tick();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < v_worldList.Count; i++)
            {
                v_worldList[i].Draw();
            }
        }

        public static World CreateWorld(World world)
        {
            if (!instance.v_worldList.Contains(world))
            {
                instance.v_worldList.Add(world);
            }
            return world;
        }

        public static void DestroyWorld(World world)
        {
            if (instance.v_worldList.Contains(world))
            {
                instance.v_worldList.Remove(world);
            }

            world.Dispose();
        }

        public static void DestroyAllWorlds()
        {
            foreach (var item in instance.v_worldList)
            {
                DestroyWorld(item);
            }
        }
    }
}
