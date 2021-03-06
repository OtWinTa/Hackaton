using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Android.Content;
using System.Collections.Generic;
using System;

namespace Hackaton {
    class GameScreen {
        const double zoomkof = 0.01;
        const double dragTolerance = 1;

        static public double Scale = 0.5, dist;
        static public int x, y, offsetX, offsetY, offsetXX, offsetYY;

        bool IsMove = false;
        bool Iszoomin = false;
        Texture2D Texture;
        ContentManager Content;
        GameProcess gameProcess;

        public GameScreen(ContentManager AContent) {
            Content = AContent;
            Content.RootDirectory = "Content";
            Texture = Content.Load<Texture2D>("GameScreen");
            gameProcess = new GameProcess();
        }

        public void Draw() {
            Render.Draw(Texture, new Rectangle(0, 0, 960, 540),
                new Rectangle(offsetX + offsetXX, offsetY + offsetYY, (int)(960 * Scale), (int)(540 * Scale)));
            gameProcess.Draw();
        }

        void CellClick(int x, int y) {

        }

        void CheckTouch(List<Render.Touch> Touches) {
            if (Touches.Count == 0) {
                IsMove = Iszoomin = false;
                return;
            }
            if (Touches.Count == 1 && !Iszoomin) {
                if (Touches[0].State == TouchLocationState.Pressed) {
                    x = (int)Touches[0].Position.X;
                    y = (int)Touches[0].Position.Y;
                    return;
                }
                if (Touches[0].State == TouchLocationState.Released) {
                    if (IsMove) {
                        offsetX += offsetXX;
                        offsetY += offsetYY;
                    }
                    else CellClick(x, y); 
                    offsetXX = 0; offsetYY = 0;
                    return;
                }
                if (Math.Abs(x - (int)Touches[0].Position.X) < dragTolerance || Math.Abs(y - (int)Touches[0].Position.Y) < dragTolerance) return;
                offsetXX = Math.Max(Math.Min((int)(Scale * (x - (int)Touches[0].Position.X)), 960 - (int)(Scale * Texture.Width) - offsetX), -offsetX) ;
                offsetYY = Math.Max(Math.Min((int)(Scale * (y - (int)Touches[0].Position.Y)), 540 - (int)(Scale * Texture.Height) - offsetY), -offsetY);
                IsMove = true;
            }
            if (Iszoomin && Touches.Count == 1) IsMove = true;
            if (Touches.Count > 1 && !IsMove) {
                double d = Math.Sqrt((Touches[0].Position.X * Touches[0].Position.X + Touches[1].Position.X * Touches[1].Position.X) +
                    (Touches[0].Position.Y * Touches[0].Position.Y + Touches[1].Position.Y * Touches[1].Position.Y));
                if (Touches[1].State == TouchLocationState.Pressed)
                {
                    x = (int)(Touches[0].Position.X + Touches[1].Position.X) / 2;
                    y = (int)(Touches[0].Position.Y + Touches[1].Position.Y) / 2;
                    dist = d;
                    return;
                }
                if (Math.Abs(d - dist) < dragTolerance) return;
                double t = Scale;
                Scale += (dist - d) * zoomkof * Scale;
                Scale = Math.Max(Math.Min(Scale, Texture.Height / 540.0), 0.05);
                offsetX += (int)((t - Scale) * x);
                offsetX = Math.Min(Math.Max(0, offsetX), 960 - (int)(Texture.Width * Scale));
                offsetY += (int)((t - Scale) * y);
                offsetY = Math.Min(Math.Max(0, offsetY), 540 - (int)(Texture.Height * Scale));
                dist = d;
                Iszoomin = true;
                IsMove = false;
            }
        }

        public void Update(List<Render.Touch> Touches) {
            CheckTouch(Touches);
            gameProcess.Update();
            //if (StartBtn.CheckTouch(Touches)) {
            //    return;
            //}
            //if (ExitBtn.CheckTouch(Touches)) {
            //    Game1.NeedExit = true;
            //    return;
            //}
            //if (RecordBtn.CheckTouch(Touches)) {
            //    return;
            //}
        }
    }
}