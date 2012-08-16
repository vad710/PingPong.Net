// -----------------------------------------------------------------------
// <copyright file="TextBox.cs">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PingPong.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Allows the user to enter text via keyboard
    /// </summary>
    public class TextBox : IDraw
    {
        SpriteFont _font;
        Color _color;

        string _label;
        StringBuilder _theText = new StringBuilder();

        public TextBox(string label, SpriteFont font, Color color)
        {
            _label = label;
            _font = font;
            _color = color;
        }

        /// <summary>
        /// The position of the Textbox in the game screen
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Returns true if the text box has the user's focus
        /// </summary>
        public bool HasFocus { get; private set; }



        #region IDraw Members

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content, Microsoft.Xna.Framework.GraphicsDeviceManager graphics)
        {
            
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime, KeyboardHelper keyboard)
        {
            if (this.HasFocus)
            {
                var pressedKeys = keyboard.KeysPressedOnce(); //keyboardState.GetPressedKeys();

                foreach (var key in pressedKeys)
                {

                    switch (key)
                    {
                        case Keys.Back:
                            if (_theText.Length > 0)
                                _theText.Remove(_theText.Length-1, 1);
                            break;

                        case Keys.Space:
                            _theText.Append(' ');
                            break;
                        case Keys.A:
                            _theText.Append('A');
                            break;
                        case Keys.B:
                            _theText.Append('B');
                            break;
                        case Keys.C:
                            _theText.Append('C');
                            break;
                        case Keys.D:
                            _theText.Append('D');
                            break;
                        case Keys.E:
                            _theText.Append('E');
                            break;
                        case Keys.F:
                            _theText.Append('F');
                            break;
                        case Keys.G:
                            _theText.Append('G');
                            break;
                        case Keys.H:
                            _theText.Append('H');
                            break;
                        case Keys.I:
                            _theText.Append('I');
                            break;
                        case Keys.J:
                            _theText.Append('J');
                            break;
                        case Keys.K:
                            _theText.Append('K');
                            break;
                        case Keys.L:
                            _theText.Append('L');
                            break;
                        case Keys.M:
                            _theText.Append('M');
                            break;
                        case Keys.N:
                            _theText.Append('N');
                            break;
                        case Keys.O:
                            _theText.Append('O');
                            break;
                        case Keys.P:
                            _theText.Append('P');
                            break;
                        case Keys.Q:
                            _theText.Append('Q');
                            break;
                        case Keys.R:
                            _theText.Append('R');
                            break;
                        case Keys.S:
                            _theText.Append('S');
                            break;
                        case Keys.T:
                            _theText.Append('T');
                            break;
                        case Keys.U:
                            _theText.Append('U');
                            break;
                        case Keys.V:
                            _theText.Append('V');
                            break;
                        case Keys.W:
                            _theText.Append('W');
                            break;
                        case Keys.X:
                            _theText.Append('X');
                            break;
                        case Keys.Y:
                            _theText.Append('Y');
                            break;
                        case Keys.Z:
                            _theText.Append('Z');
                            break;
                        default:
                            break;
                    }

                    
                }
            }
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (this.HasFocus)
            {

                //TODO: Draw Blinking Cursor
            }


            spriteBatch.DrawString(_font, _label + _theText.ToString(), this.Position, _color,0f,Vector2.Zero,0.1f, SpriteEffects.None,0f);
        }

        #endregion

        /// <summary>
        /// Sets the focus on this control
        /// </summary>
        internal void SetFocus()
        {
            this.HasFocus = true;
        }

        internal void RemoveFocus()
        {
            this.HasFocus = false;
        }
    }
}
