namespace kataKalibrate
{
    public class NormalItem :Product
    {
        public NormalItem(string name, int sellin, int quality, int productType)
        {
            this.name = name;
            this.sellIn = sellin;
            this.quality = quality;
            this.productType = productType;
        }
        override public void Update()
        {
            this.quality = this.quality - 1;
            this.sellIn = this.sellIn - 1;
            CheckLimits();
        }
    }
}
