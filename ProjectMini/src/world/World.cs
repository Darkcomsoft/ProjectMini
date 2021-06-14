using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.world
{
    public class World : ClassBase
    {
        public World()
        {

        }

        protected override void OnDispose()
        {
            base.OnDispose();
        }

        public static World CreateWorld(World world)
        {
            return WorldManager.CreateWorld(world);
        }

        public static void DestroyWorld(World world)
        {
            WorldManager.DestroyWorld(world);
        }
    }
}
