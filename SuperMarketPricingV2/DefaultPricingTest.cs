using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace SuperMarketPricingV2
{
    public class DefaultPricingTest
    {
        private DefaultPricing defaultPricing;
        [Fact]
        public void Should_calculate_price()
        {
            //Arrange
            Product Milk = new Product()
            {
                Name = "Milka",
                HasReduction = false,
                ByWeight = false,
                UnitaryPrice = 1.5M
            };
            defaultPricing = new DefaultPricing();
            int valueToBuy = 2;

            //Act
            var price= defaultPricing.CalculatePrice(Milk, valueToBuy);

            //Assert
            Assert.Equal(3,price);
        }
    }
}
