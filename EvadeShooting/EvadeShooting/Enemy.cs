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
    public class Enemy : Sprite
    {
        public enum Kind
        {
            Test01,
            TestBoss,
        }
        
        public Kind kind{set;get;}

        public SoundEffect soundEffect;

        EnemyAlgorithm algorithm;

        public Enemy(Kind kd, Element el, Vector2 pos, int algorithmNo = 0, int stageNo = 0)
        {
            kind = kd;
            Element = el;
            algorithm = new EnemyAlgorithm(this, algorithmNo, stageNo);
            switch (kind)
            {
                case Kind.Test01:
                    Texture = Images.testEnemy;
                    Position = pos;
                    HP = MaxHp = 70000;
                    Atk = 5000.0f;
                    Radius = 4;
                    Rect = new Rectangle((int)Element * 16, 0, 16, 16);
                    soundEffect = null;
                    break;
                case Kind.TestBoss:
                    Texture = Images.testBoss;
                    Position = pos;
                    HP = MaxHp = 10000000;
                    Atk = 10000.0f;
                    Radius = 32;
                    Rect = new Rectangle((int)Element * 64, 0, 64, 64);
                    soundEffect = Sounds.bom01;
                    break;
            }
        }

        public override void RecieveDamage(Sprite attacker)
        {
            HP -= Sprite.DamageCalculation(attacker, this);
            if (HP <= 0 && soundEffect != null)
            {
                soundEffect.Play();
                Screen.stage.BGM.Stop();
                Screen.ScreenManager.AddScreen(new GameclearMenuScreen(), Screen.ControllingPlayer);
            }
            base.RecieveDamage(attacker);
        }

        public override void Remove()
        {
            
            base.Remove();
        }

        public override void Draw(GameTime gameTime)
        {
                base.Draw(gameTime);
        }
        public override void Update(GameTime gameTime)
        {
            algorithm.Update(gameTime);
            base.Update(gameTime);
        }
    }

    public class Enemies : BelongScreen
    {
        public List<Enemy> enemies = new List<Enemy>();
        public void Add(string kindName, string elementName, float posX, float posY, int algorithmNo = 0, int stageNo = 0)
        {
            foreach (Enemy.Kind kd in Enum.GetValues(typeof(Enemy.Kind)))
            {
                if (kd.ToString() == kindName)
                {
                    foreach (Element el in Enum.GetValues(typeof(Element)))
                    {
                        if (kd.ToString() == elementName)
                        {
                            enemies.Add(new Enemy(kd, el, new Vector2(posX, posY), algorithmNo, stageNo));
                        }
                    }
                }
            }
        }
        public void Add(Enemy.Kind kd, Element el, Vector2 pos, int algorithmNo = 0, int stageNo = 0)
        {
            enemies.Add(new Enemy(kd, el, pos, algorithmNo, stageNo));
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var item in enemies)
            {
                item.Draw(gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
            Enemy[] copy = new Enemy[enemies.Count];    //enemiesのコピーを作成
            enemies.CopyTo(copy);
            foreach (var item in copy)
            {
                if (item.Position.X < -120 || item.Position.Y < -120 || item.Position.X > 520 || item.Position.Y > 720 || item.HP < 0)
                {
                    item.Remove();
                    enemies.Remove(item);
                }
                else
                {
                    item.Update(gameTime);
                }
            }
        }
    }
}
