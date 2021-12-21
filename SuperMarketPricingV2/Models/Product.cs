using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketPricingV2
{
    public class Product
    {
        public string Name { get; set; }
        public bool ByWeight { get; set; }
        public bool HasReduction { get; set; }
        public Dictionary <int,float>ReductionList { get; set; }   
        public decimal UnitaryPrice { get; set; }
    }
}
