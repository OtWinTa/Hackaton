using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Android.Content;
using System.Collections.Generic;

namespace Hackaton {
    public class Enemy {
        double Stepx, Stepy;
        int CellInd, speed, time;
        static List<Texture2D> Textures;
        static SpriteBatch spriteBatch;
        static ContentManager content;

        public Enemy() {
            CellInd = 0;
        }

        public static void SetTexture(SpriteBatch ASpriteBatch, ContentManager AContent, string Path1, string Path2) {
            spriteBatch = ASpriteBatch;
            content = AContent;
            content.RootDirectory = "Content/Mobs";
            Textures = new List<Texture2D>();
            Textures.Add(content.Load<Texture2D>(Path1));
            Textures.Add(content.Load<Texture2D>(Path2));
        }

        public void Update() {
            if (time == 5) {
                time = 0;
                CellInd++;
            }
            if (time == 0) {
                //Stepx = (GameProcess.Way[CellInd + 1] % 35 - GameProcess.Way[CellInd] % 35) / 10.0;
                //Stepy = (GameProcess.Way[CellInd + 1] / 35 - GameProcess.Way[CellInd] / 35) / 10.0;
            }
            time++;
        }

        public void Draw() {
            //int p = (int)((GameProcess.Way[CellInd] % 35 * 12 + 201 + Stepx * time - GameScreen.offsetX) / GameScreen.Scale * Game1.Dx);
            //int q = (int)((GameProcess.Way[CellInd] / 35 * 12 + 21 + Stepy * time - GameScreen.offsetY) / GameScreen.Scale * Game1.Dy);
            //spriteBatch.Draw((Texture2D)Textures[0], new Rectangle(p,
            //    q, (int)(100 * GameScreen.Scale), (int)(100 * GameScreen.Scale)), 
            //    new Rectangle(0, 0, Textures[0].Width, Textures[0].Height), Color.White);
            //Textures.Reverse();
            //p,
            //    q, (int)(10 * GameScreen.Scale), (int)(10 * GameScreen.Scale)
        }
    }
}