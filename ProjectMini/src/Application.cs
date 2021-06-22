using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMini.src.assets;
using ProjectMini.src.debug;
using ProjectMini.src.engine;
using ProjectMini.src.entitys;
using ProjectMini.src.game;
using System;
using System.Threading;

namespace ProjectMini
{
    public class Application : Game
    {
        public static Application instance { get; private set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameApp v_game;

        public float DeltaTime;
        public float time;

        private BasicEffect v_spriteShader;

        public Application()
        {
            instance = this;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.GraphicsProfile = GraphicsProfile.Reach;

            IsFixedTimeStep = true;

            Window.AllowUserResizing = true;
            Window.Title = "Project-Mini";

            _graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            v_spriteShader = new BasicEffect(GraphicsDevice);
            v_spriteShader.TextureEnabled = true;
            v_spriteShader.FogEnabled = false;
            v_spriteShader.LightingEnabled = false;
            v_spriteShader.VertexColorEnabled = true;
            v_spriteShader.World = Matrix.Identity;
            v_spriteShader.Projection = Matrix.Identity;
            v_spriteShader.View = Matrix.Identity;

            v_game = new GameApp();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            v_game?.Load();

            textureTeste = AssetsManager.GetTexture("tiles");
        }

        protected override void Update(GameTime gameTime)
        {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            time = (float)gameTime.TotalGameTime.TotalSeconds;

            if (backbufferHeight != GraphicsDevice.PresentationParameters.BackBufferHeight || backbufferWidth != GraphicsDevice.PresentationParameters.BackBufferWidth)
            {
                ScalePresentationArea();
            }

            Input.TickStart();
            AppInput();
            v_game?.Tick(gameTime);

            if (Camera.main != null)
            {
                instance.v_spriteShader.Projection = Camera.main.v_projection;
                instance.v_spriteShader.View = Camera.main.v_view;
            }

            Input.TickEnd();
            base.Update(gameTime);
        }

        Texture2D textureTeste;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            v_game.Draw(gameTime);

            _spriteBatch.Begin();
            //
            v_game.DrawGUI();//this call ImGUI draw elements
            //
            _spriteBatch.End();//End with GameRender

            Thread.Sleep(1);
            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            v_game.Dispose();
            base.UnloadContent();
        }

        private void AppInput()
        {
            if (Input.GetKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Input.GetKeyDown(Keys.F11))
            {
                _graphics.ToggleFullScreen();
            }
        }
        Vector2 baseScreenSize = new Vector2(640, 640);
        int backbufferWidth, backbufferHeight;
        Matrix globalTransformation;
        public void ScalePresentationArea()
        {
            //Work out how much we need to scale our graphics to fill the screen
            backbufferWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            backbufferHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
            float horScaling = backbufferWidth / baseScreenSize.X;
            float verScaling = backbufferHeight / baseScreenSize.Y;
            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            globalTransformation = Matrix.CreateScale(screenScalingFactor);
            System.Diagnostics.Debug.WriteLine("Screen Size - Width[" + GraphicsDevice.PresentationParameters.BackBufferWidth + "] Height [" + GraphicsDevice.PresentationParameters.BackBufferHeight + "]");
        }

        public static void Draw(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            instance.v_spriteShader.World = Matrix.CreateTranslation(new Vector3(position, 0) - new Vector3(EntityPlayer.v_playerPosition, 0));
            instance._spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, instance.v_spriteShader, null);
            instance._spriteBatch.Draw(texture, Vector2.Zero, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
            instance._spriteBatch.End();//End with GameRender
        }

        public static void DrawStatic(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            instance.v_spriteShader.World = Matrix.CreateTranslation(new Vector3(position, 0));
            instance._spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, instance.v_spriteShader, null);
            instance._spriteBatch.Draw(texture, Vector2.Zero, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
            instance._spriteBatch.End();//End with GameRender
        }
    }

    public static class MathUtils
    {
        public static int FloorToInt(double value) => (int)Math.Floor(value);
    }
}
