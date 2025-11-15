using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Logic
{
	public class CalculatorLogic
	{
		private readonly List<string> _history=new List<string>();

		/// <summary>Adds two numbers.</summary>
		/// <param name="a">The first number to add.</param>
		/// <param name="b">The second number to add.</param>
		/// <returns>The sum of a and b.</returns>
		public double Add(double a, double b) => a + b;

		/// <summary>Subtracts one number from another.</summary>
		/// <param name="a">The number to subtract from.</param>
		/// <param name="b">The number to subtract.</param>
		/// <returns>The difference of a and b.</returns>
		public double Subtract(double a, double b) => a - b;

		/// <summary>Multiplies two numbers.</summary>
		/// <param name="a">The first number to multiply.</param>
		/// <param name="b">The second number to multiply.</param>
		/// <returns>The product of a and b.</returns>
		public double Multiply(double a, double b) => a * b;

		/// <summary>Divides number a by number b.</summary>
		/// <param name="a">The number to divide.</param>
		/// <param name="b">The number to divide by.</param>
		/// <returns>The result of the division.</returns>
		/// <exception cref="DivideByZeroException">Thrown when b is zero.</exception>
		public double Divide(double a, double b)
		{
			if (b == 0)
			{

				throw new DivideByZeroException("Error: Cannot divide by zero.");
			}
			return a / b;
		}

		/// <summary>Calculates integer division (truncates the decimal).</summary>
		/// <param name="a">The number to divide.</param>
		/// <param name="b">The number to divide by.</param>
		/// <returns>The integer result of the division.</returns>
		/// <exception cref="DivideByZeroException">Thrown when b is zero.</exception>
		public double IntegerDivide(double a, double b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException("Error: Cannot divide by zero.");
			}
			return (int)(a / b);
		}

		/// <summary>Calculates remainder division.</summary>
		/// <param name="a">The number to divide.</param>
		/// <param name="b">The number to divide by.</param>
		/// <returns>The remainder of the division.</returns>
		/// <exception cref="DivideByZeroException">Thrown when b is zero.</exception>
		public double Remainder(double a, double b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException("Error: Cannot divide by zero.");
			}
			return a % b;
		}

		/// <summary>Calculates the square root of a number.</summary>
		/// <param name="a">The number to find the root of.</param>
		/// <returns>The square root of a.</returns>
		/// <exception cref="ArgumentException">Thrown when a is negative.</exception>
		public double Sqrt(double a)
		{
			if (a < 0)
			{
				throw new ArgumentException("Error: Cannot calculate square root of a negative number.");
			}
			return Math.Sqrt(a);
		}

		/// <summary>Calculates the logarithm of a number.</summary>
		/// <param name="a">The number to find the logarithm of.</param>
		/// <returns>The logarithm of a.</returns>
		/// <exception cref="ArgumentException">Thrown when a is zero or negative.</exception>
		public double Log(double a)
		{
			if (a <= 0)
			{
				throw new ArgumentException("Error: Logarithm is undefined for non-positive numbers.");
			}
			return Math.Log(a);
		}

		/// <summary>Adds a calculation entry to the history list.</summary>
		/// <param name="historyEntry">The calculation entry (for example "5 + 5 = 10") to add.</param>
		public void AddToHistory(string historyEntry)
		{
			_history.Add(historyEntry);
		}

		/// <summary>Gets the current list of calculation entries.</summary>
		/// <returns>A new List<string> containing all history entries.</returns>
		public List<string> GetHistory()
		{
			return new List<string>(_history);
		}
	}
}
