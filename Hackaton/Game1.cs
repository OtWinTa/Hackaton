using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hackaton {
    public class Game1 : Game {
        public enum GameState { Menu, Load, Game, Pause };
        static public GameState State = GameState.Menu;
        static public bool NeedExit = false;
        static public double Dx, Dy;
        StartScreen startScreen;
        GameScreen gameScreen;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        protected override void Initialize() {
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            startScreen = new StartScreen(spriteBatch, Content);
            gameScreen = new GameScreen(spriteBatch, Content);
            Enemy1.SetTexture(spriteBatch, Content, "Enemy1", "Enemy1");
        }

        protected override void UnloadContent() {
        }

        protected override void Update(GameTime gameTime) {
            var metric = new Android.Util.DisplayMetrics();
            Activity.WindowManager.DefaultDisplay.GetMetrics(metric);
            Dx = (double)metric.WidthPixels / 960.0;
            Dy = (double)metric.HeightPixels / 540.0;
            base.Update(gameTime);
            switch (State) {
                case GameState.Menu:
                    startScreen.Update();
                    if (NeedExit) Exit();
                    break;
                case GameState.Load:
                    break;
                case GameState.Pause:
                    break;
                case GameState.Game:
                    gameScreen.Update();
                    break;
            }
        }

        static public int NormalizeX(int x) {
            return (int)(x * Dx);
        }

        static public int NormalizeY(int x) {
            return (int)(x * Dy);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (State) {
                case GameState.Menu:
                    startScreen.Draw();
                    break;
                case GameState.Load:
                    break;
                case GameState.Pause:
                    break;
                case GameState.Game:
                    gameScreen.Draw();
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
