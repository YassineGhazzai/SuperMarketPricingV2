using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SuperMarketPricingV2
{
    public class SuperMarketTest
    {

        private SuperMarket supermarket;
        [Fact] 
        public void Product_should_correctly_be_updated_when_reduction_set()
        {

            SuperMarket supermarket = new SuperMarket();
            Product milk = new Product()
            {
                Name = "Milka",
                HasReduction = false,
                ByWeight = false,
                UnitaryPrice = 1.5M
            };

            supermarket.AddReduction(milk, 2, 0.5f);

            Assert.True(milk.HasReduction);
            Assert.True(milk.ReductionList.ContainsKey(2));
            Assert.True(milk.ReductionList[2]== 0.5f);
        }

        [Fact]
    public void Product_reduction_should_correctly_be_replace_when_new_reduction_set()
        {
            supermarket = new SuperMarket();
            Product milk = new Product()
            {
                Name = "Milka",
                HasReduction = false,
                ByWeight = false,
                UnitaryPrice = 1.5M,
            };
            supermarket.AddReduction(milk, 10, 0.9f);

            supermarket.AddReduction(milk, 2, 0.5f);

            Assert.True(milk.HasReduction);
            Assert.True(milk.ReductionList.ContainsKey(2));
            Assert.True(milk.ReductionList[2] == 0.5f);
        }


        [Fact]
    public void Product_should_correctly_be_updated_when_reduction_removed()
        {

            supermarket = new SuperMarket();
            Dictionary<int, float> inputReductionList = new Dictionary<int, float>
            {
                { 2, 0.5f }
            };
            Product milk = new Product()
            {
                Name = "Milka",
                HasReduction = true,
                ByWeight = false,
                UnitaryPrice = 50M,
                ReductionList = inputReductionList
            };

            supermarket.RemoveReductions(milk);

            Assert.True(!milk.HasReduction);
            Assert.True(milk.ReductionList.Count ==0);
        }

        [Fact]
        public void Price_should_be_correct_when_calculating_bill()
        {
            supermarket = new SuperMarket();
            Client clt = new Client();
            Product milk = new Product()
            {
                Name = "Milka",
                HasReduction = false,
                ByWeight = false,
                UnitaryPrice = 50M
            };
            Product tomate = new Product()
            {
                Name = "Tomate",
                HasReduction = false,
                ByWeight = true,
                UnitaryPrice = 5M
            };
            Product shampoo = new Product()
            {
                Name = "Shampoo",
                HasReduction = false,
                ByWeight = false,
                UnitaryPrice = 10
            };
            clt.AddToCart(milk, 4);
            clt.AddToCart(tomate, 2.2f);
            clt.AddToCart(shampoo, 3);
            supermarket.AddReduction(shampoo, 2, 0.5f);
            
            Assert.True(supermarket.Pricing(clt) == 231.0M);
        }
    }
}
