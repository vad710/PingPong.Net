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

        int _lastBlinkTime = 0;
        string _blinker = string.Empty;

        private const int _blinkSpeed = 400;

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
                        
                        case Keys.LeftShift:
                        case Keys.RightShift:
                            //ignore
                            break;

                        default:
                            _theText.Append(key.ToString().ToUpper());
                            break;
                    }

                    
                }
            }
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
            if (this.HasFocus)
            {
                _lastBlinkTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_lastBlinkTime > _blinkSpeed)
                {
                    _lastBlinkTime -= _blinkSpeed;

                    if (_blinker == string.Empty)
                        _blinker = "|";
                    else
                        _blinker = string.Empty;

                }
            }


            spriteBatch.DrawString(_font, string.Concat(_label , _theText.ToString(), _blinker), this.Position, _color,0f,Vector2.Zero,0.1f, SpriteEffects.None,0f);
        }

        #endregion

        /// <summary>
        /// Sets or Gets the value of the TextBox
        /// </summary>
        public string Text {
            get
            {
                return _theText.ToString();
            } 
            set
            {
                _theText = new StringBuilder(value);
            }
        }

        /// <summary>
        /// Sets the focus on this control
        /// </summary>
        internal void SetFocus()
        {
            this.HasFocus = true;
        }

        internal void RemoveFocus()
        {
            _blinker = string.Empty; //make sure the blinker is removed
            this.HasFocus = false;
        }
    }
}
