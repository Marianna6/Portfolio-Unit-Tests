using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessGame.Logic;

namespace MyProjects.Tests
{
	public class GuessGameLogicTests
	{
		[Theory]
		[InlineData(1, 1, 50)]
		[InlineData(2, 1, 100)]
		[InlineData(3, 1, 500)]
		[InlineData(99, 1, 100)]
		public void StartNewGame_ValidLevels_SetsSecretNumberInRange(int difficulty, int min, int max)
		{
			GuessGameLogic logic = new GuessGameLogic();
			logic.StartNewGame(difficulty);
			int actualSecretNumber = logic.GetSecretNumber();

			Assert.InRange(actualSecretNumber, min, max);
		}

		[Theory]
		[InlineData(30, "TooLow")]
		[InlineData(60, "TooHigh")]
		[InlineData(50, "Correct")]
		public void MakeGuess_SimpleGuesses_ReturnsCorrectStatus(int guess, string expectedResult)
		{
			GuessGameLogic logic = new GuessGameLogic();
			logic.StartTestGame(50);
			string actual = logic.MakeGuess(guess);
			Assert.Equal(expectedResult, actual);
		}

		[Fact]
		public void MakeGuess_OnLastAttempt_ReturnsYouLostString()
		{
			GuessGameLogic logic = new GuessGameLogic();
			logic.StartTestGame(50);
			for (int i = 0; i < 9; i++)
			{
				logic.MakeGuess(10);
			}
			string actual = logic.MakeGuess(20);
			Assert.Equal("YouLost", actual);
		}

		[Fact]
		public void GetRecords_OnNewGame_ReturnsEmptyList()
		{
			GuessGameLogic logic = new GuessGameLogic();
			logic.StartNewGame(1);
			Assert.Empty(logic.GetRecords());
		}

		[Fact]
		public void MakeGuess_CorrectGuess_AddsRecordToHistory()
		{
			GuessGameLogic logic = new GuessGameLogic();
			logic.StartTestGame(50);
			int expectedRecord = 1;
			logic.MakeGuess(50);
			var actualRecords = logic.GetRecords();
			Assert.Single(actualRecords);
			Assert.Equal(expectedRecord, actualRecords[0]);
		}
	}
}
