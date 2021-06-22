using Microsoft.Xna.Framework;
using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.engine
{
    public class GameObject : ClassBase
    {
        public Vector2 v_position;

        public string v_tag = "Default";
        protected bool v_activated;

        public void Tick()
        {
            if (v_activated)
            {
                OnTick();
            }
        }

        public void Draw()
        {
            if (v_activated)
            {
                OnDraw();
            }
        }

        protected override void OnDispose()
        {
            base.OnDispose();
        }

        protected virtual void OnTick() { }
        protected virtual void OnDraw() { }
    }
}
