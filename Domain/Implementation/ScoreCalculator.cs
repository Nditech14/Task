using Domain.Abstraction;
using Microsoft.Extensions.Logging;

namespace Domain.Implementation
{
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly ILogger<ScoreCalculator> _logger;

        public ScoreCalculator(ILogger<ScoreCalculator> logger)
        {
            _logger = logger;
        }

        public int CalculateScore(int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));

            int totalScore = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    totalScore += 1;
                    _logger.LogInformation("Added 1 point for even number {Number}. Total score: {TotalScore}", number, totalScore);
                }
                else
                {
                    totalScore += 3;
                    _logger.LogInformation("Added 3 points for odd number {Number}. Total score: {TotalScore}", number, totalScore);
                }

                if (number == 8)
                {
                    totalScore += 5;
                    _logger.LogInformation("Added 5 bonus points for number 8. Total score: {TotalScore}", totalScore);
                }
            }
            _logger.LogInformation("Final total score: {TotalScore}", totalScore);
            return totalScore;
        }
    }
}
