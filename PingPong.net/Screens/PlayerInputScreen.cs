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

    /// <summary>
    /// Allows the user to enter in the name of the first and second players
    /// </summary>
    public class PlayerInputScreen : Screen
    {

        TextBox _player1Name;

        public PlayerInputScreen() : base("PlayerInput")
        {

        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content, Microsoft.Xna.Framework.GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);

            _player1Name = new TextBox(_textFont, _textColor);
            _player1Name.SetFocus();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            _player1Name.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            _player1Name.Draw(gameTime, spriteBatch);
        }
    }
}
