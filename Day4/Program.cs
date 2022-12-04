namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //read input

            var lines = File.ReadAllLines("input.txt");

            Console.WriteLine(TaskOne(lines));
            Console.WriteLine(TaskTwo(lines));
        }

        private static int TaskTwo(string[] lines)
        {
            var number = 0;

            foreach (var line in lines)
            {
                var splitPair = GetPair(line);

                var elfOne = splitPair.elfOne.ToHashSet();
                var elfTwo = splitPair.elfTwo.ToHashSet();

                bool containsAny = elfOne.Intersect(elfTwo).Any();

                if (containsAny)
                {
                    number++;
                }
            }

            return number;
        }

        private static int TaskOne(string[] lines)
        {
            var number = 0;

            foreach (var line in lines)
            {
                var splitPair = GetPair(line);

                var elfOne = splitPair.elfOne.ToHashSet();
                var elfTwo = splitPair.elfTwo.ToHashSet();

                bool hasAllElfOne = elfOne.All(x => elfTwo.Contains(x));

                if (hasAllElfOne)
                {
                    number++;
                    continue;
                }

                bool hasAllElfTwo = elfTwo.All(x => elfOne.Contains(x));

                if (hasAllElfTwo)
                {
                    number++;
                }
            }

            return number;
        }

        private static (IEnumerable<int> elfOne, IEnumerable<int> elfTwo) GetPair(string line)
        {
            var splitPair = line.Split(',');

            var elfOne = GetRange(splitPair[0]);
            var elfTwo = GetRange(splitPair[1]);

            return (elfOne, elfTwo);
        }

        private static IEnumerable<int> GetRange(string input)
        {
            var split = input.Split("-");
            var start = int.Parse(split[0]);
            var end = int.Parse(split[1]);

            for (int i = start; i <= end; i++)
            {
                yield return i;
            }
        }
    }
}