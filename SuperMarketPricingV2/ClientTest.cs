using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SuperMarketPricingV2
{
    public class ClientTest
    {
        public Client clt = new Client();
        readonly Product Milk = new Product()
        {
          Name="Milka",
          HasReduction = false,
          ByWeight = false,
          UnitaryPrice = 1.5M
        };
        readonly Product Tomato = new Product()
        {
            Name = "tomato",
            HasReduction = false,
            ByWeight = false,
            UnitaryPrice = 5
        };        
        [Fact]
        public void Add_Product_When_AddToCart()
        {   //Arrange
            clt.cart = new Dictionary<Product, float>();
            //act
            clt.AddToCart(Milk, 1);
            clt.AddToCart(Tomato, 1.5f);
            clt.AddToCart(Tomato, 1.5f);
            //Assert
            Assert.True(clt.cart.ContainsKey(Milk) && clt.cart[Tomato] == 3);
        }
        [Fact]
        public void Remove_Product_When_RemoveToCart()
        {   //Arrange
            clt.cart = new Dictionary<Product, float>();
            //act
            clt.AddToCart(Milk, 1);
            clt.AddToCart(Tomato, 3f);
            clt.RemoveFromCart(Tomato, 0.99f);
            clt.RemoveFromCart(Milk, 1);
            //Assert
            Assert.True(!clt.cart.ContainsKey(Milk) && clt.cart[Tomato] ==2.01f);
        }
    }
}
