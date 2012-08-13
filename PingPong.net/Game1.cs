using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PingPong.net
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        //TODO: Keep Track of who should serve
        //TODO: Get Player's Names and display on scoreboard
        //TODO: Keep Track of Score and persist so we can gather player stats

        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        SpriteFont _scoreFont;
        Vector2 _screenCenter;

        Vector2 _p1ScorePosition;
        Vector2 _p2ScorePosition;

        int _p1Score = 0;
        int _p2Score = 0;

        bool _isScoreUpdating = false;

        Color _scoreColor = Color.OrangeRed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _scoreFont = Content.Load<SpriteFont>("ScoreBoard");

            _p1ScorePosition = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 4, _graphics.GraphicsDevice.Viewport.Height / 2);
            _p2ScorePosition = new Vector2((_graphics.GraphicsDevice.Viewport.Width / 4)*3, _graphics.GraphicsDevice.Viewport.Height / 2);
            
            //_screenCenter = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, _graphics.GraphicsDevice.Viewport.Height / 2);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            string p1Score = _p1Score.ToString("00");
            string p2Score = _p2Score.ToString("00");
            

            Vector2 textCenter = _scoreFont.MeasureString(p1Score) / 2;
            _spriteBatch.DrawString(_scoreFont, p1Score, _p1ScorePosition, _scoreColor, 0, textCenter, 1f, SpriteEffects.None, 0);

            textCenter = _scoreFont.MeasureString(p2Score) / 2;
            _spriteBatch.DrawString(_scoreFont, p2Score, _p2ScorePosition, _scoreColor, 0, textCenter, 1f, SpriteEffects.None, 0);


            

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
