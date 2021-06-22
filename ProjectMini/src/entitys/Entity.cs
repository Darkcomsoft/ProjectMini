using Microsoft.Xna.Framework;
using ProjectMini.src.engine;
using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.entitys
{
    public class Entity : GameObject
    {
        public void Start()
        {
            v_activated = true;
            OnStart();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
        }

        protected virtual void OnStart() { }

        public static Entity SpawnEntity(Entity entity)
        {
            return EntityManager.AddEntity(entity);
        }

        public static void DestroyEntity(Entity entity)
        {
            EntityManager.RemoveEntity(entity);
        }
    }
}