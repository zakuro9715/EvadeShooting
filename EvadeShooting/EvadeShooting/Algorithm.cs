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
    public class StageAlgorithm : BelongScreen
    {
        public int time = 0;
        public int StageNo;
        int seed = DateTime.Now.Millisecond;

        public StageAlgorithm(int stageNo = 0)
        {
            StageNo = stageNo;
            time = 0;
        }

        public override void Update(GameTime gameTime)
        {
            switch (StageNo)
            {
                case 0:
                    if (time == 0)
                    {
                        Screen.stage.BGM = Sounds.Genkaku;
                        Screen.stage.BGM.Play();
                        Screen.accessory.Font = Fonts.AccessoryFont;
                        Screen.accessory.Text = "BGM\n幻覚小町";
                        Screen.accessory.TextPosition = new Vector2(-50, 570);
                    }
                    if (time < 34 || (time > 234 && time < 240)) { Screen.accessory.TextPosition.X += 12; }
                    if (time < 1400 && time % 198 == 0)
                    {

                        Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 50), 0);
                        Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(400, 50), 1);

                        if (time >= 600)
                        {
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 0), 0);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(400, 0), 1);

                        }
                    }
                    else if (time > 1400 && time < 2400 && time % 1580 == 0)
                    {
                        Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(100, 0), 2);
                        Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(200, 0), 2);
                        Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(300, 0), 2);
                    }
                    else if (time % 25 == 0 && time > 2300 && time < 2700)
                    {
                        Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(200, 0), 3);
                    }
                    else if (time == 3100)
                    {
                        if (GameState.Level == GameState.GameLevel.Easy)
                        {
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, -32), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-8, -16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(8, -16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-16, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(16, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-8, 16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(8, 16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 32), 7);
                        }
                        else if (GameState.Level == GameState.GameLevel.Nomal)
                        {
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, -32), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-8, -16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(8, -16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-16, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(16, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-8, 16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(8, 16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 32), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(0, 568), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(-8, 584), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(8, 584), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(-16, 600), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(0, 600), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(16, 600), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(-8, 616), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(8, 616), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(0, 632), 8);
                        }
                        else if (GameState.Level == GameState.GameLevel.Hard)
                        {
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, -32), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-8, -16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(8, -16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-16, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(16, 0), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(-8, 16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(8, 16), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 32), 7);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(0, 568), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(-8, 584), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(8, 584), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(-16, 600), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(0, 600), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(16, 600), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(-8, 616), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(8, 616), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(0, 632), 8);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(100, -32), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(92, -16), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(108, -16), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(84, 0), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(100, 0), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(116, 0), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(92, 16), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(108, 16), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(100, 32), 9);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(100, 568), 10);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(92, 584), 10);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(108, 584), 10);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(86, 600), 10);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(100, 600), 10);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(116, 600), 10);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(92, 616), 10);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(108, 616), 10);
                            Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, new Vector2(100, 632), 10);
                        }
                    }
                    else if (time > 3800 && time < 4600)
                    {
                        if (time % 100 == 0)
                        {
                            float loop = 0;
                            if (GameState.Level == GameState.GameLevel.Easy)
                                loop = 5;
                            else if (GameState.Level == GameState.GameLevel.Nomal)
                                loop = 10;
                            else
                                loop = 20;

                            for (int i = 0; i < loop; i++)
                            {
                                Vector2 pos = Screen.me.Position + new Vector2((float)Math.Cos(2 * Math.PI * (i / loop)), (float)Math.Sin(2 * Math.PI * (i / loop))) * 150;
                                if (pos.X < 0)
                                    pos.X = 0;
                                else if (pos.X > 400)
                                    pos.X = 400;
                                if (pos.Y < 0)
                                    pos.Y = 0;
                                else if (pos.Y > 600)
                                    pos.Y = 600;

                                if (time % 300 == 0)
                                    Screen.enemies.Add(Enemy.Kind.Test01, Element.Flame, pos, 11);
                                else if (time % 300 == 100)
                                    Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, pos, 11);
                                else if (time % 300 == 200)
                                    Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, pos,11);
                            }
                        }
                    }
                    if (time == 4650)
                    {
                        Screen.enemies.Add(Enemy.Kind.TestBoss, Element.Aqua, new Vector2(200, 100));
                        if (GameState.Level == GameState.GameLevel.Nomal)
                        {
                            //Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua, new Vector2(0, 0), 50);
                            //Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind,  new Vector2(0, 0), 50);
                            //Screen.enemies.Add(Enemy.Kind.Test01, Element.Aqua,  new Vector2(300, 600), 51);
                            //Screen.enemies.Add(Enemy.Kind.Test01, Element.Wind, new Vector2(300, 600), 51);
                        }
                    }
                    break;
                case 99:
                    if (time == 0)
                    {
                        seed = DateTime.Now.Millisecond;
                        Screen.stage.BGM = Sounds.BGM01;
                        Screen.stage.BGM.Play();
                        Screen.accessory.Font = Fonts.AccessoryFont;
                        Screen.accessory.Text = "BGM\n狩り";
                        Screen.accessory.TextPosition = new Vector2(-50, 570);
                    }
                    if (time < 34 || (time > 234 && time < 240)) { Screen.accessory.TextPosition.X += 12; }
                    if (time % 150 == 0)
                        Screen.shots.Add(Shot.Kind.EnemyShot1, Element.Flame, new Vector2(0, 0), Sprite.GetDeg(new Vector2(0, 0), Screen.me.Position), 3);
                    else if (time % 150 == 50)
                        Screen.shots.Add(Shot.Kind.EnemyShot1, Element.Aqua, new Vector2(0, 0), Sprite.GetDeg(new Vector2(0, 0), Screen.me.Position), 3);
                    else if (time % 150 == 100)
                        Screen.shots.Add(Shot.Kind.EnemyShot1, Element.Wind, new Vector2(0, 0), Sprite.GetDeg(new Vector2(0, 0), Screen.me.Position), 3);
                    
                    break;
            }
            time++;
        }
        public override void Draw(GameTime gameTime)
        {

        }
    }

    public class EnemyAlgorithm : BelongScreen
    {
        Enemy enemy;
        int time = 0;
        int AlgorithmNo;
        int seed = DateTime.Now.Second;
        int value = -1;
        int StageNo;

        public EnemyAlgorithm(Enemy enemy, int AlgorithmNo = 0, int stageNo = 0)
        {
            this.enemy = enemy;
            this.AlgorithmNo = AlgorithmNo;
            StageNo = stageNo;
        }

        public override void Update(GameTime gameTime)
        {
            switch (StageNo)
            {
                case 0:
                    switch (enemy.kind)
                    {
                        case Enemy.Kind.Test01:
                            switch (AlgorithmNo)
                            {
                                case 0:
                                    enemy.Position += new Vector2(2, 2);
                                    if (time % 26 == 0)
                                    {
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position + new Vector2(0, 3), -90, 3);

                                    }
                                    if (time % 13 == 0 && GameState.Level == GameState.GameLevel.Nomal)
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, Sprite.GetDeg(enemy.Position, Screen.me.Position), 3);
                                    else if (time % 2 == 0 && time % 30 >= 15 && GameState.Level == GameState.GameLevel.Hard)
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, Sprite.GetDeg(enemy.Position, Screen.me.Position), 3);
                                    break;
                                case 1:
                                    enemy.Position += new Vector2(-2, 2);
                                    if (time % 26 == 0)
                                    {
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position + new Vector2(0, 3), -90, 3);
                                    }
                                    if (time % 13 == 0 && GameState.Level == GameState.GameLevel.Nomal)
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, Sprite.GetDeg(enemy.Position, Screen.me.Position), 3);
                                    else if (time % 2 == 0 && time % 30 >= 15 && GameState.Level == GameState.GameLevel.Hard)
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, Sprite.GetDeg(enemy.Position, Screen.me.Position), 3);
                                    break;
                                case 2:
                                    if (time < 10)
                                        enemy.Position += new Vector2(0, 10);
                                    else if (time > 730)
                                        enemy.Position -= new Vector2(0, 10);
                                    else if (GameState.Level == GameState.GameLevel.Easy && time % 40 == 0)
                                    {
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 10, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 90, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 130, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 170, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 210, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 250, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 290, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 330, 3);
                                    }
                                    else if (GameState.Level == GameState.GameLevel.Nomal && time % 35 == 0)
                                    {
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 30, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 60, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 90, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 120, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 150, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 180, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 210, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 240, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 270, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 300, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 330, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 360, 3);
                                    }
                                    else if (GameState.Level == GameState.GameLevel.Hard && time % 30 == 0)
                                    {
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 0, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 15, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 30, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 45, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 60, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 75, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 90, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 105, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 120, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 135, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 150, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 165, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 180, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 195, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 210, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 225, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 240, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 255, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 270, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 285, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 300, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 315, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 330, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, 345, 3);
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, Sprite.GetDeg(enemy.Position, Screen.me.Position), 3);
                                    }
                                    break;
                                case 3:
                                    if (time < 25)
                                        enemy.Position += new Vector2(8, 12);
                                    else if (time < 50)
                                        enemy.Position += new Vector2(-8, 12);
                                    else if (time < 75)
                                        enemy.Position += new Vector2(-8, -12);
                                    else
                                        enemy.Position += new Vector2(8, -12);
                                    if (time < 100)
                                    {
                                        if (time % 20 == 0 && GameState.Level == GameState.GameLevel.Easy)
                                            Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position + new Vector2(1, 3), Sprite.GetDeg(enemy.Position, new Vector2(200, 300)), 1);
                                        else if (time % 15 == 0 && GameState.Level == GameState.GameLevel.Nomal)
                                            Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position + new Vector2(1, 3), Sprite.GetDeg(enemy.Position, Screen.me.Position), 1);
                                        else if (time % 10 == 0 && GameState.Level == GameState.GameLevel.Hard)
                                            Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position + new Vector2(1, 3), Sprite.GetDeg(enemy.Position, Screen.me.Position), 1);
                                    }
                                    break;
                                case 7:

                                    if (time < 600)
                                    {
                                        if (time % 300 < 75)
                                            enemy.Position += new Vector2(200.0f / 75, 8);
                                        else if (time % 300 < 150)
                                            enemy.Position += new Vector2(200.0f / 75, -8);
                                        else if (time % 300 < 225)
                                            enemy.Position += new Vector2(-200.0f / 75, 8);
                                        else
                                            enemy.Position += new Vector2(-200.0f / 75, -8);
                                    }
                                    else if (time < 675)
                                        enemy.Position += new Vector2(200.0f / 75, 300.0f / 75);
                                    else
                                        enemy.Position += new Vector2(0, 300.0f / 75);

                                    break;
                                case 8:
                                    if (time < 600)
                                    {
                                        if (time % 300 < 75)
                                            enemy.Position += new Vector2(200.0f / 75, -8);
                                        else if (time % 300 < 150)
                                            enemy.Position += new Vector2(200.0f / 75, 8);
                                        else if (time % 300 < 225)
                                            enemy.Position += new Vector2(-200.0f / 75, -8);
                                        else
                                            enemy.Position += new Vector2(-200.0f / 75, 8);
                                    }
                                    else if (time < 675)
                                        enemy.Position += new Vector2(200.0f / 75, -300.0f / 75);
                                    else
                                        enemy.Position += new Vector2(0, -300.0f / 75);

                                    break;
                                case 9:
                                    if (time < 600)
                                    {
                                        if (time % 300 < 75)
                                            enemy.Position += new Vector2(100.0f / 75, 4);
                                        else if (time % 300 < 150)
                                            enemy.Position += new Vector2(100.0f / 75, -4);
                                        else if (time % 300 < 225)
                                            enemy.Position += new Vector2(-100.0f / 75, 4);
                                        else
                                            enemy.Position += new Vector2(-100.0f / 75, -4);
                                    }
                                    else if (time < 675)
                                        enemy.Position += new Vector2(100.0f / 75, 300.0f / 75);
                                    else
                                        enemy.Position += new Vector2(200f / 75, 0);

                                    if (time % 13 == 0)
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position + new Vector2(1, 3), Sprite.GetDeg(enemy.Position, Screen.me.Position), 3);

                                    break;
                                case 10:
                                    if (time < 600)
                                    {
                                        if (time % 300 < 75)
                                            enemy.Position += new Vector2(100.0f / 75, -4);
                                        else if (time % 300 < 150)
                                            enemy.Position += new Vector2(100.0f / 75, 4);
                                        else if (time % 300 < 225)
                                            enemy.Position += new Vector2(-100.0f / 75, -4);
                                        else
                                            enemy.Position += new Vector2(-100.0f / 75, 4);
                                    }
                                    else if (time < 675)
                                        enemy.Position += new Vector2(100.0f / 75, -300.0f / 75);
                                    else
                                        enemy.Position += new Vector2(-200f / 75, 0);

                                    if (time % 13 == 0)
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position + new Vector2(1, 3), Sprite.GetDeg(enemy.Position, Screen.me.Position), 3);

                                    break;
                                case 11:
                                    if (time == 50)
                                    {
                                        float speed = Sprite.GetLength(enemy, Screen.me) / 15;
                                        Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position + new Vector2(1, 3), Sprite.GetDeg(enemy.Position, Screen.me.Position), speed);
                                        enemy.Remove();
                                        Screen.enemies.enemies.Remove(enemy);
                                    }
                                    break;
                            }

                            break;
                        case Enemy.Kind.TestBoss:
                            switch (AlgorithmNo)
                            {
                                case 0:
                                    if (time < 60)
                                    {
                                        enemy.Position += new Vector2(0, 1);
                                    }
                                    else
                                    {
                                        int Bosstime = (this.time - 60) % 770;
                                        if (Bosstime == 0)
                                        {
                                            int beforValue = value;
                                            do
                                            {
                                                value = new Random(seed++).Next(3);
                                            } while (beforValue == value);
                                        }
                                        switch (value)
                                        {
                                            case 0:
                                                if (GameState.Level == GameState.GameLevel.Easy)
                                                {
                                                    if (Bosstime % 30 == 0 && Bosstime < 400)
                                                    {
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 90, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 180, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 270, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 90), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 180), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 270), 1.0f);
                                                    }
                                                }
                                                else if (GameState.Level == GameState.GameLevel.Nomal)
                                                {
                                                    if (Bosstime % 10 == 0 && Bosstime < 400)
                                                    {
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 60, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 120, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 180, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 240, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 300, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 60), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 120), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 180), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 240), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 300), 1.0f);
                                                    }
                                                }
                                                else if (GameState.Level == GameState.GameLevel.Hard)
                                                {
                                                    if (Bosstime % 2 == 0 && Bosstime < 400)
                                                    {
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 45, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 90, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 135, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 180, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 225, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 270, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, time + 315, 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 45), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 90), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 135), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time - 180), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time - 225), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 270), 1.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -(time + 315), 1.0f);
                                                    }
                                                }
                                                break;
                                            case 1:
                                                if (Bosstime < 100)
                                                    enemy.Position += new Vector2(0, -2);
                                                else if (Bosstime == 100)
                                                    enemy.Position = new Vector2(-60, -90);
                                                else if (Bosstime - 100 < 150)
                                                    enemy.Position += new Vector2(520 / 150.0f, 780 / 150f);
                                                else if (Bosstime - 100 == 150)
                                                    enemy.Position = new Vector2(460, -90);
                                                else if (Bosstime - 100 < 300)
                                                    enemy.Position += new Vector2(-520 / 150.0f, 780 / 150f);
                                                else if (Bosstime - 100 == 300)
                                                    enemy.Position = new Vector2(100, -90);
                                                else if (Bosstime - 100 < 450)
                                                    enemy.Position += new Vector2(0, 780 / 150.0f);
                                                else if (Bosstime - 100 == 450)
                                                    enemy.Position = new Vector2(300, 690);
                                                else if (Bosstime - 100 < 600)
                                                    enemy.Position += new Vector2(0, -780 / 150.0f);
                                                else if (Bosstime - 100 == 600)
                                                    enemy.Position = new Vector2(200, -100);
                                                else if (Bosstime - 100 < 650)
                                                    enemy.Position += new Vector2(0, 270 / 50.0f);
                                                break;
                                            case 2:
                                                if (Bosstime < 720)
                                                {
                                                    if (GameState.Level == GameState.GameLevel.Hard || (Bosstime % 10 == 0 && GameState.Level == GameState.GameLevel.Nomal) || (Bosstime % 20 == 0 && GameState.Level == GameState.GameLevel.Easy))
                                                    {
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, Bosstime * 4, 2.0f);
                                                        Screen.shots.Add(Shot.Kind.Ranbu, enemy.Element, enemy.Position, -Bosstime * 4, 2.0f);
                                                        if ((GameState.Level == GameState.GameLevel.Hard && Bosstime % 40 < 20) || (GameState.Level == GameState.GameLevel.Nomal && Bosstime % 80 < 20))
                                                            Screen.shots.Add(Shot.Kind.EnemyShot1, enemy.Element, enemy.Position, Sprite.GetDeg(enemy.Position, Screen.me.Position), 3);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    break;
                                case 1:
                                    break;
                            }
                            break;
                    }
                    break;
            }
            time++;
        }
        public override void Draw(GameTime gameTime)
        {
        }
    }
}
