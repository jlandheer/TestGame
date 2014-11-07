using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame
{
   public abstract class Figure
   {
      public string Name { get; set; }
      public Vector2 Position { get; set; }
      public Texture2D Sprite { get; set; }
      public abstract void Draw(SpriteBatch spriteBatch);
      public abstract Intent Act(IEnumerable<Figure> others);
   }
}