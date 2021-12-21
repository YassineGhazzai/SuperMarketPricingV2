using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketPricingV2
{
    public interface IPricing
    {
        public abstract decimal CalculatePrice(Product product, float numberBought);
    }
}
