namespace Task4;

internal class Program
{
    private static void Main()
    {
        var arr = new[] { 3, 1, 8, 5, 4 };

        Console.WriteLine($"Source array: {string.Join(',', arr)}{Environment.NewLine}");

        for (var i = 0; i <= 10; i++)
        {
            _findDesiredNumber(i, arr);
            Console.WriteLine();
        }

        Console.ReadLine();
    }

    private static void _findDesiredNumber(int desiredNumber, int[] sourceArray)
    {
        for (var i = 0; i < sourceArray.Length; i++)
        {
            for (var l = 0; l < sourceArray.Length; l++)
            {
                List<int> c = new() { sourceArray[i] };

                for (var j = l; j < sourceArray.Length; j++)
                {
                    if (j == i)
                    {
                        j++;

                        if (j >= sourceArray.Length)
                        {
                            break;
                        }
                    }

                    if (c.Sum() > desiredNumber)
                    {
                        continue;
                    }

                    c.Add(sourceArray[j]);

                    if (c.Sum() == desiredNumber)
                    {
                        Console.WriteLine($"desired: {desiredNumber}; result: {string.Join(',', c)}");
                        return;
                    }
                }
            }
        }

        Console.WriteLine($"desired: {desiredNumber}; result: <false>");
    }
}