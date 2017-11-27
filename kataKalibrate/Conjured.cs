namespace kataKalibrate
{
    public class Conjured : Product
    {
        public Conjured(string name, int sellin, int quality, int productType)
        {
            this.name = name;
            this.sellIn = sellin;
            this.quality = quality;
            this.productType = productType;
        }
        public override void Update()
        {
            this.sellIn = this.sellIn - 1;
            this.quality = this.quality - 2;
            CheckLimits();
        }
    }
}
