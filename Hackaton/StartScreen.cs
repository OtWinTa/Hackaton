using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Android.Content;
using System.Collections.Generic; 

namespace Hackaton { 
    class StartScreen {
        Texture2D Texture;
        ContentManager Content;
        List<Button> Buttons = new List<Button>();

        public StartScreen(ContentManager AContent) {
            Content = AContent;
            Content.RootDirectory = "Content";
            Texture = Content.Load<Texture2D>("Menu");
            Buttons.Add(new Button(315, 240, 330, 70, new Button.PressFunc(StartBtnPress)));
            Buttons[Buttons.Count - 1].SetImage("BtnNewGame", "BtnNewGameP", Content);
            Buttons.Add(new Button(315, 320, 330, 70, new Button.PressFunc(ScoreBtnPress)));
            Buttons[Buttons.Count - 1].SetImage("BtnScores", "BtnScoresP", Content);
            Buttons.Add(new Button(315, 400, 330, 70, new Button.PressFunc(ExitBtnPress)));
            Buttons[Buttons.Count - 1].SetImage("BtnExit", "BtnExitP", Content);
        }

        public void Draw() {
            Render.Draw(Texture, new Rectangle(0, 0, 960, 540));
            for (int i = 0; i < Buttons.Count; i++)
                Buttons[i].Draw();
        }

        public void Update(List<Render.Touch> Touches) {
            for (int i = 0; i < Buttons.Count; i++)
                Buttons[i].Update(Touches);
        }

        static public void StartBtnPress() {
            Game1.State = Game1.GameState.Game;
        }

        static public void ExitBtnPress() {
            Game1.NeedExit = true;
        }

        static public void ScoreBtnPress() {
        }
    }
}