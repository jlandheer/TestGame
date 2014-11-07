using Microsoft.Xna.Framework.Graphics;

namespace TestGame
{
   public abstract class Figure
   {
      public string Name { get; set; }
      public float X { get; set; }
      public float Y { get; set; }
      public Texture2D Sprite { get; set; }
   }
}