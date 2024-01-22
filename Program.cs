using System.Runtime.CompilerServices;

public class DiceSimulator
{
    private Random r = new Random();

    public int[] SimulateRolls(int numRolls)
    {
        int[] results = new int[13]; // Results for dice totals 2-12

        for (int i = 0; i < numRolls; i++)
        {
            int die1 = r.Next(1, 7); // Roll first die
            int die2 = r.Next(1, 7); // Roll second die
            int total = die1 + die2;
            results[total]++;
        }

        return results;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the dice throwing simulator!\n");

        int numRolls = 0;
        bool isValidInput = false;
        while (!isValidInput)
        {
            Console.WriteLine("How many dice rolls would you like to simulate?");
            isValidInput = int.TryParse(Console.ReadLine(), out numRolls);

            if (!isValidInput || numRolls <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
                isValidInput = false; 
            }
        }

        DiceSimulator simulator = new DiceSimulator();
        int[] results = simulator.SimulateRolls(numRolls);

        // Print Results
        Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine("Total number of rolls = " + numRolls + ".");

        for (int i = 2; i < 13; i++)
        {
            double percentage = (double)results[i] / numRolls * 100;
            Console.WriteLine(i + ": " + new string('*', (int)percentage));
        }

        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }
}

