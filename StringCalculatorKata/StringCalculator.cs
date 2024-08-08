namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            {

                if (string.IsNullOrEmpty(numbers))
                {
                    return 0;
                }

                string[] separators = { ",", "\n" };
                if (numbers.StartsWith("//"))
                {
                    var delimiterEndIndex = numbers.IndexOf('\n');
                    var customDelimiter = numbers[2..delimiterEndIndex];
                    separators = new[] { customDelimiter };
                    numbers = numbers[(delimiterEndIndex + 1)..];
                }

                var nums = numbers.Split(separators, StringSplitOptions.None).Select(int.Parse).ToList();
                var negatives = nums.Where(n => n < 0).ToList();
                if (negatives.Any())
                {
                    throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negatives)}");
                }

                return nums.Where(n => n <= 1000).Sum();

            }
        }
    }

}
