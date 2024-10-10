using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyFirstGame.Objects.Gui;

internal class Panel : MenuItem
{
    internal Vector2 position;
    internal List<MenuItem> menuItems;
    internal Texture2D background;
    
    internal override void Update(GameTime gameTime)
    {

    }

    internal override void Draw(SpriteBatch spriteBatch)
    {
        
    }
}