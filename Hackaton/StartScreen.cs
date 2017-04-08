using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Android.Content;

namespace Hackaton { 
    class StartScreen {
        Texture2D Texture;
        ContentManager Content;
        SpriteBatch spriteBatch;
        Button StartBtn, RecordBtn, ExitBtn;

        public StartScreen(SpriteBatch ASpriteBatch, ContentManager AContent) {
            spriteBatch = ASpriteBatch;
            Content = AContent;
            Content.RootDirectory = "Content";
            Texture = Content.Load<Texture2D>("Menu");
            StartBtn = new Button(315, 240, 330, 70, spriteBatch);
            StartBtn.SetImage("BtnNewGame", "BtnNewGameP", Content);
            RecordBtn = new Button(315, 320, 330, 70, spriteBatch);
            RecordBtn.SetImage("BtnScores", "BtnScoresP", Content);
            ExitBtn = new Button(315, 400, 330, 70, spriteBatch);
            ExitBtn.SetImage("BtnExit", "BtnExitP", Content);
        }

        public void Draw() {
            spriteBatch.Draw(Texture, new Rectangle(0, 0, Game1.NormalizeX(960), Game1.NormalizeY(540)), Color.White);
            StartBtn.Draw();
            RecordBtn.Draw();
            ExitBtn.Draw();
        }

        public void Update() {
            TouchCollection Touches = TouchPanel.GetState();
            if (StartBtn.CheckTouch(Touches)) {
                Game1.State = Game1.GameState.Game;
                return;
            }
            if (ExitBtn.CheckTouch(Touches)) {
                Game1.NeedExit = true;
                return;
            }
            if (RecordBtn.CheckTouch(Touches)) {
                return;
            }
        }
    }
}