using Microsoft.Xna.Framework;
using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.entitys
{
    public class Entity : ClassBase
    {
        private Vector2 v_position;

        public Entity()
        {
            v_position = Vector2.Zero;
            OnCreate();
        }

        public void Start()
        {
            OnStart();
        }

        public void Tick()
        {
            OnTick();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
        }

        protected virtual void OnTick() { }
        protected virtual void OnStart() { }
        protected virtual void OnCreate() { }

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