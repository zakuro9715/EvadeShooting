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
    public class Shot : Sprite
    {
        public enum Kind
        {
            MyShot1,
            MyShot2,
            EnemyShot1,
            Ranbu
        }

        public Kind kind { set; get; }

        public Vector2 Degree { set; get; }

        public float Speed { set; get; }

        public bool isMyShot { set; get; }

        public Shot(Kind kd, Element el, Vector2 pos, float deg, float speed, bool isMyshot = false)
        {
            kind = kd;
            Element = el;
            Degree = new Vector2(TriFuncTable.Cos(deg), -TriFuncTable.Sin(deg));
            Speed = speed;
            isMyShot = isMyshot;

            float level = 0;
            if (GameState.Level == GameState.GameLevel.Easy)
                level = 4;
            else if (GameState.Level == GameState.GameLevel.Nomal)
                level = 2.5f;
            else if (GameState.Level == GameState.GameLevel.Hard)
                level = 1;
                switch (kind)
                {
                    case Kind.MyShot1:
                        Texture = Images.shot01;
                        Position = pos;
                        HP = MaxHp = int.MaxValue;
                        Atk = 1000f * level;
                        Alpha = 0.6f;
                        Radius = 4;
                        Rect = new Rectangle((int)Element * 8, 0, 8, 8);
                        break;
                    case Kind.MyShot2:
                        Texture = Images.shot01;
                        Position = pos;
                        HP = MaxHp = int.MaxValue;
                        Atk = 1000 * level;
                        Alpha = 0.3f;
                        Radius = 4;
                        Rect = new Rectangle((int)Element * 8, 0, 8, 8);
                        break;
                    case Kind.EnemyShot1:
                        Texture = Images.shot01;
                        Position = pos;
                        HP = MaxHp = int.MaxValue;
                        Atk = 2000f;
                        Radius = 4;
                        Rect = new Rectangle((int)Element * 8, 0, 8, 8);
                        break;
                    case Kind.Ranbu:
                        Texture = Images.shot02;
                        Position = pos;
                        HP = MaxHp = int.MaxValue;
                        Atk = 4000f;
                        Radius = 1;
                        Rect = new Rectangle((int)Element * 16, 0, 16, 16);
                        break;
                }
        }

        public override void RecieveDamage(Sprite attacker)
        {
            HP = -1;
            base.RecieveDamage(attacker);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        public override void Update(GameTime gameTime)
        {
            Position +=Degree * Speed;
            if (GameState.IsExtraStage && !isMyShot)
            {
                if (Position.X <= 0)
                {
                    Position = new Vector2(0, Position.Y);
                    Degree = new Vector2(-Degree.X, Degree.Y);
                    Speed += 0.03f;
                }
                if (Position.X >= 400)
                {
                    Position = new Vector2(400, Position.Y);
                    Degree = new Vector2(-Degree.X, Degree.Y);
                    Speed += 0.03f;
                }
                if (Position.Y <= 0)
                {
                    Position = new Vector2(Position.X, 0);
                    Degree = new Vector2(Degree.X, -Degree.Y);
                    Speed += 0.03f;
                }
                if (Position.Y >= 600)
                {
                    Position = new Vector2(Position.X, 600);
                    Degree = new Vector2(Degree.X, -Degree.Y);
                    Speed += 0.03f;
                }
            }
            base.Update(gameTime);
        }
    }

    public class Shots : BelongScreen
    {
        public List<Shot> shots = new List<Shot>();
        public void Add(string kindName, string elementName, float posX, float posY, float deg, float speed, bool isMyshot = false)
        {
            foreach (Shot.Kind kd in Enum.GetValues(typeof(Shot.Kind)))
            {
                if (kd.ToString() == kindName)
                {
                    foreach (Element el in Enum.GetValues(typeof(Element)))
                    {
                        if (kd.ToString() == elementName)
                        {
                            shots.Add(new Shot(kd, el, new Vector2(posX, posY), deg, speed, isMyshot));
                        }
                    }
                }
            }
        }
        public void Add(Shot.Kind kd, Element el, Vector2 pos, float deg, float speed, bool isMyshot = false)
        {
            shots.Add(new Shot(kd, el, pos, deg, speed, isMyshot));
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var item in shots)
            {
                item.Draw(gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
            Shot[] copy = new Shot[shots.Count];    //shotsのコピーを作成
            shots.CopyTo(copy);
            foreach(var item in copy)
            {
                if (item.Position.X < 0 || item.Position.Y < 0 || item.Position.X > 400 || item.Position.Y > 600 || item.HP < 0)
                {
                    item.Remove();
                    shots.Remove(item);
                }
                else
                {
                    item.Update(gameTime);
                }
            }
        }
    }
}
