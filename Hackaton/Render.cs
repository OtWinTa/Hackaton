using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Android.Content;
using System;
using System.Collections.Generic;

namespace Hackaton {
    static class Render {
        const int ImageWidth = 960;
        const int ImageHeight = 540;
        static int OffsetX, OffsetY;
        static double Scale;
        static public SpriteBatch spriteBatch;

        static public void Draw(Texture2D Texture, Rectangle Rect, Rectangle SourseRect) {
            spriteBatch.Draw(Texture, new Rectangle((int)(Rect.Left * Scale) + OffsetX, (int)(Rect.Top * Scale) + OffsetY, (int)(Rect.Width * Scale),
                (int)(Rect.Height * Scale)), SourseRect, Color.White);
        }

        static public void Draw(Texture2D Texture, Rectangle Rect) {
            spriteBatch.Draw(Texture, new Rectangle((int)(Rect.Left * Scale) + OffsetX, (int)(Rect.Top * Scale) + OffsetY, (int)(Rect.Width * Scale), 
                (int)(Rect.Height * Scale)), Color.White);
        }

        static public void SetScreenInfo(Android.Util.DisplayMetrics metric) {
            Scale = Math.Min(metric.WidthPixels / (double)ImageWidth, metric.HeightPixels/ (double)ImageHeight);
            OffsetY = (int)(metric.HeightPixels - ImageHeight * Scale) / 2;
            OffsetX = (int)(metric.WidthPixels- ImageWidth * Scale) / 2;
        }

        public class Touch {
            public Vector2 Position;
            public TouchLocationState State;

            public Touch(Vector2 APos, TouchLocationState AState) {
                Position = APos;
                State = AState;
            }
        }

        static public List<Touch> Recount(TouchCollection Touches) {
            var T = new List<Touch>();
            for (int i = 0; i < Touches.Count; i++)
                T.Add(new Touch(new Vector2((int)((Touches[i].Position.X - OffsetX) / Scale), (int)((Touches[i].Position.Y - OffsetY) / Scale)), Touches[i].State));
            return T;
        }
    }
}