// -----------------------------------------------------------------------
// <copyright file="KeyboardHelper.cs">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PingPong
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Helper Class to determine when certain keys are only pressed once
    /// </summary>
    public class KeyboardHelper
    {

        HashSet<Keys> _keysPressedPreviously = new HashSet<Keys>();

        /// <summary>
        /// Returns true if the Key is pressed once
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyPressedOnce(Keys key)
        {
            var keyboardState = Keyboard.GetState();

            //First, lets check if the key was pressed down by the user
            if (keyboardState.IsKeyDown(key))
            {
                //The key was pressed, make sure it was not pressed previously
                if (!_keysPressedPreviously.Contains(key))
                {
                    _keysPressedPreviously.Add(key);
                    return true;
                }
            }

            //Check if the user let go of the key
            if (keyboardState.IsKeyUp(key))
                _keysPressedPreviously.Remove(key);

            return false;
        }

        /// <summary>
        /// Returns a list of keys pressed once
        /// </summary>
        /// <returns></returns>
        public Keys[] KeysPressedOnce()
        {
            var keyboardState = Keyboard.GetState();

            ///Gets all of the pressed keys
            var pressedKeys = keyboardState.GetPressedKeys();
            
            //remove keys that were pressed previously - this should give a list of only the newly pressed keys
            var newKeys = pressedKeys.Except(_keysPressedPreviously);

            var returnArray = newKeys.ToArray();
            

            //keys that were unpressed
            var removedKeys = _keysPressedPreviously.Except(pressedKeys).ToArray();

            //Remove all keys that were unpressed
            foreach (var removeKey in removedKeys)
            {
                _keysPressedPreviously.Remove(removeKey);
            }

            //Add all new keys to the previously pressed list
            foreach (var newKey in newKeys)
            {
                _keysPressedPreviously.Add(newKey);
            }


            
            return returnArray;
        }
    }
}
