using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SuperMarketPricingV2
{
    public class SuperMarket
    {
        public decimal Pricing(Client client)
        {
            IPricing _pricing = new PackagePricingDecorator(new DefaultPricing());
            return  client.cart.Sum(x=> _pricing.CalculatePrice(x.Key, x.Value));             
        }
        public void AddReduction(Product product, int numberToBuy, float reduction)
        {
            RemoveReductions(product);
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
