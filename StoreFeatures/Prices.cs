namespace StoreFeatures
{

    // Price, Cost, Payrate Arrays

    public class Prices
    {

        public double[] CoffeeRetailPrices = { 1.00, 3.00, 5.00};
        public double[] SandwichRetailPrices = { 5.50, 7.50 };
        public double[] CoffeeCOG = { .10,.15,.20 };
        public double[] SandwichCOG = { .95, 1.20 };
    }

    public class Pay
    {
        public double[] EmployeeHourly = { 12.50 };

    }

    // Enumerations 

    public enum Sizes { Small, Medium, Large }
    public enum Sandwiches { EggSandwich, ChickenSanwich }
    public enum MenuOptions { Calaculate = 1, Payroll, Exit }
    public enum Employee { employee}
}

