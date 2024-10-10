using Microsoft.Xna.Framework;

namespace MyFirstGame.Handlers
{
    internal static class ScreenHandler
    {
        internal static float scale;

        private static int OriginalScreenWidth = 3840;
        private static int OriginalScreenHeight = 2160;

        internal static void SetScreenSize(GraphicsDeviceManager graphics , int width, int height, bool fullScreen)
        {
            float scaleX = (float)width / OriginalScreenWidth;
            float scaleY = (float)height / OriginalScreenHeight;

            scale = (scaleX + scaleY) / 2;

            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.IsFullScreen = fullScreen;
            graphics.ApplyChanges();
        }
    }
}