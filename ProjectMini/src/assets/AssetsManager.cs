using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ProjectSLN.darkcomsoft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.assets
{
    public class AssetsManager : ClassBase
    {
        public static AssetsManager instance { get; private set; }

        private Dictionary<string, Texture2D> v_textureList;

        public static Texture2D v_spritesAtlas01;

        public AssetsManager()
        {
            instance = this;

            v_textureList = new Dictionary<string, Texture2D>();
        }

        protected override void OnDispose()
        {
            foreach (var item in v_textureList)
            {
                item.Value.Dispose();
            }

            v_textureList = null;
            instance = null;
            base.OnDispose();
        }

        public void LoadContent()
        {
            LoadTexture("SpriteTeste");
            LoadTexture("tiles");

            v_spritesAtlas01 = GetTexture("tiles");
        }
        #region LoadFunctions
        private void LoadTexture(string name)
        {
            if (!v_textureList.ContainsKey(name))
            {
                Texture2D tex = Application.instance.Content.Load<Texture2D>(name);

                if (tex != null)
                {
                    v_textureList.Add(name, tex);
                }
            }
        }
        #endregion

        #region GetFunctions
        public static Texture2D GetTexture(string name)
        {
            if (instance.v_textureList.TryGetValue(name, out Texture2D tex))
            {
                return tex;
            }
            throw new Exception("Don't found this asset: " + name);
        }
        #endregion
    }
}
