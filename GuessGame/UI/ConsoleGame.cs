using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessGame.Logic;

namespace GuessGame.UI
{
	public class ConsoleGame
	{
		private readonly GuessGameLogic _logic = new GuessGameLogic();

		public void Start()
		{
			while (true)
			{
				Console.WriteLine("Welcome to the game ‘Guess the number'!");
				Console.WriteLine("Select difficulty level: 1(Easy), 2(Medium), 3(Difficult)");
				Console.Write("Your choice: ");
				int.TryParse(Console.ReadLine(), out int userChoice);

				_logic.StartNewGame(userChoice);


				while (true)
				{
					Console.Write("Enter your guess: ");
					int.TryParse(Console.ReadLine(), out int guess);


					string result = _logic.MakeGuess(guess);

					if (result == "TooLow")
					{
						Console.WriteLine("Too low!");
					}
					else if (result == "TooHigh")
					{
						Console.WriteLine("Too high!");
					}
					else if (result == "YouLost")
					{
						int secret = _logic.GetSecretNumber();
						Console.WriteLine($"You lost! The secret number was {secret}.");
						break;
					}
					else if (result == "Correct")
					{
						List<int> records = _logic.GetRecords();
						Console.WriteLine("Congratulations! You guessed the number!");
						Console.WriteLine($"Top records: {string.Join(", ", records)}");
						break;
					}
				}


				Console.Write("Do you want to play again? (yes/no): ");
				string again = Console.ReadLine().ToLower();
				if (again != "yes")
				{
					Console.WriteLine("Thanks for playing!");
					break;
				}
				Console.WriteLine();
			}
		}
	}
}
