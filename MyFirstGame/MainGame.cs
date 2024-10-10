using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Menu;
using MyFirstGame.Handlers;
using MyFirstGame.Menus;
using MyFirstGame.Objects.Gui;

namespace MyFirstGame
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //menus
        internal MainMenu mainMenu;
        internal SinglePlayerMenu SinglePlayerMenu;
        internal MultiPlayerMenu MultiPlayerMenu;
        internal SettingsMenu SettingsMenu;
        internal CreateWorldMenu CreateWorldMenu;

        internal Menu loadedMenu;
        internal Menu nextMenu;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            ScreenHandler.SetScreenSize(_graphics, screenWidth, screenHeight, false);

            mainMenu = new MainMenu(Content, this);
            SinglePlayerMenu = new SinglePlayerMenu(Content, this);
            MultiPlayerMenu = new MultiPlayerMenu(Content, this);
            SettingsMenu = new SettingsMenu(Content, this);
            CreateWorldMenu = new CreateWorldMenu(Content, this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            InputHandler.LoadKeys();

            loadedMenu = mainMenu;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            InputHandler.Update();

            if (nextMenu != null)
            {
                loadedMenu = nextMenu;
                nextMenu = null;
            }

            loadedMenu.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            loadedMenu.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}