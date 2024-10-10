using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Menu;
using MyFirstGame.Handlers;
using System.Collections.Generic;

namespace MyFirstGame.Objects.Gui
{
    internal class InputField : MenuItem
    {
        private Texture2D background;

        private string text;
        private Color color;
        private SpriteFont font;

        private bool Selected;
        private string curserText = "";
        private bool curserVisable;
        private double curserVisableSwtichTime = 0.8d;
        private double curserVisableSwitchTimer;

        private Vector2 size;
        private Vector2 padding;

        private List<Keys> allowedKeys;
        private List<Keys> weardKeys;

        internal InputField(Vector2 position, Texture2D background, Vector2 padding, Color color, SpriteFont font, bool allowCharacters, bool allowIntegers)
        {
            this.position = new Vector2(position.X * ScreenHandler.scale, position.Y * ScreenHandler.scale);
            this.padding = padding;
            this.background = background;
            this.color = color;
            this.font = font;

            size = new Vector2(background.Width, background.Height);

            allowedKeys = new List<Keys>();
            weardKeys = new List<Keys>();

            if (allowCharacters)
            {
                allowedKeys.AddRange(new List<Keys>()
                {
                    Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G,
                    Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N,
                    Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U,
                    Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.Space, Keys.Back
                });
            }

            if (allowIntegers)
            {
                allowedKeys.AddRange(new List<Keys>()
                {
                    Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.NumPad4, Keys.NumPad5,
                    Keys.NumPad6, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3,Keys.NumPad0,
                    Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5,
                    Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0,
                    Keys.Back
                });

                weardKeys.AddRange(new List<Keys>()
                {
                    Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5,
                    Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0
                });
            }
        }

        internal override void Update(GameTime gameTime)
        {
            Vector2 mousePos = Mouse.GetState().Position.ToVector2();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (mousePos.X > position.X &&
                    mousePos.X < position.X + size.X &&
                    mousePos.Y > position.Y &&
                    mousePos.Y < position.Y + size.Y)
                {
                    Selected = true;
                }
                else
                {
                    curserText = "";
                    Selected = false;
                }
            }

            if (Selected)
            {
                if (curserVisableSwitchTimer > curserVisableSwtichTime)
                {
                    curserVisableSwitchTimer = 0;
                    if (curserVisable)
                    {
                        curserText = "";
                        curserVisable = false;
                    }
                    else
                    {
                        curserText = "|";
                        curserVisable = true;
                    }
                }

                foreach (Keys key in Keyboard.GetState().GetPressedKeys())
                {
                    if (allowedKeys.Contains(key) && InputHandler.IsKeyPressed(key))
                    {
                        if (key == Keys.Back)
                        {
                            if (text != null)
                            {
                                int chracterToRemove = text.Length - 1;
                                text = text.Remove(chracterToRemove);
                            }
                        }
                        else if (key == Keys.Space)
                        {
                            text += " ";
                        }
                        else
                        {
                            if (weardKeys.Contains(key))
                            {
                                text += key.ToString().Replace("D", "");
                            }
                            else
                            {
                                if (InputHandler.capslockActive)
                                {
                                    text += key.ToString().ToUpper();
                                }
                                else
                                {
                                    text += key.ToString().ToLower();
                                }
                            }
                        }
                    }
                }
            }

            curserVisableSwitchTimer += gameTime.ElapsedGameTime.TotalSeconds;
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, position, null, Color.White, 0, Vector2.Zero, ScreenHandler.scale, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, text + curserText, position + padding, color);
        }
    }
}