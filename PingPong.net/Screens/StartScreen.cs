// -----------------------------------------------------------------------
// <copyright file="StartScreen.cs">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PingPong.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// The initial screen when the game starts up
    /// </summary>
    public class StartScreen : Screen
    {
        string _startMessage = "   Accelrys PingPong\r\nPress Spacebar to Start";
        Vector2 _messageOrigin;

        public StartScreen() : base("StartScreen")
        {

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space))
                this.NextScreen();
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content, Microsoft.Xna.Framework.GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);


            ///Calculates the center of the string so it can be drawn in the middle of the screen during the draw call
            var messageSize = _textFont.MeasureString(_startMessage);
            _messageOrigin = new Vector2(messageSize.X / 2, messageSize.Y / 2);

        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_textFont, _startMessage, _screenCenter, _textColor, 0f, _messageOrigin, 0.1f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
        }
    }
}
