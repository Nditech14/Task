using Xunit;
using Domain.Abstraction;
using Domain.Implementation;
using Microsoft.Extensions.Logging;
using Moq;

namespace ScoreCalculatorTests
{
    public class ScoreTest
    {
        private readonly IScoreCalculator _calculator;
        private readonly Mock<ILogger<ScoreCalculator>> _loggerMock;

        public ScoreTest()
        {
            // Create a mock ILogger
            _loggerMock = new Mock<ILogger<ScoreCalculator>>();

            // Inject the mock logger into the ScoreCalculator
            _calculator = new ScoreCalculator(_loggerMock.Object);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 11)]
        [InlineData(new int[] { 15, 25, 35 }, 9)]
        [InlineData(new int[] { 8, 8 }, 12)]
        [InlineData(new int[] { 2, 4, 6, 8 }, 9)]
        [InlineData(new int[] { }, 0)]
        [InlineData(new int[] { 1, 3, 5, 7 }, 12)]
        [InlineData(new int[] { 0, 8 }, 7)]
        [InlineData(new int[] { -1, -2, 8, -8 }, 11)]
        public void CalculateScore_ShouldReturnExpectedResult(int[] numbers, int expectedScore)
        {
            // Act
            int actualScore = _calculator.CalculateScore(numbers);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_WithNullInput_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _calculator.CalculateScore(null));
        }
    }
}
