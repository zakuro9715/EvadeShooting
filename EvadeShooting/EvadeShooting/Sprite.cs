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
    public abstract class BelongScreen
    {
        static public MainScreen Screen;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }

    public enum Element { Flame = 0, Aqua, Wind }
    public class Sprite : BelongScreen
    {

        #region プロパティ

        /// <summary>
        /// テクスチャ
        /// </summary>
        public Texture2D Texture { set; get; }

        /// <summary>
        /// スプライトの中心座標
        /// </summary>
        public Vector2 Position { set; get; }

        /// <summary>
        /// スプライトの属性
        /// </summary>
        public Element Element { set; get; }

        /// <summary>
        /// 不透明度
        /// </summary>
        public float Alpha
        {
            set { _Alpha = value; }
            get { return _Alpha; }
        }
        float _Alpha = 1.0f;

        public float HP { set; get; }

        public float MaxHp { set; get; }

        public float Atk { set; get; }

        /// <summary>
        /// 当たり判定の半径
        /// </summary>
        public int Radius { set; get; }

        /// <summary>
        /// テクスチャの描画範囲
        /// </summary>
        public Rectangle Rect { set; get; }
        
        /// <summary>
        /// 経過フレーム
        /// </summary>
        protected int time
        {
            private set { _time = value; }
            get { return _time; }
        }
        int _time = 0;

        #endregion

        public override void Draw(GameTime gameTime)
        {
            Screen.ScreenManager.SpriteBatch.Draw(Texture, new Vector2(Position.X - Rect.Width / 2, Position.Y - Rect.Height / 2), Rect, Color.White * Alpha * (HP / MaxHp + 0.1f));
        }

        public override void Update(GameTime gameTime)
        {
            time++;
        }

        public virtual void RecieveDamage(Sprite attacker) { }

        public virtual void Remove() { }

        public static float GetDeg(Vector2 a, Vector2 target)
        {
            float x = +(a.X - target.X);
            float y = -(a.Y - target.Y);
            float deg = (float)Math.Atan(y / x) / (float)Math.PI * 180.0f;
            if (0 <= x)
            {
                deg += 180.0f;
            }
            return deg;
        }

        public static bool HitCheck(Vector2 posA, int radiusA, Vector2 posB, int radiusB)
        {
            float xx = posA.X - posB.X;
            float yy = posA.Y - posB.Y;
            xx *= xx;
            yy *= yy;

            float rr = radiusA + radiusB;
            rr *= rr;

            if ((xx + yy) <= rr)
            {
                return true;
            }

            return false;
        }

        public static bool HitCheck(Sprite a, Sprite b)
        {
            return HitCheck(a.Position, a.Radius, b.Position, b.Radius);
        }


        public static float GetLength(Vector2 a,Vector2 b)
        {
            float xx = a.X - b.X;
            float yy = a.Y - b.Y;
            xx *= xx;
            yy *= yy;

            return (float)Math.Sqrt(xx + yy);
        }
        public static float GetLength(Sprite a, Sprite b)
        {
            return GetLength(a.Position,b.Position);
        }

        protected static float DamageCalculation(Sprite attacker, Sprite target)
        {
            float atk = attacker.Atk;
            if (attacker.Element == Element.Flame)
            {
                if (target.Element == Element.Flame) { return atk; }
                else if (target.Element == Element.Aqua) { return atk * 0.8f; }
                else if (target.Element == Element.Wind) { return atk * 1.2f; }
            }
            else if (attacker.Element == Element.Aqua)
            {
                if (target.Element == Element.Flame) { return atk * 1.2f; }
                else if (target.Element == Element.Aqua) { return atk; }
                else if (target.Element == Element.Wind) { return atk * 0.8f; }
            }
            else if (attacker.Element == Element.Wind)
            {
                if (target.Element == Element.Flame) { return atk * 0.8f; }
                else if (target.Element == Element.Aqua) { return atk * 1.2f; }
                else if (target.Element == Element.Wind) { return atk; }
            }
            return atk;
        }
    }
}
