using ProjectMini.src.entitys;
using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.engine
{
    public class GameUpdateManager : ClassBase
    {
        public static GameUpdateManager instance { get; private set; }
        public List<GameObject> v_tickObjectsList;
        public List<GameObject> v_drawObjectsList;

        public GameUpdateManager()
        {
            instance = this;
            v_tickObjectsList = new List<GameObject>();
            v_drawObjectsList = new List<GameObject>();
        }

        public void Tick()
        {
            for (int i = 0; i < v_tickObjectsList.Count; i++)
            {
                v_tickObjectsList[i].Tick();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < v_drawObjectsList.Count; i++)
            {
                v_drawObjectsList[i].Draw();
            }
        }

        protected override void OnDispose()
        {
            v_tickObjectsList.Clear();
            v_drawObjectsList.Clear();

            v_tickObjectsList = null;
            v_drawObjectsList = null;

            instance = null;
            base.OnDispose();
        }

        public static void AddTickObject(GameObject obj)
        {
            instance.v_tickObjectsList.Add(obj);
        }

        public static void AddDrawObject(GameObject obj)
        {
            instance.v_drawObjectsList.Add(obj);
        }

        public static void RemoveTickObject(GameObject obj)
        {
            instance.v_tickObjectsList.Remove(obj);
        }

        public static void RemoveDrawObject(GameObject obj)
        {
            instance.v_drawObjectsList.Remove(obj);
        }
    }
}
