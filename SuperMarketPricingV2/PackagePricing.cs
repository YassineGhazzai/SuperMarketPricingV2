using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SuperMarketPricingV2
{
    public class PackagePricing : Pricing
    {
        public override decimal CalculatePrice(Product product, float numberBought)
        {
            int numberForReduction = product.ReductionList.FirstOrDefault().Key;
            int timesReductionApplied = (int)(numberBought / numberForReduction);
            float numberOfFullPriceGoods = numberBought % numberForReduction;
            float reductionValue = product.ReductionList.GetValueOrDefault(numberForReduction);  
            decimal reducedPrice = timesReductionApplied * product.UnitaryPrice * numberForReduction * (decimal)reductionValue;
            decimal unreducedPrice = (decimal)numberOfFullPriceGoods * product.UnitaryPrice;
            return reducedPrice + unreducedPrice;
        }
    }
}
