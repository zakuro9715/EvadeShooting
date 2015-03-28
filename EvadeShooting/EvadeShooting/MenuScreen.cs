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
    public class MenuScreen : GameScreen
    {
        protected List<MenuEntry> menuEntry;
        protected MenuEntry FaucsEntry;
        public SpriteFont Font;
        protected InputAction Up;
        protected InputAction Down;
        protected InputAction Right;
        protected InputAction Left;
        protected InputAction Select;
        protected InputAction Cancel;

        public override void Activate(bool instancePreserved = false)
        {
            Up = new InputAction(null, new Keys[] { Keys.Up }, true);
            Down = new InputAction(null, new Keys[] { Keys.Down }, true);
            Right = new InputAction(null, new Keys[] { Keys.Right }, true);
            Left = new InputAction(null, new Keys[] { Keys.Left }, true);
            Cancel = new InputAction(null, new Keys[] { Keys.Escape }, true);
            Select = new InputAction(null, new Keys[] { Keys.Space, Keys.Enter, Keys.Z }, true);
            this.TransitionOnTime = new TimeSpan(0, 0, 3);
            base.Activate(instancePreserved);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            FaucsEntry.TextColor = Color.Yellow;
            foreach (var item in menuEntry)
            {
                if (item != FaucsEntry) { item.TextColor = Color.White; }
            }

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var item in menuEntry)
            {
                item.Draw();
            }

            base.Draw(gameTime);
        }
    }

    public class MainMenuScreen : MenuScreen
    {
        MenuEntry startEntry;
        MenuEntry exitEntry;
        MenuEntry easyEntry;
        MenuEntry nomalEntry;
        MenuEntry hardEntry;
        MenuEntry evadeAllEntry;
        MenuEntry extraEntry;

        //InputAction DebugA;
        //InputAction DebugB;

        public override void Activate(bool instancePreserved = false)
        {
            //DebugA = new InputAction(null, new Keys[] { Keys.LeftShift }, false);
            //DebugB = new InputAction(null, new Keys[] { Keys.RightShift }, false);

            startEntry = new MenuEntry("StartGame", new Vector2(20, 40), this, Color.White);
            exitEntry = new MenuEntry("Exit", new Vector2(20, 80), this, Color.White);

            easyEntry = new MenuEntry("Easy", new Vector2(150, 40), this, Color.White);
            nomalEntry = new MenuEntry("Nomal", new Vector2(150, 60), this, Color.White);
            hardEntry = new MenuEntry("Hard", new Vector2(150, 80), this, Color.White);
            evadeAllEntry = new MenuEntry("EvadeAll", new Vector2(150, 100), this, Color.White);
            extraEntry = new MenuEntry("ExtraStage", new Vector2(150, 120), this, Color.White);

            FaucsEntry = startEntry;
            startEntry.Up = startEntry.Down = exitEntry;
            exitEntry.Up = exitEntry.Down = startEntry;

            easyEntry.Up = evadeAllEntry.Down = extraEntry;
            nomalEntry.Up = extraEntry.Down = easyEntry;
            hardEntry.Up = easyEntry.Down = nomalEntry;
            evadeAllEntry.Up = nomalEntry.Down = hardEntry;
            extraEntry.Up = hardEntry.Down = evadeAllEntry;

            easyEntry.Left = nomalEntry.Left = hardEntry.Left = evadeAllEntry.Left = extraEntry.Left = startEntry;
            startEntry.Right = easyEntry;

            menuEntry = new List<MenuEntry>();
            menuEntry.Add(startEntry);
            menuEntry.Add(exitEntry);



            base.Activate(instancePreserved);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            PlayerIndex playerIndex;
            if (Select.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                if (FaucsEntry == startEntry)
                {
                    menuEntry.Add(easyEntry);
                    menuEntry.Add(nomalEntry);
                    menuEntry.Add(hardEntry);
                    menuEntry.Add(evadeAllEntry);
                    menuEntry.Add(extraEntry);
                    FaucsEntry = easyEntry;
                }
                else if (FaucsEntry == easyEntry || FaucsEntry == nomalEntry || FaucsEntry == hardEntry || FaucsEntry == evadeAllEntry|| FaucsEntry == extraEntry)
                {
                    if (FaucsEntry == easyEntry)
                    {
                        GameState.Level = GameState.GameLevel.Easy;
                        GameState.isEvadeAll = false;
                        GameState.IsExtraStage = false;
                    }
                    else if (FaucsEntry == nomalEntry)
                    {
                        GameState.Level = GameState.GameLevel.Nomal;
                        GameState.isEvadeAll = false;
                        GameState.IsExtraStage = false;
                    }
                    else if (FaucsEntry == hardEntry)
                    {
                        GameState.Level = GameState.GameLevel.Hard;
                        GameState.isEvadeAll = false;
                        GameState.IsExtraStage = false;
                    }
                    else if (FaucsEntry == evadeAllEntry)
                    {
                        GameState.Level = GameState.GameLevel.Hard;
                        GameState.isEvadeAll = true;
                        GameState.IsExtraStage = false;
                    }
                    else if (FaucsEntry == extraEntry)
                    {
                        GameState.Level = GameState.GameLevel.Hard;
                        GameState.isEvadeAll = true;
                        GameState.IsExtraStage = true;
                    }
                    ScreenManager.AddScreen(new MainScreen(), ControllingPlayer);
                }
                else if (FaucsEntry == exitEntry)
                {
                    ScreenManager.Game.Exit();
                    this.ExitScreen();
                }
            }
            else if (Cancel.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                if (FaucsEntry == exitEntry) { ScreenManager.Game.Exit(); }
                else if (FaucsEntry == startEntry) { FaucsEntry = exitEntry; }
                else
                {
                    menuEntry.Remove(easyEntry);
                    menuEntry.Remove(nomalEntry);
                    menuEntry.Remove(hardEntry);
                    menuEntry.Remove(evadeAllEntry);
                    menuEntry.Remove(extraEntry);
                    FaucsEntry = startEntry;
                }
            }
            //else if (DebugA.Evaluate(input, ControllingPlayer, out playerIndex) && DebugB.Evaluate(input, ControllingPlayer, out playerIndex))
            //{
            //    GameState.isDebugMode = true;
            //    GameState.IsExtraStage = true;
            //    Sounds.bom01.Play();
            //}

            if (Up.Evaluate(input, ControllingPlayer, out playerIndex)) { FaucsEntry = FaucsEntry.Up; }
            if (Down.Evaluate(input, ControllingPlayer, out playerIndex)) { FaucsEntry = FaucsEntry.Down; }
            if (Right.Evaluate(input, ControllingPlayer, out playerIndex) && FaucsEntry.Right != null)
            {
                menuEntry.Add(easyEntry);
                menuEntry.Add(nomalEntry);
                menuEntry.Add(hardEntry);
                menuEntry.Add(evadeAllEntry);
                menuEntry.Add(extraEntry);
                FaucsEntry = easyEntry;
            }
            if (Left.Evaluate(input, ControllingPlayer, out playerIndex) && FaucsEntry.Left != null)
            {
                menuEntry.Remove(easyEntry);
                menuEntry.Remove(nomalEntry);
                menuEntry.Remove(hardEntry);
                menuEntry.Remove(evadeAllEntry);
                menuEntry.Remove(extraEntry);
                FaucsEntry = startEntry;
            }

            base.HandleInput(gameTime, input);
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(new Color(5, 10, 50));

            ScreenManager.SpriteBatch.DrawString(Fonts.TitleFont, "Evade Shooting", new Vector2(410, 310) - Fonts.TitleFont.MeasureString("Evade Shooting") / 2, Color.DarkBlue);
            ScreenManager.SpriteBatch.DrawString(Fonts.TitleFont, "Evade Shooting", new Vector2(400, 300) - Fonts.TitleFont.MeasureString("Evade Shooting") / 2, Color.Blue);
            base.Draw(gameTime);
        }
    }

    public class GameoverMenuScreen : MenuScreen
    {
        MenuEntry continueEntry;
        MenuEntry BackEntry;
        MenuEntry exitEntry;
        GameScreen screen;

        public GameoverMenuScreen(GameScreen screen)
        {
            this.screen = screen;
        }

        public override void Activate(bool instancePreserved = false)
        {

            TransitionOnTime = new TimeSpan(0, 0, 5);

            continueEntry = new MenuEntry("Charange again", new Vector2(20, 40), this, Color.White);
            BackEntry = new MenuEntry("Back to Title", new Vector2(20, 80), this, Color.White);
            exitEntry = new MenuEntry("Exit", new Vector2(20, 120), this, Color.White);
            FaucsEntry = continueEntry;
            continueEntry.Up = BackEntry.Down = exitEntry;
            BackEntry.Up = exitEntry.Down = continueEntry;
            exitEntry.Up = continueEntry.Down = BackEntry;

            menuEntry = new List<MenuEntry>();
            menuEntry.Add(continueEntry);
            menuEntry.Add(BackEntry);
            menuEntry.Add(exitEntry);

            base.Activate(instancePreserved);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            if (ScreenState == GameStateManagement.ScreenState.Active)
            {
                PlayerIndex playerIndex;
                if (Select.Evaluate(input, ControllingPlayer, out playerIndex))
                {
                    if (FaucsEntry == continueEntry)
                    {
                        screen.Activate();
                    }
                    else if (FaucsEntry == BackEntry)
                    {
                        screen.ExitScreen();
                        GameState.isEvadeAll = false;
                        ScreenManager.AddScreen(new MainMenuScreen(), ControllingPlayer);
                    }
                    else if (FaucsEntry == exitEntry) { ScreenManager.Game.Exit(); }
                    this.ExitScreen();
                }
                else if (Cancel.Evaluate(input, ControllingPlayer, out playerIndex))
                {
                    if (FaucsEntry == exitEntry) { ScreenManager.Game.Exit(); }
                    else { FaucsEntry = exitEntry; }
                }

                if (Up.Evaluate(input, ControllingPlayer, out playerIndex)) { FaucsEntry = FaucsEntry.Up; }
                if (Down.Evaluate(input, ControllingPlayer, out playerIndex)) { FaucsEntry = FaucsEntry.Down; }

            }
            base.HandleInput(gameTime, input);
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.SpriteBatch.Draw(Images.GameOver, Vector2.Zero, Color.White * TransitionAlpha);
            ScreenManager.SpriteBatch.DrawString(Fonts.TitleFont, "GameOver", new Vector2(410, 310) - Fonts.TitleFont.MeasureString("GameOver") / 2, Color.DarkRed * TransitionAlpha);
            ScreenManager.SpriteBatch.DrawString(Fonts.TitleFont, "GameOver", new Vector2(400, 300) - Fonts.TitleFont.MeasureString("GameOver") / 2, Color.Red * TransitionAlpha);

            if(ScreenState==GameStateManagement.ScreenState.Active)
                base.Draw(gameTime);
        }
    }
    
    public class GameclearMenuScreen : MenuScreen
    {
        MenuEntry backEntry;
        MenuEntry exitEntry;

        public override void Activate(bool instancePreserved = false)
        {

            TransitionOnTime = new TimeSpan(0, 0, 5);

                backEntry = new MenuEntry("Back to Title", new Vector2(20, 40), this, Color.White);
                exitEntry = new MenuEntry("Exit", new Vector2(20, 80), this, Color.White);

                backEntry.Up = backEntry.Down = exitEntry;
                exitEntry.Up = exitEntry.Down = backEntry;
                FaucsEntry = backEntry;
            


            menuEntry = new List<MenuEntry>();
            menuEntry.Add(backEntry);
            menuEntry.Add(exitEntry);

            base.Activate(instancePreserved);
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            PlayerIndex playerIndex;
            if (Select.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                if (FaucsEntry == backEntry)
                {
                    ScreenManager.AddScreen(new MainMenuScreen(), ControllingPlayer);
                    GameState.isEvadeAll = false;
                }
                else if (FaucsEntry == exitEntry) { ScreenManager.Game.Exit(); }
                this.ExitScreen();
            }
            else if (Cancel.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                if (FaucsEntry == exitEntry) { ScreenManager.Game.Exit(); }
                else { FaucsEntry = exitEntry; }
            }

            if (Up.Evaluate(input, ControllingPlayer, out playerIndex)) { FaucsEntry = FaucsEntry.Up; }
            if (Down.Evaluate(input, ControllingPlayer, out playerIndex)) { FaucsEntry = FaucsEntry.Down; }

            base.HandleInput(gameTime, input);
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.SpriteBatch.Draw(Images.GameClear, Vector2.Zero, Color.White * TransitionAlpha);
            if (GameState.isEvadeAll)
            {
                ScreenManager.SpriteBatch.DrawString(Fonts.TitleFont, "Congratulations", new Vector2(410, 310) - Fonts.TitleFont.MeasureString("Congratulations") / 2, Color.DarkBlue * TransitionAlpha);
                ScreenManager.SpriteBatch.DrawString(Fonts.TitleFont, "Congratulations", new Vector2(400, 300) - Fonts.TitleFont.MeasureString("Congratulations") / 2, Color.Blue * TransitionAlpha);
                ScreenManager.SpriteBatch.DrawString(Fonts.AccessoryFont, "You  evated all shots and enemies.\nThank you for playing!", new Vector2(360, 320), Color.Blue * TransitionAlpha);
            }
            else
            {
                ScreenManager.SpriteBatch.DrawString(Fonts.TitleFont, "GameClear", new Vector2(410, 310) - Fonts.TitleFont.MeasureString("GameClear") / 2, Color.DarkBlue * TransitionAlpha);
                ScreenManager.SpriteBatch.DrawString(Fonts.TitleFont, "GameClear", new Vector2(400, 300) - Fonts.TitleFont.MeasureString("GameClear") / 2, Color.Blue * TransitionAlpha);
            }

            if(ScreenState==GameStateManagement.ScreenState.Active)
                base.Draw(gameTime);
        }
    }
}
