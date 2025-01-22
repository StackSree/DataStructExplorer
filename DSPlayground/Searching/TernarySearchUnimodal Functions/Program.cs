namespace TernarySearchUnimodal_Functions;

internal class Program
{
    static void Main(string[] args)
    {
        double left = 0, right = 6; // Search range
        double maxPoint = FindMaximum(left, right);

        Console.WriteLine($"Maximum value found near x = {maxPoint:F6}");
        Console.WriteLine($"Maximum value is approximately f(x) = {Function(maxPoint):F6}");
    }

    static double Function(double x)
    {
        return -1 * (x - 3) * (x - 3) + 9; // Maximum at x = 3
    }

    public static double FindMaximum(double left, double right, double epsilon = 1e-6)
    {
        while (right - left > epsilon)
        {
            double mid1 = left + (right - left) / 3;
            double mid2 = right - (right - left) / 3;

            if (Function(mid1) < Function(mid2))
            {
                left = mid1;
            }
            else
            {
                right = mid2;
            }
        }

        return (left + right) / 2; // Approximate maximum point
    }
}
