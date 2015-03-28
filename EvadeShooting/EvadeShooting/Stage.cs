using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameStateManagement;

namespace Evade
{
    public class Stage : BelongScreen
    {
        public StageAlgorithm algorithm;
        public SoundEffectInstance BGM;
        public int StageNo = 0;
        int time;

        public void Activate()
        {
            algorithm = new StageAlgorithm();
            time = 0;
        }

        public void ChangeStage()
        {
            StageNo++;
            time = 0;
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            algorithm.Update(gameTime);
            time++;
        }
    }

    public class Accessory:BelongScreen
    {
        public string Text { set; get; }
        public Vector2 TextPosition;
        public SpriteFont Font;


        public Accessory()
        {
            Text = "";
            Font = Fonts.MenuFont;
            TextPosition = new Vector2(0, 570);
        }
        public override void Draw(GameTime gameTime)
        {
            Screen.ScreenManager.SpriteBatch.DrawString(Font, Text, TextPosition, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
