using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Android.Content;
using System.Collections;

namespace Hackaton {
    class Enemy {
        static ArrayList Textures;
        static SpriteBatch spriteBatch;
        static ContentManager content;
        int Posx, Posy;

        public static void SetTexture(SpriteBatch ASpriteBatch, ContentManager AContent, string Path1, string Path2) {
            spriteBatch = ASpriteBatch;
            content = AContent;
            content.RootDirectory = "Content/Mobs";
            Textures.Add(content.Load<Texture2D>(Path1));
            Textures.Add(content.Load<Texture2D>(Path2));
        }

        void Update() {

        }

        void Draw() {
            spriteBatch.Draw((Texture2D)Textures[0], new Rectangle(Posx, Posy, (int)(10 * GameScreen.Scale), (int)(10 * GameScreen.Scale)), Color.White);
            Textures.Reverse();
        }
    }
}