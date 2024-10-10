using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace MonoGame_Menu
{
    internal static class InputHandler
    {
        private static Dictionary<Keys, bool> currentKeyStates = new Dictionary<Keys, bool>();
        private static Dictionary<Keys, bool> previousKeyStates = new Dictionary<Keys, bool>();

        internal static bool capslockActive;

        private static bool LeftMouseButtonPressed;
        private static bool previousLeftMouseButtonState;

        internal static void LoadKeys()
        {
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                currentKeyStates.Add(key, false);
                previousKeyStates.Add(key, false);
            }
        }

        internal static void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();


            foreach (Keys key in currentKeyStates.Keys)
            {
                if (currentKeyStates[key])
                {
                    currentKeyStates[key] = false;
                }

                if (keyboardState.IsKeyDown(key) && previousKeyStates[key] == false)
                {
                    currentKeyStates[key] = true;
                }

                previousKeyStates[key] = keyboardState.IsKeyDown(key);
            }

            HandleLeftMouseButton();
            HandleCapslock();
        }

        internal static void HandleLeftMouseButton()
        {
            if (LeftMouseButtonPressed)
            {
                LeftMouseButtonPressed = false;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !previousLeftMouseButtonState)
            {
                LeftMouseButtonPressed = true;
            }

            previousLeftMouseButtonState = Mouse.GetState().LeftButton == ButtonState.Pressed;
        }

        private static void HandleCapslock()
        {
            if (IsKeyPressed(Keys.CapsLock))
            {
                capslockActive = !capslockActive;
            }
        }

        internal static bool IsLeftMouseButtonPressed()
        {
            return LeftMouseButtonPressed;
        }

        internal static bool IsKeyPressed(Keys key)
        {
            return currentKeyStates[key];
        }
    }
}
