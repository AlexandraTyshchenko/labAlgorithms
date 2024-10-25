namespace RadixSortBenchMarking;

public static class RadixSort
{
    public static void Sort(int[] array)
    {
        int maxValue = array.Max();
        int exp = 1;

        int[] buffer = new int[array.Length];

        while (maxValue / exp > 0)
        {
            CountingSortByDigit(array, buffer, exp);
            exp *= 10;
        }
    }

    private static void CountingSortByDigit(int[] array, int[] buffer, int exp)
    {
        int[] count = new int[10];

        for (int i = 0; i < array.Length; i++)
        {
            int digit = (array[i] / exp) % 10;
            count[digit]++;
        }

        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = array.Length - 1; i >= 0; i--)
        {
            int digit = (array[i] / exp) % 10;
            buffer[--count[digit]] = array[i];
        }

        Array.Copy(buffer, array, array.Length);
    }
}
