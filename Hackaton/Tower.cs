using System;
using Microsoft.Xna.Framework;

namespace Hackaton{
    class Tower{
        public int PosX, PosY, height, width;
        Texture2D Texture, PressTexture;
        SpriteBatch spriteBatch;
        public int Level;
        public int Damage;

        public Tower(int Ax, int Ay, int Awidth, int Aheigh, SpriteBatch AspriteBatch) {
            PosX = Ax; PosY = Ay;
            width = Awidth;
            height = Aheigh;
            spriteBatch = AspriteBatch;
            }

        public void SetImage(string Tpath, string PTpath, ContentManager Content) {
        }

        public void Draw() {
            spriteBatch.Draw(isPress ? Texture : PressTexture, new Rectangle(Game1.NormalizeX(PosX), Game1.NormalizeY(PosY),
                Game1.NormalizeX(width), Game1.NormalizeY(height)), Color.White);
        }
    }
}