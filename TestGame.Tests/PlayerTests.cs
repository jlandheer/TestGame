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
            var player = new Mass
            {
               Position = new Vector2(0, 0)
            };

            var res = player.Act(new List<Figure>());

            Assert.AreEqual(new Vector2(0, 0), res.Direction);
         }
         [Test]
         public void OneOtherReturnsDistance()
         {
            var player = new Mass
            {
               Position = new Vector2(0, 0)
            };

            var res = player.Act(new List<Figure> { new Mass { Position = new Vector2(20, 0) } });

            Assert.AreEqual(new Vector2(-20, 0), res.Direction);
         }
      }
   }
}
