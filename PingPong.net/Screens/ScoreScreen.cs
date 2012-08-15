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

        bool _isScoreUpdating = false;

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
            _p1ScorePosition = new Vector2(graphics.GraphicsDevice.Viewport.Width / 4, graphics.GraphicsDevice.Viewport.Height / 2);
            _p2ScorePosition = new Vector2((graphics.GraphicsDevice.Viewport.Width / 4) * 3, graphics.GraphicsDevice.Viewport.Height / 2);
            
            
            base.LoadContent(content, graphics);
        }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (!_isScoreUpdating)
            {
                if (keyboardState.IsKeyDown(Keys.D1))
                {
                    _p1Score++;
                    _isScoreUpdating = true;
                }
                else if (keyboardState.IsKeyDown(Keys.D2))
                {
                    _p2Score++;
                    _isScoreUpdating = true;
                }
                else if (keyboardState.IsKeyDown(Keys.R))
                {
                    _p1Score = 0;
                    _p2Score = 0;
                    _isScoreUpdating = true;
                }
            }
            else
            {
                if (keyboardState.GetPressedKeys().Count() == 0)
                    _isScoreUpdating = false;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string p1Score = _p1Score.ToString("00");
            string p2Score = _p2Score.ToString("00");


            Vector2 textCenter = _textFont.MeasureString(p1Score) / 2;
            spriteBatch.DrawString(_textFont, p1Score, _p1ScorePosition, _textColor, 0, textCenter, 1f, SpriteEffects.None, 0);

            textCenter = _textFont.MeasureString(p2Score) / 2;
            spriteBatch.DrawString(_textFont, p2Score, _p2ScorePosition, _textColor, 0, textCenter, 1f, SpriteEffects.None, 0);
        }
    }
}
