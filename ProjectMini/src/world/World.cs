using Microsoft.Xna.Framework;
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

        public void Tick()
        {
            OnTick();
        }

        public void Draw()
        {
            OnDraw();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
        }

        protected virtual void OnTick() { }
        protected virtual void OnDraw() { }

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
