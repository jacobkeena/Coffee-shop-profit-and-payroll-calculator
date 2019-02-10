using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreFeatures;

namespace CoffeeShop
{
    class Menu
    {
        Prices prices = new Prices();
        Totals ttls = new Totals();
        Pay pay = new Pay();
        public void DisplayMenu()
        {
            try
            {
                string title = "House Of Coffee";
                Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
                Console.WriteLine(title);
                Console.WriteLine("If you would like to . . . ");
                Console.WriteLine("Calculate todays revenue and cost of goods please enter 1\nCalculate this weeks payroll please enter 2\nExit please type 'exit'"); //enter choices
                string answer = Console.ReadLine();
                if (answer == "exit")
                {
                    return;
                }
                int choice = int.Parse(answer);
                GoToChoice(choice);
            }
            catch (FormatException)
            {
                Console.WriteLine("Hmm that option didn't seem to work...Please press enter and try again!");
                Console.ReadLine();
                Console.Clear();
                this.DisplayMenu();

            }
        }


        private void GoToChoice(int choice)
        {

                switch ((MenuOptions)choice)
                {
                    case MenuOptions.Calaculate:
                    //Calculates totals for all Coffee and Sandwiches and displays results to screen

                    Console.Clear();
                    try
                    {
                        Console.WriteLine("Enter the total amount sold for the following items . . . ");
                        //Small Coffee
                        Console.WriteLine("Small Coffees");
                        int a = int.Parse(Console.ReadLine());
                        ttls.CalculateCoffee(a, prices.CoffeeRetailPrices, prices.CoffeeCOG, Sizes.Small);

                        //Medium Coffee
                        Console.WriteLine("Medium Coffees");
                        int b = int.Parse(Console.ReadLine());
                        ttls.CalculateCoffee(b, prices.CoffeeRetailPrices, prices.CoffeeCOG, Sizes.Medium);

                        //Large Coffee
                        Console.WriteLine("Large Coffees");
                        int c = int.Parse(Console.ReadLine());
                        ttls.CalculateCoffee(c, prices.CoffeeRetailPrices, prices.CoffeeCOG, Sizes.Large);

                        //Egg Sandwich
                        Console.WriteLine("Egg Sandwiches");
                        int d = int.Parse(Console.ReadLine());
                        ttls.CalculateSandwich(d, prices.SandwichRetailPrices, prices.SandwichCOG, Sandwiches.EggSandwich);

                        //Chicken Sandwich
                        Console.WriteLine("Chicken Sandwiches");
                        int e = int.Parse(Console.ReadLine());
                        ttls.CalculateSandwich(e, prices.SandwichRetailPrices, prices.SandwichCOG, Sandwiches.ChickenSanwich);

                        //Totals
                        Console.Clear();
                        string title1 = "Totals entered";
                        Console.SetCursorPosition((Console.WindowWidth - title1.Length) / 2, Console.CursorTop);
                        Console.WriteLine(title1);
                        Console.WriteLine($"Coffee: \nSmall: [{a}]\nMedium: [{b}]\nLarge: [{c}]\n\n");
                        Console.WriteLine($"Coffee Daily Sales: {Totals.CoffeeGrossSales:c}");
                        Console.WriteLine($"Coffee Cost of Goods: {Totals.CoffeeeCostOfGoodsSold:c}");
                        Console.WriteLine($"Coffee Profit: {(Totals.CoffeeGrossSales - Totals.CoffeeeCostOfGoodsSold):c}\n\n");
                        Console.WriteLine($"Sandwiches: \nEgg Sandwich: [{d}]\nChicken Sandwich: [{e}]\n");
                        Console.WriteLine($"Sandwich Daily Sales: {Totals.SandwichGrossSales:c}\nSandwich Cost of Goods: {Totals.SandwichCostOfGoodsSold:c}" +
                            $"\nSandwich Profit: {(Totals.SandwichGrossSales - Totals.SandwichCostOfGoodsSold):c}");
                        Console.WriteLine($"\n\nTotal profit from today's sales: " +
                            $"[{((Totals.SandwichGrossSales - Totals.SandwichCostOfGoodsSold) + (Totals.CoffeeGrossSales - Totals.CoffeeeCostOfGoodsSold)):c}]");
                        Console.WriteLine($"\nTotal cost of goods from today's sales: " +
                            $"[{(Totals.SandwichCostOfGoodsSold + Totals.CoffeeeCostOfGoodsSold):c}]");

                        Console.ReadLine();
                    }
                    catch(FormatException fEx)
                    {
                        Console.WriteLine(fEx.Message + " Please press enter to try again or type exit to return to the main menu.");
                        string answer = Console.ReadLine();
                        if (answer == "exit")
                        {
                            DisplayMenu();
                        }
                        GoToChoice(1);

                    }
                    catch (OverflowException oEx)
                    {
                        Console.WriteLine(oEx.Message + " Please press enter to try again or type exit to return to the main menu.");
                        string answer = Console.ReadLine();
                        if (answer == "exit")
                        {
                            DisplayMenu();
                        }
                        GoToChoice(1);
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message + " Please press enter to try again or type exit to return to the main menu.");
                        string answer = Console.ReadLine();
                        if (answer == "exit")
                        {
                            DisplayMenu();
                        }
                        GoToChoice(1);
                    }
                        break;

                    // case 2

                   case MenuOptions.Payroll:
                    Console.Clear();
                    try
                    {


                        // Payroll stuff
                        String title2 = "Payroll";
                        Console.SetCursorPosition((Console.WindowWidth - title2.Length) / 2, Console.CursorTop);
                        Console.WriteLine(title2);
                        Console.WriteLine("Please enter the total hours worked this week for each employee.\n");

                        //Employee 1
                        Console.WriteLine("Employee 1:");
                        int emp1 = int.Parse(Console.ReadLine());
                        double emp1Pay = ttls.CalculatePayroll(emp1, pay.EmployeeHourly, Employee.employee);
                        double emp1Overtime = CalculateOvetime(emp1);

                        //Employee2
                        Console.WriteLine("Employee 2");
                        int emp2 = int.Parse(Console.ReadLine());
                        double emp2Pay = ttls.CalculatePayroll(emp2, pay.EmployeeHourly, Employee.employee);
                        double emp2Overtime = CalculateOvetime(emp2);

                        //Employee3
                        Console.WriteLine("Employee 3");
                        int emp3 = int.Parse(Console.ReadLine());
                        double emp3Pay = ttls.CalculatePayroll(emp3, pay.EmployeeHourly, Employee.employee);
                        double emp3Overtime = CalculateOvetime(emp3);

                        //Employee4
                        Console.WriteLine("Employee 4");
                        int emp4 = int.Parse(Console.ReadLine());
                        double emp4Pay = ttls.CalculatePayroll(emp4, pay.EmployeeHourly, Employee.employee);
                        double emp4Overtime = CalculateOvetime(emp4);

                        //Employee5
                        Console.WriteLine("Employee 5");
                        int emp5 = int.Parse(Console.ReadLine());
                        double emp5Pay = ttls.CalculatePayroll(emp5, pay.EmployeeHourly, Employee.employee);
                        double emp5Overtime = CalculateOvetime(emp5);



                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - title2.Length) / 2, Console.CursorTop);
                        Console.WriteLine(title2);
                        Console.WriteLine("Total Hours Entered:");

                        //Display Employee1
                        Console.WriteLine($"Employee 1 \nHours [{emp1}] " +
                            $"\nOvertime hours [{emp1Overtime}]" +
                            $"\nTotal earned: [{emp1Pay:c}]\n");

                        //Display Employee2
                        Console.WriteLine($"Employee 2 \nHours [{emp2}] " +
                            $"\nOvertime hours [{emp2Overtime}]" +
                            $"\nTotal earned: [{emp2Pay:c}]\n");


                        //Display Employee3
                        Console.WriteLine($"Employee 3 \nHours [{emp3}] " +
                            $"\nOvertime hours [{emp3Overtime}]" +
                            $"\nTotal earned: [{emp3Pay:c}]\n");


                        //Display Employee4
                        Console.WriteLine($"Employee 4 \nHours [{emp4}] " +
                            $"\nOvertime hours [{emp4Overtime}]" +
                            $"\nTotal earned: [{emp4Pay:c}]\n");


                        //Display Employee5
                        Console.WriteLine($"Employee 5 \nHours [{emp5}] " +
                            $"\nOvertime hours [{emp5Overtime}]" +
                            $"\nTotal earned: [{emp5Pay:c}]\n");


                        //Display Total Hours
                        Console.WriteLine($"Total amount paid this week: [{(emp1Pay + emp2Pay + emp3Pay + emp4Pay + emp5Pay):c}]");
                        Console.WriteLine($"Total overtime hours worked this week: [{(emp1Overtime + emp2Overtime + emp3Overtime + emp4Overtime + emp5Overtime):c}]");
                        Console.WriteLine("Please press enter when finished ...");
                        RestartMenu();
                        Console.ReadLine();
                    }

                    catch (FormatException fEx)
                    {
                        Console.WriteLine(fEx.Message + " Please press enter to try again or type exit to return to the main menu.");
                        string answer = Console.ReadLine();
                        if (answer == "exit")
                        {
                            DisplayMenu();
                        }
                        GoToChoice(1);

                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message + " Please press enter to try again or type exit to return to the main menu.");
                        string answer = Console.ReadLine();
                        if (answer == "exit")
                        {
                            DisplayMenu();
                        }
                        GoToChoice(1);
                    }
                    break;
                default:
                        Console.WriteLine("Hmm that option didn't seem to work. Please press enter and try again...");
                    Console.ReadLine();
                    Console.Clear();
                        DisplayMenu();
                        break;
                }
        }

        public double CalculateOvetime(double hours)
        {
            double overtime;
            if (hours > 40)
            {
                overtime = hours - 40;
                return overtime;
            }
            else
                return 0;
        }
        public void RestartMenu()
        {
            Console.WriteLine("\nRecalculate?\n\nType [y] to recalculate ...\nType[n] to return to main menu ...");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                GoToChoice(2);
            }
            else
                Console.Clear();
                DisplayMenu();
        }

    
    }
}
