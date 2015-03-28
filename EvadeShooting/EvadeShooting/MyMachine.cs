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
    public class MyMachine : Sprite
    {
        public int InvincibleTime = 0;
        bool wasCreateScreen = false;

        public MyMachine(Element el = Element.Flame)
        {
            Texture = Images.myUnit;
            Position = new Vector2(200,450);
            Element = el;


            if (GameState.Level == GameState.GameLevel.Easy)
                HP = MaxHp = 30000.0f;
            else if (GameState.Level == GameState.GameLevel.Nomal)
                HP = MaxHp = 10000.0f;
            else if (GameState.Level == GameState.GameLevel.Hard)
                HP = MaxHp = 5000.0f;
            if(GameState.isEvadeAll)
                HP = MaxHp = 1.0f;
            if (GameState.isDebugMode)
                HP = MaxHp = float.MaxValue;

            Atk = 0.0f;
            Radius = 1;
            Rect = new Rectangle(0, 0, 32, 32);
        }


        public override void RecieveDamage(Sprite attacker)
        {
            if (InvincibleTime <= 0)
            {
                HP -= Sprite.DamageCalculation(attacker, this) * new Random().Next(80000, 120000) / 100000;
                InvincibleTime = 100;
            }

            base.RecieveDamage(attacker);
        }
        public override void Draw(GameTime gameTime)
        {
            if ((InvincibleTime < 0 || time % 18 <= 8) && HP > 0) { base.Draw(gameTime); }
        }
        public override void Update(GameTime gameTime)
        {
            if (HP <= 0 && !wasCreateScreen)
            {
                Screen.GameOver();
                wasCreateScreen = true;
            }
            InvincibleTime--;
            base.Update(gameTime);
        }
    }
}
