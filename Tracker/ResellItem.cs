using System;

namespace Tracker
{
    public class ResellItem
    {
        public string Name { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public double Fees { get; set; }
        public double Shipping { get; set; }
        public DateTime Date { get; set; }

        public double Profit
        {
            get { return SellPrice - BuyPrice - Fees - Shipping; }
        }
    }
}