
namespace sorting;

class BubbleSort
{
    static void Main()
    {
        int[] numbers = { 100, 9, 7, 12, 67, 78, 89 };

        Console.Write("Original array:");
        PrintArray(numbers);

        BubbleSorting(numbers);

        Console.Write("Sorted array:");
        PrintArray(numbers);
    }

    public static void BubbleSorting(int[] numbers)
    {
       int n = numbers.Length;
        
        for (int i = 0; i < n-1; i++)
        { 
            // flag to optimise and reduce un necessary iteration
            bool swapped = false;

            for (int j = 0; j < n-1; j++)
            {
                swapped = true;
                if (numbers[j] > numbers[j+1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j+1];
                    numbers[j+1] = temp;
                }
            }

            if (swapped)
            {
                break;
            }
        }
    }

    private static void PrintArray(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write(number + ",");
        }
        Console.WriteLine();
    }
}
