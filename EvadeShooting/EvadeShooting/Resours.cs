using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Evade
{
    static class Images
    {
        static public Texture2D myUnit;
        static public Texture2D shot01;
        static public Texture2D shot02;
        static public Texture2D testEnemy;
        static public Texture2D testBoss;
        static public Texture2D Migi;
        static public Texture2D GameOver;
        static public Texture2D GameClear;

        static public void LoadImage(ContentManager Content)
        {
            myUnit = Content.Load<Texture2D>("Image\\MyMachine\\FrightAircraft01");
            shot01 = Content.Load<Texture2D>("Image\\Shot\\Shot01");
            shot02 =Content.Load<Texture2D>("Image\\Shot\\Shot02");
            testEnemy = Content.Load<Texture2D>("Image\\Enemy\\Test");
            testBoss = Content.Load<Texture2D>("Image\\Enemy\\TestBoss");
            Migi = Content.Load<Texture2D>("Image\\Background\\Migi");
            GameOver = Content.Load<Texture2D>("Image\\Background\\GameOver");
            GameClear = Content.Load<Texture2D>("Image\\Background\\GameClear");
        }
    }
    static class Sounds
    {
        static public SoundEffectInstance BGM01;
        static public SoundEffectInstance Genkaku;
        static public SoundEffect bom01;

        static public void LoadSound(ContentManager Content)
        {
            BGM01 = Content.Load<SoundEffect>("BGM\\No1").CreateInstance();
            Genkaku = Content.Load<SoundEffect>("BGM\\幻覚小町").CreateInstance();
            bom01 = Content.Load<SoundEffect>("SoundEffect\\bom01");
            BGM01.IsLooped = true;
            Genkaku.IsLooped = true;
            Genkaku.Volume = 0.4f;
        }
    }
    static class Fonts
    {
        static public SpriteFont MenuFont;
        static public SpriteFont AccessoryFont;
        static public SpriteFont TitleFont;

        static public void LoadFont(ContentManager Content)
        {
            MenuFont = Content.Load<SpriteFont>("Font\\MenuFont");
            AccessoryFont = Content.Load<SpriteFont>("Font\\AccessoryFont");
            TitleFont = Content.Load<SpriteFont>("Font\\TitleFont");
        }
    }
}
