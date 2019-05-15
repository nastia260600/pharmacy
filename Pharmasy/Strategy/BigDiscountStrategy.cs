using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmasy.Strategy
{
    class BigDiscountStrategy : BillingStrategy
    {
        public double getActualPrice(double rawPrice)
        {
            return 0.9 * rawPrice;
        }

    }
}
