// -----------------------------------------------------------------------
// <copyright file="ScreenManager.cs">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PingPong
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Managers different screens in the game
    /// </summary>
    public class ScreenManager
    {
        private Dictionary<string, Screen> _screens = new Dictionary<string, Screen>();
        private Screen _activeScreen;

        /// <summary>
        /// Adds a new screen to the screen manager
        /// </summary>
        /// <param name="screen"></param>
        public void Add(Screen screen)
        {
            _screens.Add(screen.Name, screen);
            //TODO: Need to hookup delegate to change screen
        }

        /// <summary>
        /// Loads the contents for all of the screens
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            foreach (var screen in _screens.Values)
            {
                screen.LoadContent(content, graphics);
            }
        }

        /// <summary>
        /// Draws the Active Screen
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.ActiveScreen.Draw(gameTime, spriteBatch);
        }


        /// <summary>
        /// Updates the Active Screen
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            this.ActiveScreen.Update(gameTime);
        }

        /// <summary>
        /// Returns the active screen
        /// </summary>
        protected Screen ActiveScreen
        {
            get
            {
                if (_activeScreen == null && _screens.Count > 0)
                    _activeScreen = _screens.Values.First();

                return _activeScreen;
            }
        }


    }

    /// <summary>
    /// Delegate that changes the current screen
    /// </summary>
    /// <param name="name"></param>
    public delegate void ChangeScreen(string name);
}
