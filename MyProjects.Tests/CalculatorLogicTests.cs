using CalculatorApp.Logic;

namespace MyProjects.Tests
{
	public class CalculatorLogicTests
	{
		[Theory]
		[InlineData(2,2,4)]
		[InlineData(5,0,5)]
		[InlineData(-2,-3,-5)]
		public void Add_SimpleValues_ReturnsCorrectSum(double a, double b, double expected)
		{
			CalculatorLogic logic = new CalculatorLogic();

			double actual = logic.Add(a,b);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(5,2,3)]
		[InlineData(5,5,0)]
		[InlineData(6, 0, 6)]
		[InlineData(2,5,-3)]
		[InlineData(5, -2,7)]
		[InlineData(-5, 1, -6)]
		public void Subtract_SimpleValues_ReturnsCorrectSubtract(double a, double b, double expected)
		{
			CalculatorLogic logic=new CalculatorLogic();

			double actual=logic.Subtract(a,b);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(5,2,10)]
		[InlineData(5, 1, 5)]
		[InlineData(5,0,0)]
		[InlineData(-5,2,-10)]
		[InlineData(-5,-5,25)]
		public void Multiply_SimpleValues_ReturnsCorrectMultiply(double a, double b, double expected)
		{
			CalculatorLogic logic=new CalculatorLogic();

			double actual=logic.Multiply(a,b);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(10, 2, 5)]
		[InlineData(0, 5, 0)]
		[InlineData(-10, 2, -5)]
		[InlineData(-10, -2, 5)]
		public void Divide_SimpleValues_ReturnsCorrectDivide(double a, double b, double expected)
		{
			CalculatorLogic logic =new CalculatorLogic();

			double actual =logic.Divide(a,b);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Divide_ByZero_ThrowsDivideByZeroException()
		{
			CalculatorLogic logic = new CalculatorLogic();

			Assert.Throws<DivideByZeroException>(() => logic.Divide(10, 0));
		}

		[Theory]
		[InlineData(7,2,3)]
		[InlineData(0,2,0)]
		[InlineData(-7,2,-3)]
		[InlineData(-7,-2,3)]
		public void IntegerDivide_SimpleValues_ReturnsCorrectInteger(double a, double b, double expected)
		{
			CalculatorLogic logic = new CalculatorLogic();

			double actual=logic.IntegerDivide(a,b);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void IntegerDivide_ByZero_ThrowsDivideByZeroException()
		{
			CalculatorLogic logic = new CalculatorLogic();

			Assert.Throws<DivideByZeroException>(() => logic.IntegerDivide(10, 0));
		}

		[Theory]
		[InlineData(7,2,1)]
		[InlineData(10,2,0)]
		[InlineData(-7, 2, -1)]
		[InlineData(7, -2, 1)]
		public void Remainder_SimpleValues_ReturnsCorrectRemainder(double a, double b, double expected)
		{
			CalculatorLogic logic = new CalculatorLogic();

			double actual=logic.Remainder(a,b);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Remainder_ByZero_ThrowsDivideByZeroException()
		{
			CalculatorLogic logic = new CalculatorLogic();

			Assert.Throws<DivideByZeroException>(()=>logic.Remainder(10, 0));
		}

		[Theory]
		[InlineData(4, 2)]
		[InlineData(0, 0)]
		public void Sqrt_ValidInputs_ReturnsCorrectResult(double a, double expected)
		{
			CalculatorLogic logic = new CalculatorLogic();

			double actual=logic.Sqrt(a);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Sqrt_NegativeInput_ThrowsArgumentException()
		{
			CalculatorLogic logic = new CalculatorLogic();

			Assert.Throws<ArgumentException>(() => logic.Sqrt(-1));
		}

		[Fact]
		public void Log_One_ReturnsZero()
		{
			CalculatorLogic logic = new CalculatorLogic();
			double a = 1;
			double expected = 0;

			double actual= logic.Log(a);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void Log_InvalidInputs_ThrowsArgumentException(double a)
		{
			CalculatorLogic logic = new CalculatorLogic();

			Assert.Throws<ArgumentException>(() => logic.Log(a));
		}

		[Fact]
		public void AddToHistory_OneEntry_AddsOneEntryToHistory()
		{
			CalculatorLogic logic = new CalculatorLogic();
			string expectedEntry = "5 + 5 = 10";
			logic.AddToHistory(expectedEntry);
			var actualHistory = logic.GetHistory();
			Assert.Single(actualHistory);
			Assert.Equal(expectedEntry, actualHistory[0]);
		}

		[Fact]
		public void GetHistory_OnNewCalculator_ReturnsEmptyList()
		{
			CalculatorLogic logic = new CalculatorLogic();

			var actualHistory =logic.GetHistory();

			Assert.Empty(actualHistory);
		}
	}
}
