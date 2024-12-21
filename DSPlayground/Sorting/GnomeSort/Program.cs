namespace GnomeSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 34, 2, 10, -9, 7 };

        Console.WriteLine("Original Array:");
        PrintArray(arr);

        Sort(arr);

        Console.WriteLine("Sorted Array:");
        PrintArray(arr);
    }

    static void Sort(int[] arr)
    {
        int n = arr.Length;
        int index = 0;

        while (index < n)
        {
            if (index == 0 || arr[index] >= arr[index - 1])
            {
                index++;
            }
            else
            {
                // Swap arr[index] and arr[index - 1]
                int temp = arr[index];
                arr[index] = arr[index - 1];
                arr[index - 1] = temp;

                index--;
            }
        }
    }

    // Helper function to print the array
    static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
