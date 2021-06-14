using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.entitys
{
    public class EntityManager : ClassBase
    {
        public static EntityManager instance;
        private List<Entity> v_entityList;

        public EntityManager()
        {
            instance = this;
            v_entityList = new List<Entity>();
        }

        protected override void OnDispose()
        {
            foreach (var item in v_entityList)
            {
                RemoveEntity(item);
            }

            v_entityList.Clear();
            v_entityList = null;
            instance = null;
            base.OnDispose();
        }

        public static Entity AddEntity(Entity entity)
        {
            if (!instance.v_entityList.Contains(entity))
            {
                instance.v_entityList.Add(entity);
            }

            entity.Start();

            return entity;
        }

        public static void RemoveEntity(Entity entity)
        {
            if (instance.v_entityList.Contains(entity))
            {
                instance.v_entityList.Remove(entity);
            }
            entity.Dispose();
        }
    }
}