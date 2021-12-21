using System;
using System.Collections.Generic;

namespace SuperMarketPricingV2
{
    public class Client
    {
        public Dictionary<Product, float> cart = new Dictionary<Product, float>();
        public void AddToCart(Product product, float numberToBuy)
        {
            if(!product.ByWeight && (numberToBuy - (int)numberToBuy != 0))
                    throw new ArgumentException($"Error case: you cannot buy {numberToBuy} of a {product.Name}");
            if (cart.ContainsKey(product))
            {
                cart[product] = numberToBuy + cart[product];
            }
            else
            {
                cart.Add(product, numberToBuy);
            }

        }
        public void RemoveFromCart(Product product, float number)
        {
            if (cart.ContainsKey(product))
            {
                float numberInitial = cart[product];
                float result = numberInitial - number;
                if (result > 0)
                {
                    cart[product] = cart[product] - number;
                }
                else
                {
                    cart.Remove(product);
                }
            }
        }
    }
}
