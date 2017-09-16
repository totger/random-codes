using System;

namespace guessthenumber
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("--=*** Welcome to Guess The Number ***=-- ");
			bool startNewGame = true;
			while (startNewGame)
			{
				startNewGame = RunGame(startNewGame);
			}
		}

		private static bool RunGame(bool startNewGame)
		{
			int level;
			int storedNumber = 0;
			bool won = false;

			while (storedNumber == 0)
			{
				level = ChooseDifficutly();
				storedNumber = GetNumber(level);
			}
			int lives = SetLives();
			while (!won)
			{
				int guess = GetUserGuess(lives);
				won = Evaluate(guess, storedNumber, lives);
				if (!won)
				{
					lives--;
				}
				if (lives == 0)
					break;
			}
			Results(lives, storedNumber);
			return startNewGame = RestartGame();
		}

		private static bool RestartGame()
		{
			Console.Write("Do you want to play again? \n(Yes) - (No) " +
						   "\nType here:");
			string answer = Console.ReadLine();
			answer = answer.ToUpper();
			if (answer == "YES")
				return true;
			return false;
		}

		private static void Results(int lives, int storedNumber)
		{
			if (lives == 1)
			{
				Console.WriteLine("Congratulations, You won and " +
									  "have {0} life left!", lives);
			}

			else if (lives > 0)
			{
				Console.WriteLine("Congratulations, You won and " +
								  "have {0} lives left!", lives);
			}

			else
			{
				Console.WriteLine("** BAMMM, you are dead :( **" +
								  "\nMy number was: {0}", storedNumber);
			}
		}

		private static bool Evaluate(int guess, int number, int lives)
		{
			if (guess != number && lives == 1)
				return false;
			if (guess > number)
			{
				Console.WriteLine("My number is lower!");
				return false;
			}
			if (guess < number)
			{
				Console.WriteLine("My number is greater");
				return false;
			}
			return true;
		}

		private static int GetUserGuess(int lives)
		{
			Console.WriteLine("\nWhat's your guess? -- {0} lives left", lives);
			int guess = Convert.ToInt32(Console.ReadLine());
			return guess;
		}

		private static int GetNumber(int level)
		{
			int number;
			Random random = new Random();
			switch (level)
			{
				case 1:
					return number = random.Next(1, 101);

				case 2:
					return number = random.Next(1, 501);

				case 3:
					return number = random.Next(1, 1001);

				default:
					return number = 0;
			}
		}

		private static int SetLives()
		{
			Console.WriteLine("\nHow many lives do you give to yourself?");
			int lives = Convert.ToInt32(Console.ReadLine());
			return lives;
		}

		private static int ChooseDifficutly()
		{
			Console.WriteLine("\nPlease choose difficutly:");
			Console.WriteLine("1 - Easy: from 1 to 100" +
							  "\n2 - Medium: from 1 to 500" +
						  "\n3 - Hard: from 1 to 1000");
			Console.Write("Type 1, 2 or 3 and press ENTER:");
			int level = Convert.ToInt32(Console.ReadLine());
			return level;
		}
	}
}