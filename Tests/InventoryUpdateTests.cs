using kataKalibrate;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InventoryUpdateTests
    {
        private const int minQuality = 0;
        private const int maxQuality = 50;
        [Test]
        public void QualityMaxLimit()
        {
            NormalItem item = new NormalItem("testItem", 1, 51, (int)Product.ProductType.NormalItem);
            item.Update();
            Assert.That(minQuality <= item.quality && item.quality <= maxQuality);
        }

        [Test]
        public void QualityMinLimit()
        {
            NormalItem item = new NormalItem("testItem", 1, -51, (int)Product.ProductType.NormalItem);
            item.Update();
            Assert.That(minQuality <= item.quality && item.quality <= maxQuality);
        }

        [Test]
        public void QualityConjured()
        {
            Conjured item = new Conjured("testItem", 2, 6, (int)Product.ProductType.Conjured);
            item.Update();
            Assert.That(item.quality.Equals(4));
        }

        [Test]
        public void Quality()
        {
            NormalItem item = new NormalItem("testItem", 1, 6, (int)Product.ProductType.NormalItem);
            item.Update();
            Assert.That(item.quality.Equals(5));
        }

        [Test]
        public void QualityWithSellInPastDate()
        {
            NormalItem item = new NormalItem("testItem", -1, 55, (int)Product.ProductType.NormalItem);
            item.Update();
            Assert.That(item.quality.Equals(50));
        }

    }
}
