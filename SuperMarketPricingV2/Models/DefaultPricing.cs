using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketPricingV2
{
    public class DefaultPricing : IPricing
    {
        public decimal CalculatePrice(Product product, float numberBought)
        {
            return  product.UnitaryPrice * (decimal)numberBought;
        }
    }
}
