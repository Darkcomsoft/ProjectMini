using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMini.src.assets;
using ProjectMini.src.debug;
using ProjectMini.src.engine;
using ProjectMini.src.game;
using System.Threading;

namespace ProjectMini
{
    public class Application : Game
    {
        public static Application instance { get; private set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameApp v_game;

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
            v_game = new GameApp();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            v_game?.Load();

            textureTeste = AssetsManager.GetTexture("SpriteTeste");
        }

        Vector2 playerpos = Vector2.Zero;

        protected override void Update(GameTime gameTime)
        {
            Input.TickStart();
            AppInput();

            if (Input.GetKey(Keys.W))
            {
                playerpos.Y += 2f;
            }

            if (Input.GetKey(Keys.S))
            {
                playerpos.Y -= 2f;
            }

            if (Input.GetKey(Keys.D))
            {
                playerpos.X -= 2f;
            }

            if (Input.GetKey(Keys.A))
            {
                playerpos.X += 2f;
            }

            v_game?.Tick(gameTime);

            Input.TickEnd();
            base.Update(gameTime);
        }

        Texture2D textureTeste;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,SamplerState.PointClamp);

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    _spriteBatch.Draw(textureTeste, new Vector2((x * 80) + playerpos.X, (y * 80) + playerpos.Y), new Rectangle(0, 0, 16, 16), Color.White, 0, Vector2.Zero, new Vector2(5, 5), SpriteEffects.None, 0);
                }
            }

            v_game.Draw(gameTime);
            _spriteBatch.End();
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

        public static void Draw(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            instance._spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }
    }
}
