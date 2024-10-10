using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyFirstGame.Objects.Gui;
using System.Collections.Generic;

namespace MyFirstGame.Menus
{
    internal class SinglePlayerMenu : Menu
    {
        internal SinglePlayerMenu(ContentManager content, MainGame game)
        {
            background = content.Load<Texture2D>("Gui/MainMenu_Background");

            SpriteFont font = content.Load<SpriteFont>("Gui/MenuFont");
            Texture2D buttonTexture = content.Load<Texture2D>("Gui/ButtonTexture");
            Texture2D buttonHoverTexture = content.Load<Texture2D>("Gui/HoverTexture");
            
			Button WorldOne = CreateButton("world one", new Vector2(1400, 100), buttonTexture, buttonHoverTexture, font);
			WorldOne.onClick = (item) =>
			{
				
			};

			Button WorldTwo = CreateButton("world two", new Vector2(1400, 400), buttonTexture, buttonHoverTexture, font);
			WorldTwo.onClick = (item) =>
			{

			};
			
			Button worldThree = CreateButton("world three", new Vector2(1400, 700), buttonTexture, buttonHoverTexture, font);
			worldThree.onClick = (item) =>
			{

			};
			
			Button worldFour = CreateButton("world four", new Vector2(1400, 1000), buttonTexture, buttonHoverTexture, font);
			worldFour.onClick = (item) =>
			{

			};
			
			Button worldFive = CreateButton("world five", new Vector2(1400, 1300), buttonTexture, buttonHoverTexture, font);
			worldFive.onClick = (item) =>
			{

			};
			
            Button mainMenu = CreateButton("return", new Vector2(200, 1700), buttonTexture, buttonHoverTexture, font);
            mainMenu.onClick = (item) =>
            {
                game.nextMenu = game.mainMenu;
            };
            
            Button loadWorld = CreateButton("load", new Vector2(1400, 1700), buttonTexture, buttonHoverTexture, font);
            loadWorld.onClick = (item) =>
            {
                //game.nextMenu = game.SinglePlayerMenu;
            };
            
			Button createWorld = CreateButton("create", new Vector2(2600, 1700), buttonTexture, buttonHoverTexture, font);
			createWorld.onClick = (item) =>
			{
				game.nextMenu = game.CreateWorldMenu;
			};

			menuItems = new List<MenuItem>
            {
				WorldOne,
				WorldTwo,
				worldThree,
				worldFour,
				worldFive,
                mainMenu,
				loadWorld,
                createWorld
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