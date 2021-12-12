using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketPricingV2
{
    public class DefaultPricing : Pricing
    {
        public override decimal CalculatePrice(Product product, float numberBought)
        {
            return  product.UnitaryPrice * (decimal)numberBought;
        }
    }
}
