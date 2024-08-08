namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
                if (string.IsNullOrEmpty(numbers))
                {
                    return 0;
                }

                var separators = GetDefaultSeparators();
                numbers = ExtractCustomDelimiters(numbers, separators);

                var nums = ParseNumbers(numbers, separators);
                ValidateNoNegatives(nums);

                return CalculateSum(nums);

        }
        private List<string> GetDefaultSeparators()
        {
            return new List<string> { ",", "\n" };
        }

        private int CalculateSum(List<int> numbers)
        {
            return numbers.Where(n => n <= 1000).Sum();
        }

        private void ValidateNoNegatives(List<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0).ToList();
            if (negatives.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negatives)}");
            }
        }
        private string ExtractCustomDelimiters(string numbers, List<string> separators)
        {
            if (numbers.StartsWith("//"))
            {
                var delimiterEndIndex = numbers.IndexOf('\n');
                var customDelimiter = numbers[2..delimiterEndIndex];
                AddCustomDelimiters(customDelimiter, separators);
                numbers = numbers[(delimiterEndIndex + 1)..];
            }

            return numbers;
        }

        private void AddCustomDelimiters(string customDelimiter, List<string> separators)
        {
            if (customDelimiter.StartsWith("[") && customDelimiter.EndsWith("]"))
            {
                var delimiterParts = customDelimiter.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                separators.AddRange(delimiterParts);
            }
            else
            {
                separators.Add(customDelimiter);
            }
        }
        private List<int> ParseNumbers(string numbers, List<string> separators)
        {
            return numbers.Split(separators.ToArray(), StringSplitOptions.None)
                .Select(int.Parse)
                .ToList();
        }


    }
}
