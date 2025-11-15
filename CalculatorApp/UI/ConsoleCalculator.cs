using CalculatorApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.UI
{
	public sealed class ConsoleCalculator
	{
		private readonly CalculatorLogic _logic = new CalculatorLogic();

		private static Dictionary<string, Dictionary<string, string>> translations = new()
		{
{
 "en", new Dictionary<string, string>
 {
 { "greeting", "Welcome to the calculator!" },
 { "chooseOperator", "Choose an operator:" },
 { "invalidChoice", "Invalid choice. Please try again." },
 { "result", "The result is: " },
 { "exit", "Goodbye!" }
 }
 },
 {
 "uk", new Dictionary<string, string>
 {
 { "greeting", "Вітаємо в калькуляторі " },
 { "chooseOperator", "Оберіть оператор:" },
 { "invalidChoice", "Невірний вибір . спробуйте ще раз ." },
 { "result", "Результат: " },
 { "exit", "Допобачення !" }
 }
 }
		};
		private string _currentLanguage = "en";

		public void Start()
		{
			SelectLanguage();
			RunCalculator();
		}

		private void SelectLanguage()
		{

			Console.WriteLine("Choose a language [en/uk]:");
			string languageChoice = Console.ReadLine().ToLower();
			if (translations.ContainsKey(languageChoice))
			{
				_currentLanguage = languageChoice;
				Console.WriteLine(translations[_currentLanguage]["greeting"]);
			}
			else
			{
				Console.WriteLine("Invalid language. Defaulting to English.");
				_currentLanguage = "en";
			}
		}

		private void RunCalculator()
		{
			PrintSeparator();
			while (true)
			{
				PrintSupportedOperators();
				string operatorChoice = Console.ReadLine();
				if (operatorChoice == "exit")
				{
					Console.WriteLine(translations[_currentLanguage]["exit"]);
					break;
				}

				if (operatorChoice == "history")
				{
					ShowHistory();
					continue;
				}

				Console.WriteLine("Enter the first number:");
				double firstNumber = GetNumberFromUser();
				double secondNumber = 0;

				if (operatorChoice != "sqrt" && operatorChoice != "log")
				{
					Console.WriteLine("Enter the second number:");
					secondNumber = GetNumberFromUser();
				}

				try
				{
					double result = 0;
					string historyEntry = "";

					switch (operatorChoice)
					{
						case "+":
							result = _logic.Add(firstNumber, secondNumber);
							historyEntry = $"{firstNumber} + {secondNumber} = {result}";
							break;
						case "-":
							result = _logic.Subtract(firstNumber, secondNumber);
							historyEntry = $"{firstNumber} - {secondNumber} = {result}";
							break;
						case "*":
							result = _logic.Multiply(firstNumber, secondNumber);
							historyEntry = $"{firstNumber} * {secondNumber} = {result}";
							break;
						case "/":
							result = _logic.Divide(firstNumber, secondNumber);
							historyEntry = $"{firstNumber} / {secondNumber} = {result}";
							break;
						case "//":

							result = _logic.IntegerDivide(firstNumber, secondNumber);
							historyEntry = $"{firstNumber} // {secondNumber} = {result}";
							break;
						case "%":
							result = _logic.Remainder(firstNumber, secondNumber);
							historyEntry = $"{firstNumber} % {secondNumber} = {result}";
							break;
						case "sqrt":
							result = _logic.Sqrt(firstNumber);
							historyEntry = $"sqrt({firstNumber}) = {result}";
							break;
						case "log":
							result = _logic.Log(firstNumber);
							historyEntry = $"log({firstNumber}) = {result}";
							break;
						default:
							Console.WriteLine(translations[_currentLanguage]["invalidChoice"]);
							continue;
					}

					_logic.AddToHistory(historyEntry);
					Console.WriteLine($"{translations[_currentLanguage]["result"]} {result:F2}");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

				PrintSeparator();
			}
		}

		private void ShowHistory()
		{
			Console.WriteLine("History of calculations:");
			var history = _logic.GetHistory();
			if (history.Count == 0)
			{
				Console.WriteLine("History is empty.");
			}
			else
			{
				foreach (var entry in history)
				{
					Console.WriteLine(entry);
				}
			}
		}

		private double GetNumberFromUser()
		{
			double number;
			while (true)
			{
				string input = Console.ReadLine();
				if (double.TryParse(input, out number))
				{
					return number;
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a valid number.");
				}
			}
		}

		private void PrintSupportedOperators()
		{
			Dictionary<string, string> supportedOperators = new()
			 {
			 { "+", "Add" }, { "-", "Subtract" }, { "*", "Multiply" },
			 { "/", "Divide" }, { "//", "Integer Divide" }, { "%", "Remainder" },
			 { "sqrt", "Square Root" }, { "log", "Logarithm" },
			 { "history", "Show History" }, { "exit", "Exit" }
             };
			Console.WriteLine("Operator choices are as follows:");
			foreach (var op in supportedOperators)
			{
				Console.WriteLine($"{op.Value}: {op.Key}");
			}
		}

		private void PrintSeparator()
		{
			Console.WriteLine("_______");
		}
	}
}
