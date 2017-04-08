using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Android.Content;

namespace Hackaton {
    class Button{
        public int PosX, PosY, height, width;
        bool isPress = false;
        Texture2D Texture, PressTexture;
        SpriteBatch spriteBatch;

        public Button(int Ax, int Ay, int Awidth, int Aheigh, SpriteBatch AspriteBatch) {
            PosX = Ax; PosY = Ay;
            width = Awidth;
            height = Aheigh;
            spriteBatch = AspriteBatch;
        }

        public void SetImage(string Tpath, string PTpath, ContentManager Content) {
            if (Tpath != "") Texture = Content.Load<Texture2D>(Tpath);
            if (PTpath != "") PressTexture = Content.Load<Texture2D>(PTpath);
        }

        public void Draw() {
            spriteBatch.Draw(isPress ? Texture : PressTexture, new Rectangle(Game1.NormalizeX(PosX), Game1.NormalizeY(PosY),
                Game1.NormalizeX(width), Game1.NormalizeY(height)), Color.White);
        }

        public bool CheckTouch(TouchCollection Touches) {
            if (Touches.Count != 1)
                return isPress = false;
            else {
                isPress = (Touches[0].Position.X >= Game1.NormalizeX(PosX) && Touches[0].Position.X <= Game1.NormalizeX(PosX + width) &&
                    Touches[0].Position.Y >= Game1.NormalizeY(PosY) && Touches[0].Position.Y <= Game1.NormalizeY(PosY + height));
                if (Touches[0].State == TouchLocationState.Released && isPress)
                    return !(isPress = false);
                return false;
            }
        }
        
    }
}