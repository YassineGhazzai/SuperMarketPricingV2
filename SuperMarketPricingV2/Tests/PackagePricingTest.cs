using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SuperMarketPricingV2
{
    public class PackagePricingTest
    {
        private PackagePricingDecorator packagePricing;
        Product Tomato = new Product()
        {
            Name = "tomato",
            HasReduction = true,
            ByWeight = true,
            UnitaryPrice = 50
        };
        [Theory]
        [InlineData(2,100)]
        [InlineData(3, 135)]
        [InlineData(4, 185)]
        [InlineData(6, 270)]

        public void Pricing_discounted_combinations_Products(float numberToBuy, decimal expectedPrice)
        {   //Promotion for 3 product bought the superMarket offer 10% reduction
            Dictionary<int, float> reductionList = new Dictionary<int, float>
            {
                { 3, 0.9f }
            };
            packagePricing = new PackagePricingDecorator(new DefaultPricing());
            Tomato.ReductionList = reductionList;
            Assert.Equal(expectedPrice, packagePricing.CalculatePrice(Tomato, numberToBuy));
        }
    }
}
