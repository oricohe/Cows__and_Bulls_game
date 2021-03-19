using System;

namespace BullsnCows
{
    class Program
    {
        //Returns list of digits of a number 
        public static int[] getDigits(int num)
            {
                int[] arr = new int[4];
                for (int i = 1; i <= arr.Length; i++)
                {
                    arr[arr.Length - i] = num % 10;
                    num /= 10;
                }
            return arr;
            }
        //Returns True if number(list) has no duplicate digits otherwise False  
        public static bool noDuplicates(int[] num_li)
        {
            for (int i = 0; i < num_li.Length; i++)
            {
                for (int d = 0; d < num_li.Length; d++)
                {
                    if (num_li[i] == num_li[d] && d != i)
                    {
                        return false;
                    }


                }
            }
            return true;
        }
        //Print the list
        static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
        //Generates a 4 digit number with no repeated digits
        public static int[] generateNum()
        {
            int[] num_il = new int[4];
            Random rnd = new Random();
            while (true)
            {
                for (int i = 0; i < num_il.Length; i++)
                {
                    num_il[i] = rnd.Next(0, 10);
                }
                if (!noDuplicates(num_il))
                {
                    return generateNum();
                }
                else
                {
                    return num_il;
                }
            }
        }
        //Returns common digits with exact matches(bulls) and the common digits in the wrong position(cows)
        public static int[] numOfBullsCows(int[] num_li, int[] guess_li)
        {
            int[] bull_cow = { 0, 0 };
            for (int i = 0; i < guess_li.Length; i++)
            {
                for (int a = 0; a < num_li.Length; a++)
                {
                    if (guess_li[i] == num_li[a])
                    {
                        bull_cow[1] += 1;
                    }
                }
            }
            for (int i = 0; i < guess_li.Length; i++)
            {
                if (num_li[i] == guess_li[i])
                {
                    bull_cow[0] += 1;
                }
            }
            bull_cow[1] -= bull_cow[0];
            return bull_cow;
        }
        //the all game
        static void Game(bool guide = true)
        {
            int[] num_li = generateNum();
            int[] bull_cow = new int[2];

            int guess;
            int times = 0;
            bool stop = false;
            if (guide)
            {
                Console.WriteLine("Hello, welcome to a vulnerable ball game.");
                Console.WriteLine("If you want to retire then guess what you will write 0");
            }
            //Play game until correct guess or till no tries left
            while (!stop)
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                times += 1;

                if (guess != 0)
                {
                    int[] guess_li = getDigits(guess);
                    if (!noDuplicates(guess_li))
                    {
                        Console.WriteLine("Number should not have repeated digits. Try again.");
                    }
                    if (guess_li[0] != 0 && guess < 1000 || guess > 9999)
                    {
                        Console.WriteLine("Enter 4 digit number only. Try again.");
                    }
                    bull_cow = numOfBullsCows(num_li, guess_li);
                    Console.WriteLine("Your Score is {0} bulls and {1} cows", bull_cow[0], bull_cow[1]);
                    if (bull_cow[0] == 4)
                    {
                        Console.WriteLine("You guessed right!");
                        Console.Write("The number was ");
                        Print(num_li);
                        Console.WriteLine();
                        Console.WriteLine("You made it in " + times + " times.");


                        stop = true;
                    }
                }
                else
                {
                    Console.WriteLine("Not bad, maybe next time.");
                    Console.WriteLine("The number was ");
                    Print(num_li);
                    Console.WriteLine();
                    stop = true;
                }
            }
            Console.Write("Do you want a new game?(y/n) ");
            string anser = Console.ReadLine();
            if (anser == "y" || anser == "Y"  || anser == "yes" || anser == "Yes")
            {
                Game(false);
            }
        }

        //Secret Code 
        static void Main(string[] args)
        {
            Game();
        }
    }
}
