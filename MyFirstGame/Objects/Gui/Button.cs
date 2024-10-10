using MyFirstGame.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MonoGame_Menu;

namespace MyFirstGame.Objects.Gui
{
    
    internal class Button : MenuItem
    {
        internal Action<Button> onClick;
        
        private Label label;
        private Texture2D buttonTexture;
        private Texture2D buttonHoverTexture;
        private Texture2D textureToUse;
        private Vector2 size;

        internal Button(Vector2 position, Texture2D buttonTexture, Texture2D buttonHoverTexture, Label label)
        {
            this.position = new Vector2(position.X * ScreenHandler.scale, position.Y * ScreenHandler.scale);
            this.buttonTexture = buttonTexture;
            this.buttonHoverTexture = buttonHoverTexture;
            textureToUse = buttonTexture;
            size = new Vector2(buttonTexture.Width * ScreenHandler.scale, buttonTexture.Height * ScreenHandler.scale);
            this.label = label;
            this.label.position = this.position;
        }

        internal override void Update(GameTime gameTime)
        {
            Vector2 mousePosition = Mouse.GetState().Position.ToVector2();

            if (mousePosition.X > position.X &&
                mousePosition.X < position.X + size.X &&
                mousePosition.Y > position.Y &&
                mousePosition.Y < position.Y + size.Y)
            {
                textureToUse = buttonHoverTexture;
                if (InputHandler.IsLeftMouseButtonPressed())
                {
                    onClick?.Invoke(this);
                }
            }
            else
            {
                textureToUse = buttonTexture;
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureToUse, position, null, Color.White, 0, Vector2.Zero, ScreenHandler.scale, SpriteEffects.None, 0);
            label.Draw(spriteBatch);
        }
    }
}