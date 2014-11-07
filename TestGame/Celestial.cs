using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame
{
   public class Celestial : Figure
   {
      public const float G = 1f;

      public float Mass { get; set; }

      public override void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(Sprite, new Vector2(Position.X * Sprite.Width, Position.Y * Sprite.Height), null, null, null, 0.0f, Vector2.One, Color.White, SpriteEffects.None, LayerDepth.Figures);
      }

      public override Intent Act(IEnumerable<Figure> others)
      {
         var figures = others.Where(i => i is Celestial).Cast<Celestial>().ToList();
         var v = new Vector2(0, 0);
         foreach (var figure in figures)
         {
            var direction = (figure.Position- this.Position);
            var distanceSquared = direction.LengthSquared();
            direction.Normalize();
            var force = G * this.Mass * figure.Mass / distanceSquared;
            v = v + (direction * force);
         }
         return new Intent { Direction = v };
      }
   }
}