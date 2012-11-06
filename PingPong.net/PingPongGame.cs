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
using PingPong.Screens;
using PingPong.Game_Data;

namespace PingPong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PingPongGame : Microsoft.Xna.Framework.Game
    {

        //TODO: Keep Track of who should serve
        //TODO: Get Player's Names and display on scoreboard
        //TODO: Keep Track of Score and persist so we can gather player stats

        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        ScreenManager _screenManager;

        KeyboardHelper _keyboard = new KeyboardHelper();

        //Vector2 _screenCenter;

        public PingPongGame()
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

            ///Creates the screen manager and adds screens
            _screenManager = new ScreenManager();
            _screenManager.Add(new StartScreen());
            _screenManager.Add(new PlayerInputScreen());
            _screenManager.Add(new ScoreScreen());

            
            _screenManager.LoadContent(this.Content, _graphics);

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

            _screenManager.Update(gameTime, _keyboard);

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

            //Draws the active screen
            _screenManager.Draw(gameTime, _spriteBatch);


            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }

    /// <summary>
    /// Temporary Class to allow for inter-screen communication
    /// </summary>
    public static class Global
    {
        //TODO: Remove the need for this class!
        public static string Player1Name;
        public static string Player2Name;
    }
}
