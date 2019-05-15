using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmasy.Strategy
{
    public class Bill
    {
        private static int FIRST_LIMIT = 300;
        private int mQuantity;

        public double getTotal(int quantity)
        {
            mQuantity = quantity;
            BillingStrategy strategy;
            if (mQuantity >= FIRST_LIMIT)
            {
                strategy = new BigDiscountStrategy();
            }
            else
            {
                strategy = new NormalStrategy();
            }
            return strategy.getActualPrice(mQuantity);
        }
    }
}
