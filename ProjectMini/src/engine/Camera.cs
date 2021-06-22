using Microsoft.Xna.Framework;
using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.engine
{
    public class Camera : ClassBase
    {
        public static Camera main { get; private set; }

        public const float v_near = 1f;
        public const float v_far = 100f;

        public Vector2 v_position;

        private float v_aspectRatio;
        private float v_fov = 60;

        public Matrix v_view { get; private set; }
        public Matrix v_projection { get; private set; }

        public Camera()
        {
            if (main != null)
            {
                this.Dispose();
                throw new Exception("All ready exist a Camera!");
            }

            main = this;
            v_position = Vector2.Zero;
        }

        public void UpdateMatrix(Vector2 position)
        {
            v_position = position;

            v_aspectRatio = (float)Application.instance.GraphicsDevice.Viewport.Width / (float)Application.instance.GraphicsDevice.Viewport.Height;
            v_view = Matrix.CreateLookAt(new Vector3(0,0, 10), Vector3.Forward, -Vector3.Up);
            v_projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(v_fov), v_aspectRatio, v_near, v_far);
        }

        protected override void OnDispose()
        {
            if (main == this)
            {
                main = null;
            }
            base.OnDispose();
        }
    }
}
