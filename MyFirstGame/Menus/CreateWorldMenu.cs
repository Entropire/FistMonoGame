using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyFirstGame.Objects.Gui;
using System.Collections.Generic;

namespace MyFirstGame.Menus
{
	internal class CreateWorldMenu : Menu
	{
		internal CreateWorldMenu(ContentManager content, MainGame game)
		{
			background = content.Load<Texture2D>("Gui/MainMenu_Background");

			SpriteFont font = content.Load<SpriteFont>("Gui/MenuFont");
			Texture2D buttonTexture = content.Load<Texture2D>("Gui/ButtonTexture");
			Texture2D buttonHoverTexture = content.Load<Texture2D>("Gui/HoverTexture");


			Label worldNameLabel = new Label(new Vector2(1400, 350), "World name", Color.Black, font);
			InputField worldName = new InputField(new Vector2(1400, 400), content.Load<Texture2D>("Gui/InputFieldTexture"), 
				new Vector2(10, 15), Color.Black, content.Load<SpriteFont>("Gui/MenuFont"), true, false);
			
			
			Label worldSeedLabel = new Label(new Vector2(1400, 650), "World Seed", Color.Black, font);
			InputField worldSeed = new InputField(new Vector2(1400, 700), content.Load<Texture2D>("Gui/InputFieldTexture"), 
				new Vector2(10, 15), Color.Black, content.Load<SpriteFont>("Gui/MenuFont"), false, true);
			
			
			
			Button createWorld = CreateButton("Create", new Vector2(1400, 1000), buttonTexture, buttonHoverTexture, font);
			createWorld.onClick = (item) =>
			{

			};
			
			Button singlePlayer = CreateButton("Return", new Vector2(1400, 1300), buttonTexture, buttonHoverTexture, font);
			singlePlayer.onClick = (item) =>
			{
				game.nextMenu = game.SinglePlayerMenu;
			};

			menuItems = new List<MenuItem>
			{
				worldNameLabel,
				worldName,
				worldSeedLabel,
				worldSeed,
				createWorld,
				singlePlayer
			};
		}
		
		private Button CreateButton(string buttonText, Vector2 position, Texture2D buttonTexture, Texture2D buttonHoverTexture, SpriteFont font)
		{
			Label buttonLabel = new Label(new Vector2(0, 0), buttonText, Color.Black, font);
			Button button = new Button(position, buttonTexture, buttonHoverTexture, buttonLabel);
            
			return button;
		}
		
		private Button CreateInputField(string buttonText, Vector2 position, Texture2D buttonTexture, Texture2D buttonHoverTexture, SpriteFont font, bool letters, bool numbers)
		{
			Label buttonLabel = new Label(new Vector2(0, 0), buttonText, Color.Black, font);
			Button button = new Button(position, buttonTexture, buttonHoverTexture, buttonLabel);
			
			return button;
		}
	}
}
