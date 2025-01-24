namespace JumpSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };
        int target = 15;

        int result = Search(arr, target);
        Console.WriteLine(result != -1 ? $"Element found at index {result}" : "Element not found");
    }

    // Jump Search implementation
    public static int Search(int[] arr, int target)
    {
        int n = arr.Length;

        // Determine the jump size
        int step = (int)Math.Floor(Math.Sqrt(n));
        int prev = 0;

        // Jump forward to find the block where the target lies
        while (arr[Math.Min(step, n) - 1] < target)
        {
            prev = step;
            step += (int)Math.Floor(Math.Sqrt(n));

            // If we've gone out of bounds, the target is not in the array
            if (prev >= n)
                return -1;
        }

        // Perform a linear search within the identified block
        while (arr[prev] < target)
        {
            prev++;

            // If we reach the end of the block or array, return -1
            if (prev == Math.Min(step, n))
                return -1;
        }

        // Check if the target is found
        if (arr[prev] == target)
            return prev;

        return -1; // Element not found
    }
}
