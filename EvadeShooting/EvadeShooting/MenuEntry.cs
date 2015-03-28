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
    public class MenuEntry
    {
        public string Text { set; get; }
        public MenuEntry Right { set; get; }
        public MenuEntry Left { set; get; }
        public MenuEntry Up { set; get; }
        public MenuEntry Down { set; get; }
        public Color TextColor { set; get; }
        public Vector2 Position { set; get; }
        public MenuScreen MenuScreen { set; get; }

        public MenuEntry(string text, Vector2 pos, MenuScreen menuScreen, Color textColor)
        {
            Text = text;
            Position = pos;
            MenuScreen = menuScreen;
            TextColor = textColor;
        }

        public void Draw()
        {
            MenuScreen.ScreenManager.SpriteBatch.DrawString(Fonts.MenuFont, Text, Position, TextColor);
        }
    }
}
