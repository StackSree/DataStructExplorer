namespace FibonacciSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 10, 22, 35, 40, 45, 50, 80, 82, 85, 90, 100 };
        int target = 85;

        int result = Search(arr, target);
        Console.WriteLine(result != -1 ? $"Element found at index {result}" : "Element not found");
    }
    // Function to perform Fibonacci Search
    public static int Search(int[] arr, int target)
    {
        int n = arr.Length;

        // Initialize Fibonacci numbers
        int fibM2 = 0;  // (m-2)th Fibonacci number
        int fibM1 = 1;  // (m-1)th Fibonacci number
        int fibM = fibM2 + fibM1;  // mth Fibonacci number

        // Find the smallest Fibonacci number greater than or equal to n
        while (fibM < n)
        {
            fibM2 = fibM1;
            fibM1 = fibM;
            fibM = fibM2 + fibM1;
        }

        // Marks the eliminated range from the front
        int offset = -1;

        // While there are elements to be inspected
        while (fibM > 1)
        {
            // Check if fibM2 is a valid index
            int i = Math.Min(offset + fibM2, n - 1);

            // If target is greater than the value at index fibM2, cut the subarray after i
            if (arr[i] < target)
            {
                fibM = fibM1;
                fibM1 = fibM2;
                fibM2 = fibM - fibM1;
                offset = i;
            }
            // If target is less than the value at index fibM2, cut the subarray before i
            else if (arr[i] > target)
            {
                fibM = fibM2;
                fibM1 = fibM1 - fibM2;
                fibM2 = fibM - fibM1;
            }
            // Element found
            else
            {
                return i;
            }
        }

        // Compare the last element with the target
        if (fibM1 == 1 && offset + 1 < n && arr[offset + 1] == target)
        {
            return offset + 1;
        }

        // Element not found
        return -1;
    }
}
