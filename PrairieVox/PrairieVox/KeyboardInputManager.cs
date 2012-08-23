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


namespace PrairieVox
{
    public class KeyboardInputManager : Microsoft.Xna.Framework.GameComponent
    {
        KeyboardState oldKeyboardState;
        KeyboardState currentKeyboardState;

        public KeyboardInputManager(Game game)
            : base(game)
        {            
        }

        public override void Initialize()
        {
            oldKeyboardState = currentKeyboardState = Keyboard.GetState(); 

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        public bool IsKeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        public bool IsKeyUp(Keys key)
        {
            return currentKeyboardState.IsKeyUp(key);
        }

        public bool WasKeyPressed(Keys key)
        {
            if (currentKeyboardState.IsKeyDown(key) && oldKeyboardState.IsKeyUp(key))
                return true;
            else
                return false;
        }

        public bool WasKeyReleased(Keys key)
        {
            if(currentKeyboardState.IsKeyUp(key) && currentKeyboardState.IsKeyDown(key))
                return true;
            else
                return false;
        }

    }
}
