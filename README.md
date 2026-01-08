# C# Unit Testing Project (xUnit)

This repository includes a test suite for two C# console applications - a Calculator and a Guess Game.
I originally built these applications after completing a foundational C# course as part of a personal learning portfolio and career development program.

During refactoring, I focused on improving the structure of both applications.
The goal was to separate business logic from console input/output, making the code clean, reusable, and fully testable with xUnit.

This suite contains 47 isolated unit tests that verify the main logic of both programs.

---

## Architecture

The refactored architecture separates each application into distinct layers:

* **Logic Layer:** Contains only the business logic (e.g., math operations, game state management). It is completely isolated from the Console.
* **UI Layer:** Responsible only for console I/O (`Console.WriteLine`/`Console.ReadLine`).
* **Tests:** This project tests the Logic layer directly.

---

## Test Strategy and Coverage

The test suite covers Positive, Boundary, and Negative scenarios using the "Arrange, Act, Assert" pattern.

### CalculatorLogicTests.cs
* **Data-Driven Tests:** Used `[Theory]` and `[InlineData]` to efficiently cover all math operations (`Add`, `Subtract`, `Multiply`, `Divide`, `IntegerDivide`, `Remainder`).
* **Exception Testing (`[Fact]`):** Confirmed that the logic fails correctly when it should fail.
    * `Assert.Throws<DivideByZeroException>`
    * `Assert.Throws<ArgumentException>` (for `Sqrt` and `Log`)
* **Stateful (`void`) Testing:** Verified `void` methods (like `AddToHistory`) by checking their "side effects" on the class state, using `Assert.Single` and `Assert.Empty`.

### GuessGameLogicTests.cs
* **Testing `Random`:** Used `Assert.InRange` to verify that `StartNewGame()` correctly selects a number within the "Easy," "Medium," and "Difficult" difficulty ranges.
* **Test Hooks:** Implemented a `StartTestGame(forcedNumber)` method in the `Logic` layer. This "Test Hook" skips `Random`, ensuring all `MakeGuess` tests are deterministic.
* **State Exhaustion Testing:** Used a `for` loop in the `MakeGuess_OnLastAttempt_ReturnsYouLost` test to verify the `YouLost` state after all attempts are used.

---

## Key Skills Demonstrated

* **C# & Software Architecture**
    * Refactoring for Testability.
    * Separation of Concerns.
	* Exception Handling.
* **xUnit Framework:**
    * `[Fact]` (for unique scenarios).
    * `[Theory]` / `[InlineData]` (for data-driven scenarios).
    * `Assert.Equal`, `Assert.Throws<TException>`, `Assert.InRange`, `Assert.Single`, `Assert.Empty`.
* **Key Test Design Patterns:**
    * Stateful (`void`) method testing.
    * State Exhaustion (Looping) testing.
    * Creating "Test Hooks" to achieve Testability and Determinism.

---

## Technology Stack

* Language: C#
* Framework: .NET 9
* Test Runner: xUnit
* IDE: Visual Studio 2022
