
namespace StringCalculatorApplication
{
    public class StringCalculator
    {
        private List<string> delimiters = new() { ",", "\n" };

        public object Add(string input)
        {
            if (input is not null && input.StartsWith("//"))
            {
                var fulldelimiter = input.Substring(2, input.IndexOf('\n') - 2);
                if (fulldelimiter.Length > 1)
                {
                    AddDelimeters(fulldelimiter, ref delimiters);
                    input = input.Substring(input.IndexOf('\n') + 1);
                }
                else
                {
                    delimiters.Add(input[2].ToString());
                    input = input.Substring(3);
                } 
            }

            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var parsedNumbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse);

            var negatives = parsedNumbers.Where(n => n < 0);

            if(negatives.Any())
                throw new Exception("Negatives not allowed : "+ string.Join(",", negatives));

            return parsedNumbers.Where(n => n <= 1000).Sum();
        }

        private void AddDelimeters(string fulldelimiter, ref List<string> delimiters)
        {
            for (int i = 0; i < fulldelimiter.Length; i++)
            {
                if (fulldelimiter[i] == '[')
                {
                    var closingBracketIndex = fulldelimiter.IndexOf(']', i);
                    if (closingBracketIndex > i)
                    {
                        var delimiter = fulldelimiter.Substring(i + 1, closingBracketIndex - i - 1);
                        delimiters.Add(delimiter);
                        i = closingBracketIndex;
                    }
                }
            }
        }
    }
}
