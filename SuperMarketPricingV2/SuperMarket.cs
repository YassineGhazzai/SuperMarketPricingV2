using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketPricingV2
{
    public class SuperMarket
    {
        public decimal Pricing(Client client)
        {
            decimal total=0;
            
            foreach (KeyValuePair<Product, float> item in client.cart)
            {
                Product productToCalulate = item.Key;
                float numberBought = item.Value;
                if (item.Key.HasReduction)
                    total += new PackagePricing().CalculatePrice(item.Key, item.Value);
                else if (!item.Key.ByWeight && (item.Value % 1 != 0))
                {
                    //error can't buy a part of an product
                }
                else
                    total += new DefaultPricing().CalculatePrice(item.Key, item.Value);                        
            }
            return total;
        }
        public void AddReduction(Product product, int numberToBuy, float reduction)
        {
            this.RemoveReductions(product);
            product.HasReduction=true;
            product.ReductionList = new Dictionary<int, float>
            {
                { numberToBuy, reduction }
            };
        }
        public void RemoveReductions(Product product)
        {
            if (product.HasReduction)
            {
                product.HasReduction = false;
                product.ReductionList =new Dictionary<int, float>();
            }
        }
    }
}
