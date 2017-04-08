using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hackaton
{
    public class Game1 : Game
    {
        enum GameState { Menu, Load, Game, Pause };
        static GameState State = GameState.Menu;
        static public bool NeedExit = false;
        static public double Dx, Dy;
        StartScreen startScreen;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            startScreen = new StartScreen(spriteBatch, Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            var metric = new Android.Util.DisplayMetrics();
            Activity.WindowManager.DefaultDisplay.GetMetrics(metric);
            Dx = (double)metric.WidthPixels / 960.0;
            Dy = (double)metric.HeightPixels / 540.0;
            switch (State)
            {
                case GameState.Menu:
                    base.Update(gameTime);
                    startScreen.Update();
                    if (NeedExit) Exit();
                    break;
                case GameState.Load:
                    break;
                case GameState.Pause:
                    break;
                case GameState.Game:
                    break;
            }
        }

        static public int NormalizeX(int x)
        {
            return (int)(x * Dx);
        }

        static public int NormalizeY(int x)
        {
            return (int)(x * Dy);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (State)
            {
                case GameState.Menu:
                    startScreen.Draw();
                    break;
                case GameState.Load:
                    break;
                case GameState.Pause:
                    break;
                case GameState.Game:
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
