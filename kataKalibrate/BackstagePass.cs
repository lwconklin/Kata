using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kataKalibrate
{
    public class BackstagePass : Product
    {
        public BackstagePass(string name, int sellin, int quality, int productType)
        {
            this.name = name;
            this.sellIn = sellin;
            this.quality = quality;
            this.productType = productType;
        }
        override public void Update()
        {
            this.sellIn = this.sellIn - 1;
            if (this.sellIn < 11)
            {
                this.quality = this.quality + 2;
            }
            if (this.sellIn < 6)
            {
                this.quality = this.quality + 3;
            }
            if(sellIn <= 0)
            {
                this.quality = 0;
            }
            CheckLimits();
        }
    }
}
