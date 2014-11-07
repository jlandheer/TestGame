using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace TestGame.Tests
{
   [TestFixture]
   public class PlayerTests
   {
      public class ActTests
      {
         [Test]
         public void NoOthersReturnsNullVector()
         {
            var player = new Celestial
            {
               Position = new Vector2(0, 0)
            };

            var res = player.Act(new List<Figure>());

            Assert.AreEqual(new Vector2(0, 0), res.Direction);
         }
         [Test]
         public void OneOtherReturnsDistance()
         {
            var player = new Celestial
            {
               Position = new Vector2(0, 0),
               Mass = 1
            };

            var res = player.Act(new List<Figure> { new Celestial { Position = new Vector2(20, 0), Mass = 1 } });

            Assert.AreEqual(new Vector2(0.0025f, 0), res.Direction);
         }
      }
   }
}
