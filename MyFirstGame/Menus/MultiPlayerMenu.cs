using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyFirstGame.Objects.Gui;
using System.Collections.Generic;

namespace MyFirstGame.Menus
{
    internal class MultiPlayerMenu : Menu
    {
        internal MultiPlayerMenu(ContentManager content, MainGame game)
        {
            background = content.Load<Texture2D>("Gui/MainMenu_Background");

            SpriteFont font = content.Load<SpriteFont>("Gui/MenuFont");
            Texture2D buttonTexture = content.Load<Texture2D>("Gui/ButtonTexture");
            Texture2D buttonHoverTexture = content.Load<Texture2D>("Gui/HoverTexture");
            
			Button mainMenu = CreateButton("return", new Vector2(1400, 800), buttonTexture, buttonHoverTexture, font);
			mainMenu.onClick = (item) =>
			{
				game.nextMenu = game.mainMenu;
			};
			
			Button hostGame = CreateButton("Host game", new Vector2(1400, 1100), buttonTexture, buttonHoverTexture, font);
			hostGame.onClick = (item) =>
			{

			};

            Button joinGame = CreateButton("Join game", new Vector2(1400, 1400), buttonTexture, buttonHoverTexture, font);
            joinGame.onClick = (item) =>
            {
                
            };

            menuItems = new List<MenuItem>
            {
                mainMenu,
                hostGame,
                joinGame
            };
        }
        
        private Button CreateButton(string buttonText, Vector2 position, Texture2D buttonTexture, Texture2D buttonHoverTexture, SpriteFont font)
        {
	        Label buttonLabel = new Label(new Vector2(0, 0), buttonText, Color.Black, font);
	        Button button = new Button(position, buttonTexture, buttonHoverTexture, buttonLabel);
            
	        return button;
        }
    }
}
