using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Hackaton {

    public class Game1 : Game {
        StartScreen startScreen;
        GameScreen gameScreen;
        GraphicsDeviceManager graphics;

        public enum GameState { Menu, Load, Game, Pause };
        static public GameState State = GameState.Menu;
        static public bool NeedExit = false;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            GameProcess.EnemyType.Add(new Enemy1().GetType());
        }

        protected override void Initialize() {
            base.Initialize();
        }

        protected override void LoadContent() {
            Render.spriteBatch = new SpriteBatch(GraphicsDevice);
            startScreen = new StartScreen(Content);
            gameScreen = new GameScreen(Content);
        }

        protected override void UnloadContent() {
        }

        protected override void Update(GameTime gameTime) {
            var metric = new Android.Util.DisplayMetrics();
            Activity.WindowManager.DefaultDisplay.GetMetrics(metric);
            Render.SetScreenInfo(metric);

            List<Render.Touch> Touches = Render.Recount(TouchPanel.GetState());

            switch (State) {
                case GameState.Menu:
                    startScreen.Update(Touches);
                    if (NeedExit) Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                    break;
                case GameState.Load:
                    break;
                case GameState.Pause:
                    break;
                case GameState.Game:
                    gameScreen.Update(Touches);
                    break;
            }
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Render.spriteBatch.Begin();
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
            Render.spriteBatch.End();
        }
    }
}
