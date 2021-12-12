using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketPricingV2
{
    public abstract class Pricing
    {
        public Product product;
        public abstract decimal CalculatePrice(Product product, float numberBought);
    }
}
