using Microsoft.Xna.Framework.Input;

namespace TestGame
{
   public class InputState
   {
      public GamePadState CurrentGamePadState;
      public KeyboardState CurrentKeyboardState;
      public bool GamePadWasConnected;

      public GamePadState LastGamePadState;
      public KeyboardState LastKeyboardState;

      public MouseState CurrentMouseState { get; private set; }
      public MouseState LastMouseState { get; private set; }

      public InputState()
      {
         CurrentMouseState = new MouseState();
         LastMouseState = new MouseState();

         GamePadWasConnected = false;
      }

      /// <summary>
      ///    Reads the latest state of the keyboard and gamepad.
      /// </summary>
      public void Update()
      {
         LastKeyboardState = CurrentKeyboardState;
         LastGamePadState = CurrentGamePadState;

         CurrentKeyboardState = Keyboard.GetState();
         CurrentGamePadState = GamePad.GetState(0);

         // Keep track of whether a gamepad has ever been
         // connected, so we can detect if it is unplugged.
         if (CurrentGamePadState.IsConnected)
         {
            GamePadWasConnected = true;
         }

         LastMouseState = CurrentMouseState;
         CurrentMouseState = Mouse.GetState();
      }

      public bool IsNewLeftMouseClick(out MouseState mouseState)
      {
         mouseState = CurrentMouseState;
         return (CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed);
      }

      public bool IsNewRightMouseClick(out MouseState mouseState)
      {
         mouseState = CurrentMouseState;
         return (CurrentMouseState.RightButton == ButtonState.Released && LastMouseState.RightButton == ButtonState.Pressed);
      }

      public bool IsNewThirdMouseClick(out MouseState mouseState)
      {
         mouseState = CurrentMouseState;
         return (CurrentMouseState.MiddleButton == ButtonState.Pressed && LastMouseState.MiddleButton == ButtonState.Released);
      }

      public bool IsNewMouseScrollUp(out MouseState mouseState)
      {
         mouseState = CurrentMouseState;
         return (CurrentMouseState.ScrollWheelValue > LastMouseState.ScrollWheelValue);
      }

      public bool IsNewMouseScrollDown(out MouseState mouseState)
      {
         mouseState = CurrentMouseState;
         return (CurrentMouseState.ScrollWheelValue < LastMouseState.ScrollWheelValue);
      }

      /// <summary>
      ///    Helper for checking if a key was newly pressed during this update. The
      ///    controllingPlayer parameter specifies which player to read input for.
      ///    If this is null, it will accept input from any player. When a keypress
      ///    is detected, the output playerIndex reports which player pressed it.
      /// </summary>
      public bool IsNewKeyPress(Keys key)
      {
         return (CurrentKeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key));
      }

      /// <summary>
      ///    Helper for checking if a button was newly pressed during this update.
      ///    The controllingPlayer parameter specifies which player to read input for.
      ///    If this is null, it will accept input from any player. When a button press
      ///    is detected, the output playerIndex reports which player pressed it.
      /// </summary>
      public bool IsNewButtonPress(Buttons button)
      {
         return (CurrentGamePadState.IsButtonDown(button) && LastGamePadState.IsButtonUp(button));
      }

      public bool IsKeyPressed(Keys key)
      {
         return (CurrentKeyboardState.IsKeyDown(key));
      }

      public bool IsButtonPressed(Buttons button)
      {
         return (CurrentGamePadState.IsButtonDown(button));
      }

      public bool IsExitGame()
      {
         return IsNewKeyPress(Keys.Escape) || IsNewButtonPress(Buttons.Back);
      }

      public bool IsLeft()
      {
         return IsNewKeyPress(Keys.Left) || IsNewButtonPress(Buttons.DPadLeft)
                || IsNewButtonPress(Buttons.LeftThumbstickLeft);
      }

      public bool IsRight()
      {
         return IsNewKeyPress(Keys.Right) || IsNewButtonPress(Buttons.DPadRight)
                || IsNewButtonPress(Buttons.LeftThumbstickRight);
      }

      public bool IsUp()
      {
         return IsNewKeyPress(Keys.Up) || IsNewButtonPress(Buttons.DPadUp)
                || IsNewButtonPress(Buttons.LeftThumbstickUp);
      }

      public bool IsDown()
      {
         return IsNewKeyPress(Keys.Down) || IsNewButtonPress(Buttons.DPadDown)
                || IsNewButtonPress(Buttons.LeftThumbstickDown);
      }

      public bool IsSpace()
      {
         return IsNewKeyPress(Keys.Space);
      }

      public bool IsScrollLeft()
      {
         return IsKeyPressed(Keys.A);
      }

      public bool IsScrollRight()
      {
         return IsKeyPressed(Keys.D);
      }

      public bool IsScrollUp()
      {
         return IsKeyPressed(Keys.W);
      }

      public bool IsScrollDown()
      {
         return IsKeyPressed(Keys.S);
      }

      public bool IsZoomOut()
      {
         return IsNewKeyPress(Keys.OemPeriod);
      }

      public bool IsZoomIn()
      {
         return IsNewKeyPress(Keys.OemComma);
      }
   }
}