using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyFirstGame.Handlers;

namespace MyFirstGame.Objects.Gui
{
    internal class Label : MenuItem
    {
        private string text;
        private Color color;
        private SpriteFont font;

        internal Label(Vector2 position, string text, Color color, SpriteFont font)
        {
            this.position = new Vector2(position.X * ScreenHandler.scale, position.Y * ScreenHandler.scale);
            this.text = text;
            this.color = color;
            this.font = font;
        }

        internal override void Update(GameTime gameTime)
        {

        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, color);
        }
    }
}
