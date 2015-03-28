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
    public class MainScreen : GameScreen
    {
        public Stage stage = new Stage();
        public Accessory accessory = new Accessory();
        public Shots shots;
        public Enemies enemies;
        public MyMachine me;
        bool isPose = true;
        int shotwait = 0;
        InputAction Up = new InputAction(null, new Keys[] { Keys.Up, Keys.W }, false);
        InputAction Down = new InputAction(null, new Keys[] { Keys.Down, Keys.S }, false);
        InputAction Right = new InputAction(null, new Keys[] { Keys.Right, Keys.D }, false);
        InputAction Left = new InputAction(null, new Keys[] { Keys.Left, Keys.A }, false);
        InputAction Slow = new InputAction(null, new Keys[] { Keys.LeftShift ,Keys.RightShift}, false);
        InputAction Shoot = new InputAction(null, new Keys[] { Keys.Z }, false);
        InputAction Reflect = new InputAction(null, new Keys[] { Keys.X}, true);

        InputAction Escape = new InputAction(null, new Keys[] { Keys.Escape }, true);

        InputAction Flame = new InputAction(null, new Keys[] { Keys.F }, false);
        InputAction Aqua = new InputAction(null, new Keys[] { Keys.A }, false);
        InputAction Wind = new InputAction(null, new Keys[] { Keys.W }, false);
        InputAction SelectElement = new InputAction(null, new Keys[] { Keys.E }, false);

        public override void Activate(bool instancePreserved = false)
        {
            TransitionOffTime = new TimeSpan(0, 0, 3);
            BelongScreen.Screen = this;
            stage.Activate();
            if (GameState.IsExtraStage)
                stage.algorithm.StageNo = 99;
            shots = new Shots();
            enemies = new Enemies();
            me = new MyMachine();
            isPose = false;

            base.Activate(instancePreserved);
        }
        public override void Deactivate()
        {

            base.Deactivate();
        }

        public override void Unload()
        {

            base.Unload();
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            if (!isPose)
            {
                if (ScreenState == GameStateManagement.ScreenState.Active)
                {
                    #region 当たり判定
                    Shot[] copyS = new Shot[shots.shots.Count];
                    Enemy[] copyE = new Enemy[enemies.enemies.Count];
                    shots.shots.CopyTo(copyS);
                    enemies.enemies.CopyTo(copyE);
                    foreach (var itemS in shots.shots)
                    {
                        if (itemS.isMyShot)
                        {
                            foreach (var itemE in enemies.enemies)
                            {
                                if (Sprite.HitCheck(itemS, itemE))
                                {
                                    itemE.RecieveDamage(itemS);
                                    itemS.RecieveDamage(itemE);
                                }
                            }
                        }
                        else
                        {
                            if (Sprite.HitCheck(itemS, me) && me.HP > 0)
                            {
                                me.RecieveDamage(itemS);
                                itemS.RecieveDamage(me);
                            }
                        }
                    }
                    foreach (var itemE in enemies.enemies)
                    {
                        if (Sprite.HitCheck(me, itemE) && me.HP > 0)
                        {
                            me.RecieveDamage(itemE);
                        }
                    }
                    #endregion
                }

                stage.Update(gameTime);
                shots.Update(gameTime);
                enemies.Update(gameTime);
                me.Update(gameTime);
            }

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            PlayerIndex playerIndex;

            float move = 4.0f;
            if (Slow.Evaluate(input, ControllingPlayer, out playerIndex)) { move /= 2.0f; }
            if (Up.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                if (Right.Evaluate(input, ControllingPlayer, out playerIndex) || Left.Evaluate(input, ControllingPlayer, out playerIndex))
                {
                    me.Position -= new Vector2(0, move / 2.0f * 1.41421356f);
                }
                else
                {
                    me.Position -= new Vector2(0, move);
                }
            }
            if (Down.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                if (Right.Evaluate(input, ControllingPlayer, out playerIndex) || Left.Evaluate(input, ControllingPlayer, out playerIndex))
                {
                    me.Position += new Vector2(0, move / 2.0f * 1.41421356f);
                }
                else
                {
                    me.Position += new Vector2(0, move);
                }
            }
            if (Right.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                if (Up.Evaluate(input, ControllingPlayer, out playerIndex) || Down.Evaluate(input, ControllingPlayer, out playerIndex))
                {
                    me.Position += new Vector2(move / 2.0f * 1.41421356f, 0);
                }
                else
                {
                    me.Position += new Vector2(move, 0);
                }
            }
            if (Left.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                if (Up.Evaluate(input, ControllingPlayer, out playerIndex) || Down.Evaluate(input, ControllingPlayer, out playerIndex))
                {
                    me.Position -= new Vector2(move / 2.0f * 1.41421356f, 0);
                }
                else
                {
                    me.Position -= new Vector2(move, 0);
                }
            }

            // 位置修正
            if (me.Position.X < 16) { me.Position = new Vector2(16, me.Position.Y); }
            if (me.Position.Y < 16) { me.Position = new Vector2(me.Position.X, 16); }
            if (me.Position.X > 384) { me.Position = new Vector2(384, me.Position.Y); }
            if (me.Position.Y > 584) { me.Position = new Vector2(me.Position.X, 584); }

            //弾発射
            if (shotwait < 0 && me.HP > 0 && !GameState.IsExtraStage)
            {
                if (Shoot.Evaluate(input, ControllingPlayer, out playerIndex))
                {
                    if (Slow.Evaluate(input, ControllingPlayer, out playerIndex))
                    {
                        shots.Add(Shot.Kind.MyShot2, me.Element, me.Position - new Vector2(-8, 10), 90.0f, 5.0f, true);
                        shots.Add(Shot.Kind.MyShot2, me.Element, me.Position - new Vector2(0, 13), 90.0f, 5.0f, true);
                        shots.Add(Shot.Kind.MyShot2, me.Element, me.Position - new Vector2(8, 10), 90.0f, 5.0f, true);
                        shotwait = 0;
                    }
                    else
                    {
                        if (me.Element == Element.Flame)
                        {
                            shots.Add(Shot.Kind.MyShot1, Element.Flame, me.Position - new Vector2(0, 6), 80, 4.0f, true);
                            shots.Add(Shot.Kind.MyShot1, Element.Aqua, me.Position - new Vector2(-3 * 1.732f, -3), 80, 4.0f, true);
                            shots.Add(Shot.Kind.MyShot1, Element.Wind, me.Position - new Vector2(3 * 1.732f, -3), 80, 4.0f, true);
                            shots.Add(Shot.Kind.MyShot1, Element.Flame, me.Position - new Vector2(0, 6), 90, 4.0f, true);
                            shots.Add(Shot.Kind.MyShot1, Element.Aqua, me.Position - new Vector2(-3 * 1.732f, -3), 90, 4.0f, true);
                            shots.Add(Shot.Kind.MyShot1, Element.Wind, me.Position - new Vector2(3 * 1.732f, -3), 90, 4.0f, true);
                            shots.Add(Shot.Kind.MyShot1, Element.Flame, me.Position - new Vector2(0, 6), 100, 4.0f, true);
                            shots.Add(Shot.Kind.MyShot1, Element.Wind, me.Position - new Vector2(-3 * 1.732f, -3), 100, 4.0f, true);
                            shots.Add(Shot.Kind.MyShot1, Element.Aqua, me.Position - new Vector2(3 * 1.732f, -3), 100, 4.0f, true);

                        }
                        shotwait = 4;
                    }
                }
            }
            shotwait--;

            if (Escape.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                ScreenManager.AddScreen(new MainMenuScreen(), ControllingPlayer);
                stage.BGM.Stop();
                ScreenManager.RemoveScreen(this);
            }

            base.HandleInput(gameTime, input);
        }

        public override void Draw(GameTime gameTime)
        {
            stage.Draw(gameTime);

            enemies.Draw(gameTime);
            me.Draw(gameTime);
            shots.Draw(gameTime);
            accessory.Draw(gameTime);

            int enemyCount = 0;
            foreach (var item in enemies.enemies)
            {
                if (item.Position.X > 0 && item.Position.X < 400 && item.Position.Y > 0 && item.Position.Y < 600)
                    enemyCount++;
            }

            ScreenManager.SpriteBatch.Draw(Images.Migi, new Vector2(400, 0), Color.White);
            if (me.HP > 0)
                ScreenManager.SpriteBatch.DrawString(Fonts.MenuFont, ": " + Math.Ceiling(me.HP).ToString(), new Vector2(520, 200), Color.White);
            else
                ScreenManager.SpriteBatch.DrawString(Fonts.MenuFont, ": 0", new Vector2(520, 200), Color.White);
            ScreenManager.SpriteBatch.DrawString(Fonts.MenuFont, "HP", new Vector2(450, 200), Color.White);
            ScreenManager.SpriteBatch.DrawString(Fonts.MenuFont, "Enemy", new Vector2(450, 220), Color.White);
            ScreenManager.SpriteBatch.DrawString(Fonts.MenuFont, ": " + enemyCount.ToString(), new Vector2(520, 220), Color.White);
            ScreenManager.SpriteBatch.DrawString(Fonts.MenuFont, "Shot", new Vector2(450, 240), Color.White);
            ScreenManager.SpriteBatch.DrawString(Fonts.MenuFont, ": " + shots.shots.Count.ToString(), new Vector2(520, 240), Color.White);
            base.Draw(gameTime);
        }

        public void GameOver()
        {
            ScreenManager.AddScreen(new GameoverMenuScreen(this), ControllingPlayer);
            stage.BGM.Stop();
            isPose = true;
        }
    }
}
