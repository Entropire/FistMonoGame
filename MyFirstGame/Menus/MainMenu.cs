using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyFirstGame.Objects.Gui;
using System.Collections.Generic;

namespace MyFirstGame.Menus
{
    internal class MainMenu : Menu
    {
        internal MainMenu(ContentManager content, MainGame game)
        {
            background = content.Load<Texture2D>("Gui/MainMenu_Background");

            SpriteFont font = content.Load<SpriteFont>("Gui/MenuFont");
            Texture2D buttonTexture = content.Load<Texture2D>("Gui/ButtonTexture");
            Texture2D buttonHoverTexture = content.Load<Texture2D>("Gui/HoverTexture");
            
            Button singlePlayer = CreateButton("SinglePlayer", new Vector2(1400, 700), buttonTexture, buttonHoverTexture, font);
            singlePlayer.onClick = (item) =>
            {
                game.nextMenu = game.SinglePlayerMenu;
            };
            
            Button multiPlayer = CreateButton("MultiPlayer", new Vector2(1400, 1000), buttonTexture, buttonHoverTexture, font);
            multiPlayer.onClick = (item) =>
            {
                game.nextMenu = game.MultiPlayerMenu;
            };
            
            Button settings = CreateButton("Settings", new Vector2(1400, 1300), buttonTexture, buttonHoverTexture, font);
            settings.onClick = (item) =>
            {
                game.nextMenu = game.SettingsMenu;
            };
            
            Button exit = CreateButton("Exit", new Vector2(1400, 1600), buttonTexture, buttonHoverTexture, font);
            exit.onClick = (item) =>
            {
                game.Exit();
            };

            menuItems = new List<MenuItem>
            {
                singlePlayer,
                multiPlayer,
                settings,
                exit
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