// -----------------------------------------------------------------------
// <copyright file="IDraw.cs" company="Microsoft">
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
    /// Defines an item that can draw itself
    /// </summary>
    public interface IDraw
    {
        /// <summary>
        /// Loads any resources that needs to be loaded from the ContentManager
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphics"></param>
        void LoadContent(ContentManager content, GraphicsDeviceManager graphics);

        /// <summary>
        /// Allows this object to Update itself
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);


        /// <summary>
        /// Allows this object to draw itself 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
