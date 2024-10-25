using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using RadixSortBenchMarking;

public class RadixSortBenchmark
{
    private int[] randomArray;
    private int[] bestCaseArray;
    private int[] worstCaseArray;
    private int[] nearlySortedArray;
    private int[] repeatedArray;

    [GlobalSetup]
    public void Setup()
    {
        int N = 10000; 

        randomArray = Enumerable.Range(1, N).Select(x => new Random().Next(0, 100000)).ToArray();
        bestCaseArray = Enumerable.Range(1, N).ToArray();
        worstCaseArray = bestCaseArray.Reverse().ToArray();

        nearlySortedArray = bestCaseArray.ToArray();
        Swap(nearlySortedArray, 10, 500);

        repeatedArray = Enumerable.Repeat(1000, N).ToArray();
    }

    private void Swap(int[] array, int index1, int index2)
    {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    [Benchmark]
    public void RandomArrayTest()
    {
        RadixSort.Sort(randomArray);
    }

    [Benchmark]
    public void BestCaseArrayTest()
    {
        RadixSort.Sort(bestCaseArray);
    }

    [Benchmark]
    public void WorstCaseArrayTest()
    {
        RadixSort.Sort(worstCaseArray);
    }

    [Benchmark]
    public void NearlySortedArrayTest()
    {
        RadixSort.Sort(nearlySortedArray);
    }

    [Benchmark]
    public void RepeatedArrayTest()
    {
        RadixSort.Sort(repeatedArray);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<RadixSortBenchmark>();
    }
}
