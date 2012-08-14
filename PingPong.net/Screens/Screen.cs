// -----------------------------------------------------------------------
// <copyright file="Screen.cs">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PingPong
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Represents one screen in the Game
    /// </summary>
    public abstract class Screen
    {

        ChangeScreen _changeScreen;

        /// <summary>
        /// Creates a new screen with the specified name
        /// </summary>
        /// <param name="name">The name of the screen</param>
        /// <param name="changeScreen">A delegate that allows the screen to be changed</param>
        public Screen(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The name of the screen
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Loads content required for this screen
        /// </summary>
        /// <param name="content"></param>
        public abstract void LoadContent(ContentManager content, GraphicsDeviceManager graphics);

        /// <summary>
        /// Updates the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);


        /// <summary>
        /// Draws the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        /// <summary>
        /// Changes the current screen
        /// </summary>
        /// <param name="name"></param>
        protected void ChangeScreen(string name)
        {
            if (_changeScreen != null)
                _changeScreen(name);
        }
    }
}
