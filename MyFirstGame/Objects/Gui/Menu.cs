using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyFirstGame.Handlers;

namespace MyFirstGame.Objects.Gui
{
    internal class Menu
    {
        internal List<MenuItem> menuItems;
        internal Texture2D background;

        internal void Update(GameTime gameTime)
        {
            foreach (MenuItem item in menuItems)
            {
                item.Update(gameTime);
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, null, Color.White, 0, Vector2.Zero, ScreenHandler.scale, SpriteEffects.None, 0);

            foreach (MenuItem item in menuItems)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
