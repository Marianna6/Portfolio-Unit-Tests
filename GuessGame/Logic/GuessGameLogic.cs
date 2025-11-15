using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame.Logic
{
	public class GuessGameLogic
	{
		private readonly Random _random = new Random();
		private readonly List<int> _records = new List<int>();
		private int _secretNumber;
		private int _attemptsLeft;
		private const int MaxAttempts = 10;

		/// <summary>Starts a new game by resetting attempts and setting a new secret number.</summary>
		/// <param name="userChoice">The difficulty level chosen by the user.</param>
		public void StartNewGame(int userChoice)
		{
			_attemptsLeft = MaxAttempts;

			if (userChoice == 1) _secretNumber = _random.Next(1, 51);
			else if (userChoice == 2) _secretNumber = _random.Next(1, 101);
			else if (userChoice == 3) _secretNumber = _random.Next(1, 501);
			else _secretNumber = _random.Next(1, 101);
		}

		/// <summary>Compares the user's guess to the secret number and returns the game state.</summary>
		/// <param name="guess">The number submitted by the user.</param>
		/// <returns>A status string: "TooLow", "TooHigh", "Correct", or "YouLost".</returns>
		public string MakeGuess(int guess)
		{
			_attemptsLeft--;

			if (guess < _secretNumber)
			{
				return (_attemptsLeft == 0) ? "YouLost" : "TooLow";
			}
			else if (guess > _secretNumber)
			{
				return (_attemptsLeft == 0) ? "YouLost" : "TooHigh";
			}
			else
			{

				int attemptsUsed = MaxAttempts - _attemptsLeft;
				_records.Add(attemptsUsed);
				_records.Sort();
				if (_records.Count > 3) _records.RemoveAt(3);

				return "Correct";
			}
		}

		/// <summary>Gets the current list of high scores (best attempts).</summary>
		/// <returns>A new List<int> containing 3 recorded attempts.</returns>
		public List<int> GetRecords()
		{
			return new List<int>(_records);
		}

		/// <summary>Gets the current secret number.</summary>
		/// <returns>The generated secret number for the current game.</returns>
		public int GetSecretNumber()
		{
			return _secretNumber;
		}

		/// <summary>
		/// (Test Hook) Starts a test game with a forced secret number.
		/// This skips Random to allow deterministic testing of the MakeGuess method.
		/// </summary>
		/// <param name="forcedSecretNumber">The specific secret number to use for the test.</param>
		public void StartTestGame(int forcedSecretNumber)
		{
			_secretNumber = forcedSecretNumber;
			_attemptsLeft = MaxAttempts;
		}
	}
}
