// -----------------------------------------------------------------------
// <copyright file="PlayerInputScreen.cs">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PingPong.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PingPong.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Allows the user to enter in the name of the first and second players
    /// </summary>
    public class PlayerInputScreen : Screen
    {

        TextBox _player1Name;
        TextBox _player2Name;

        public PlayerInputScreen() : base("PlayerInput")
        {

        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content, Microsoft.Xna.Framework.GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);            


            _player1Name = new TextBox(@"Player One's Name: ", _textFont, _textColor);
            _player1Name.Position = Vector2.Zero;
            _player1Name.SetFocus();
            
            _player2Name = new TextBox(@"Player Two's Name: ", _textFont, _textColor);
            _player2Name.Position = new Vector2(0, 150);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, KeyboardHelper keyboard)
        {
            bool enterPressed = keyboard.KeyPressedOnce(Keys.Enter);

            if (enterPressed && _player1Name.Text.Length > 0 && _player2Name.Text.Length > 0)
            {
                Global.Player1Name = _player1Name.Text;
                Global.Player2Name = _player2Name.Text;

                this.NextScreen();
                return;
            }


            bool switchFocus = keyboard.KeyPressedOnce(Keys.Tab) || enterPressed;

            if (switchFocus)
            {
                if (_player1Name.HasFocus)
                {
                    _player1Name.RemoveFocus();
                    _player2Name.SetFocus();
                }
                else if (_player2Name.HasFocus)
                {
                    _player2Name.RemoveFocus();
                    _player1Name.SetFocus();
                }
            }


            _player1Name.Update(gameTime, keyboard);
            _player2Name.Update(gameTime, keyboard);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            _player1Name.Draw(gameTime, spriteBatch);
            _player2Name.Draw(gameTime, spriteBatch);
        }
    }
}
