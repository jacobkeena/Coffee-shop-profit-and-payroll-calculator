
using System;

namespace StoreFeatures
{
    public struct Totals
    {
        public static double CoffeeGrossSales, CoffeeeCostOfGoodsSold, SandwichGrossSales, SandwichCostOfGoodsSold;


        public void CalculateCoffee(int numSold, double[] CoffeeRetailPrices, double[] CoffeeCOG, Sizes coffeeSize)
        {
            CoffeeGrossSales += CoffeeRetailPrices[(int)coffeeSize] * numSold;
            CoffeeeCostOfGoodsSold += CoffeeCOG[(int)coffeeSize] * numSold;
        }

        public void CalculateSandwich(int numSold, double[] SandwichRetailPrices, double[] SandwichCOG, Sandwiches sandwichType)
        {
            SandwichGrossSales += SandwichRetailPrices[(int)sandwichType] * numSold;
            SandwichCostOfGoodsSold += SandwichCOG[(int)sandwichType] * numSold;
        }

        public double CalculatePayroll(double ttlHours, double[] EmployeeHourly, Employee employee)
        {
            double ttlpay;
            if (ttlHours > 40)
            {
                double overtime = ttlHours - 40;
                double regular = ttlHours - overtime;
                ttlpay = (overtime * ((EmployeeHourly[(int)employee] / 2) + EmployeeHourly[(int)employee])) + (regular * EmployeeHourly[(int)employee]);
                return ttlpay;
            }
            else
                ttlpay = ttlHours * EmployeeHourly[(int)employee];
            return ttlpay;

        }


        //public Tuple<double,double> CalculateCoffee(int numSold, double[] CoffeeRetailPrices, double[] CoffeeCOG, sizes coffeeSize)
        //{
        //    double costOfGoods, grossRevenue;
        //    grossRevenue = CoffeeRetailPrices[(int)coffeeSize] * numSold;
        //    costOfGoods = CoffeeCOG[(int)coffeeSize] * numSold;

        //    return Tuple.Create(grossRevenue, costOfGoods);
        //}
    }
}