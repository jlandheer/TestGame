using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame
{
   public class Mass : Figure
   {
      public override void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(Sprite, new Vector2(Position.X * Sprite.Width, Position.Y * Sprite.Height), null, null, null, 0.0f, Vector2.One, Color.White, SpriteEffects.None, LayerDepth.Figures);
      }

      public override Intent Act(IEnumerable<Figure> others)
      {
         var enumerable = others as IList<Figure> ?? others.ToList();
         var v = new Vector2(0, 0);
         if (enumerable.Any())
         {
            foreach (var figure in enumerable)
            {

               v += (this.Position - figure.Position);
            }
         }
         return new Intent { Direction = v };
      }
   }
}