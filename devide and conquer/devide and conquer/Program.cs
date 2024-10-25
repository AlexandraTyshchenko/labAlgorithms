using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

[ShortRunJob]
public class AlgorithmsBenchmark
{
    private int[] numbers;

    [GlobalSetup]
    public void Setup()
    {
        Random rand = new Random();
        numbers = new int[10];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rand.Next(1, 100);
        }
    }

    [Benchmark]
    public int SumDivideAndConquer()
    {
        return SumDivideAndConquer(numbers, 0, numbers.Length - 1);
    }

    [Benchmark]
    public int SumBruteForce()
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    static int SumDivideAndConquer(int[] numbers, int left, int right)
    {
        if (left > right)
        {
            return 0;
        }
        else if (left == right)
        {
            return numbers[left];
        }

        int mid = (left + right) / 2;

        return SumDivideAndConquer(numbers, left, mid) + SumDivideAndConquer(numbers, mid + 1, right);
    }

}

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<AlgorithmsBenchmark>();
    }
}
