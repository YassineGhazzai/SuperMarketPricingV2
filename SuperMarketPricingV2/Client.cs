using System.Collections.Generic;

namespace SuperMarketPricingV2
{
    public class Client
    {
        public Dictionary<Product, float> cart = new Dictionary<Product, float>();
        public void AddToCart(Product product, float number)
        {
            if (cart.ContainsKey(product))
            {
                cart[product] = number + cart[product];
            }
            else
            {
                cart.Add(product, number);
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
