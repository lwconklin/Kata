namespace kataKalibrate
{
    public class Sulfuras : Product
    {
        public Sulfuras(string name, int sellin, int quality, int productType)
    {
        this.name = name;
        this.sellIn = sellin;
        this.quality = quality;
        this.productType = productType;
    }
    override public void Update()
    {
            // Nothing to do. Product doesn't sell or go out of date.
    }    
        
    }
}
