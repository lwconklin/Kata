namespace kataKalibrate
{
    using System;
    public abstract class Product
    {
        public enum ProductType
        {
            AgedBrie = 1,
            BackstagePasses = 2,
            Sulfuras = 3,
            NormalItem = 4,
            InvalidItem = 5,
            Conjured = 6
        }

        public string name { get; set; }
        public int sellIn { get; set; }
        public int quality { get; set; }
        public  int productType { get; set; }

        public abstract void Update();

        public void CheckQualityLevel()
        {
            if(quality >= 50)
            {
                quality = 50;
            }

            if (quality < 0)
            {
                quality = 0;
            }
        }

        public void CheckPastSellInDate()
        {
            if (sellIn <= 0)
            {
                if (productType.Equals((int)Product.ProductType.Conjured))
                { // Degrade quality twice as fast if past sellin date.
                    quality = quality - 2; 
                }
                else
                {
                    quality = quality - (1 * Math.Abs(sellIn) * 2);
                }
            }
        }

        public void CheckLimits()
        {
            CheckPastSellInDate();
            CheckQualityLevel();
        }

    }
}
