using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kataKalibrate
{
    class InvalidItem : Product
    {
        public InvalidItem(int productType)
        {
            this.name = "NO SUCH ITEM";
            this.sellIn = 0;
            this.quality = 0;
            this.productType = productType;
        }
        override public void Update()
        {
            // Nothing to do. Invalid items do not get updated.
        }
    }
}
