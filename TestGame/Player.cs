using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame
{
   public class Player : Figure
   {
      public void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(Sprite, new Vector2(X * Sprite.Width, Y * Sprite.Height), null, null, null, 0.0f, Vector2.One, Color.White, SpriteEffects.None, LayerDepth.Figures);
      }

      public bool HandleInput(InputState inputState)
      {
         if (inputState.IsLeft(PlayerIndex.One))
         {
            X--;
            return true;
         }
         else if (inputState.IsRight(PlayerIndex.One))
         {
            X++;
            return true;
         }
         else if (inputState.IsUp(PlayerIndex.One))
         {
            Y--;
            return true;
         }
         else if (inputState.IsDown(PlayerIndex.One))
         {
            Y++;
            return true;
         }
         return false;
      }
   }
}