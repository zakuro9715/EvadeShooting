using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evade
{
    public class Effect : Sprite
    {
        public Effect()
        {
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            HP--;
            base.Update(gameTime);
        }
    }
}
