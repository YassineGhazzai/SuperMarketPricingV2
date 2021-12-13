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
            decimal DiscountTotal = client.cart.Where(x => x.Key.HasReduction).Sum(x=> new PackagePricing().CalculatePrice(x.Key, x.Value));
            decimal totalwithoutDiscount = client.cart.Where(x => !x.Key.HasReduction).Sum(x => new DefaultPricing().CalculatePrice(x.Key, x.Value));
            return totalwithoutDiscount+ DiscountTotal;
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
