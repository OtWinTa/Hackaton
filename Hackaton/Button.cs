using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Android.Content;
using System.Collections.Generic;

namespace Hackaton {
    class Button{
        public delegate void PressFunc();

        public int PosX, PosY, height, width;
        bool isPress = false;
        Texture2D Texture, PressTexture;
        PressFunc Press;

        public Button(int Ax, int Ay, int Awidth, int Aheigh, PressFunc APress) {
            PosX = Ax; PosY = Ay;
            width = Awidth;
            height = Aheigh;
            Press = APress;
        }

        public void SetImage(string Tpath, string PTpath, ContentManager Content) {
            if (Tpath != "") Texture = Content.Load<Texture2D>(Tpath);
            if (PTpath != "") PressTexture = Content.Load<Texture2D>(PTpath);
        }

        public void Draw() {
            Render.Draw(isPress ? Texture : PressTexture, new Rectangle(PosX, PosY, width, height));
        }

        public void Update(List<Render.Touch> Touches) {
            if (Touches.Count != 1) {
                isPress = false;
                return;
            }
            isPress = (Touches[0].Position.X >= PosX && Touches[0].Position.X <= PosX + width &&
                Touches[0].Position.Y >= PosY && Touches[0].Position.Y <= PosY + height);
            if (Touches[0].State == TouchLocationState.Released && isPress) {
                isPress = false;
                Press();
            }
        }
        
    }
}