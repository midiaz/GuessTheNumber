using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Play();
        }

        private static void Play()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("|           Hi! ..Welcome to Guess Number Game.                         |");
                Console.WriteLine("|   We must discover the secret number between 1 and 100.               |");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" - Lets Play!");
                Console.WriteLine(" - Type 'exit' if you want to exit game.");
                Console.WriteLine(" - Type 'me' if you want to choose a secret number and i will find it!. Or hit intro if you want to try to find my secret number.");
                Console.ForegroundColor = ConsoleColor.White;
                string line = Console.ReadLine();
                if (line == "exit")
                    break;
                else if (line == "me")
                    PlayGuessHumanNumber();
                else
                    PlayChooseSecretNumber();
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void PlayGuessHumanNumber()
        {
            Console.ForegroundColor = ConsoleColor.White;
            bool isBigger = false;
            int numberGuessed;
            int min = 1;
            int max = 100;
            Random random = new Random();

            while (true)
            {
                numberGuessed = random.Next(min, max);
                Console.Write($"Is {numberGuessed} your secret number?");
                string answer = Console.ReadLine();
                isBigger = false;
                if (Char.TryParse(answer, out char answerChar))
                {
                    if (answerChar == '=')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("I knew it! ...I'm freaking awsome!");
                        //Console.WriteLine("cls");
                        break;
                    }
                    else if (answerChar == '+')
                    {
                        Console.WriteLine("Humm... your number is bigger... i see..");
                        isBigger = true;
                    }
                    else if (answerChar == '-')
                        Console.WriteLine("Aja! ...your number is smoller");
                }

                if (isBigger)
                    min = ++numberGuessed;
                else
                    max = numberGuessed;
            }

        }

        private static void PlayChooseSecretNumber()
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Guess my number: ");
            while (true)
            {
                string line = Console.ReadLine();
                int numberFromRead;
                if (!Int32.TryParse(line, out numberFromRead) || numberFromRead == 0)
                {
                    Console.Write("Chose a number from 1 to 100... dont give up! ...guess my number: ");
                    continue;
                }
                if (numberFromRead < secretNumber)
                {
                    Console.Write("Try a bigger one...:");
                }
                else if (numberFromRead > secretNumber)
                {
                    Console.Write("Try a lower one...: ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Yhea! you got it...");
                    Console.WriteLine($"My secret number is {secretNumber}.");

                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
