// -----------------------------------------------------------------------
// <copyright file="ScoreScreen.cs">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PingPong.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// The Screen that displays the current score
    /// </summary>
    public class ScoreScreen : Screen
    {


        Vector2 _p1ScorePosition;
        Vector2 _p2ScorePosition;
        int _p1Score = 0;
        int _p2Score = 0;

        Vector2 _viewPortSize;

        Vector2 _p1NamePosition;
        Vector2 _p2NamePosition;
        Vector2 _p1NameSize;
        Vector2 _p2NameSize;

        /// <summary>
        /// Creates a new Score Screen
        /// </summary>
        /// <param name="name"></param>
        public ScoreScreen() : base("ScoreScreen")
        {
            //Should we make a singleton?
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            _viewPortSize = new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);

            _p1ScorePosition = new Vector2(_viewPortSize.X / 4, _viewPortSize.Y / 2);
            _p2ScorePosition = new Vector2((_viewPortSize.X / 4) * 3, _viewPortSize.Y / 2);

            base.LoadContent(content, graphics);
        }

        public override void Activate()
        {
            _p1NameSize = _textFont.MeasureString(Global.Player1Name);
            _p2NameSize = _textFont.MeasureString(Global.Player2Name);
            int buffer = 10;


            //TODO: Find a better way of dealing with different font sizes (ie scaling of 0.1 below and elsewhere)
            _p1NamePosition = new Vector2(_p1ScorePosition.X, _viewPortSize.Y - (_p1NameSize.Y * 0.1f) - buffer);
            _p2NamePosition = new Vector2(_p2ScorePosition.X, _viewPortSize.Y - (_p2NameSize.Y * 0.1f) - buffer);

            base.Activate();
        }

        public override void Update(GameTime gameTime, KeyboardHelper keyboard)
        {
            if (keyboard.KeyPressedOnce(Keys.D1))
                _p1Score++;

            if (keyboard.KeyPressedOnce(Keys.D2))
                _p2Score++;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string p1Score = _p1Score.ToString("00");
            string p2Score = _p2Score.ToString("00");


            Vector2 textCenter = _textFont.MeasureString(p1Score) / 2;
            spriteBatch.DrawString(_textFont, p1Score, _p1ScorePosition, _textColor, 0, textCenter, 1f, SpriteEffects.None, 0);

            textCenter = _textFont.MeasureString(p2Score) / 2;
            spriteBatch.DrawString(_textFont, p2Score, _p2ScorePosition, _textColor, 0, textCenter, 1f, SpriteEffects.None, 0);

            var p1Center = _p1NameSize / 2;
            spriteBatch.DrawString(_textFont, Global.Player1Name, _p1NamePosition, _textColor, 0f, p1Center, 0.1f, SpriteEffects.None, 0);

            var p2Center = _p2NameSize / 2;
            spriteBatch.DrawString(_textFont, Global.Player2Name, _p2NamePosition, _textColor, 0f, p2Center, 0.1f, SpriteEffects.None, 0);

        }
    }
}
