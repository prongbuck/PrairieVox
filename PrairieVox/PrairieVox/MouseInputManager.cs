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
    public class MouseInputManager : Microsoft.Xna.Framework.GameComponent
    {
        MouseState oldMouseState, currentMouseState;

        public MouseInputManager(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            oldMouseState = currentMouseState = Mouse.GetState();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            base.Update(gameTime);
        }

        #region "helper functions"

        public void ShowCursor()
        {
            ((Game1)Game).IsMouseVisible = true;
        }

        public void HideCursor()
        {
            ((Game1)Game).IsMouseVisible = false;
        }

        public Point GetMouseMovement()
        {
            Point movement;

            movement.X = currentMouseState.X - oldMouseState.X;
            movement.Y = currentMouseState.Y - oldMouseState.Y;
           
            return movement;
        }

        public Point GetMousePosition()
        {
            Point position;

            position.X = currentMouseState.X;
            position.Y = currentMouseState.Y;

            return position;
        }

        public bool WasLeftButtonPressed()
        {
            // you'll probably want to call GetMousePosition() if this is true

            ButtonState curLeft = currentMouseState.LeftButton;
            ButtonState oldLeft = oldMouseState.LeftButton;

            if (curLeft.HasFlag(ButtonState.Pressed) && oldLeft.HasFlag(ButtonState.Released))
                return true;
            else
                return false;
        }

        public bool IsLeftButtonPressed()
        {
            // you'll probably want to call GetMousePosition() if this is true

            return currentMouseState.LeftButton.HasFlag(ButtonState.Pressed);                
        }

        public bool WasRightButtonPressed()
        {
            // you'll probably want to call GetMousePosition() if this is true

            ButtonState curRight = currentMouseState.RightButton;
            ButtonState oldRight = oldMouseState.RightButton;

            if (curRight.HasFlag(ButtonState.Pressed) && oldRight.HasFlag(ButtonState.Released))
                return true;
            else
                return false;
        }

        public bool IsRightButtonPressed()
        {
            // you'll probably want to call GetMousePosition() if this is true

            return currentMouseState.RightButton.HasFlag(ButtonState.Pressed);
        }        

#endregion

    }
}
