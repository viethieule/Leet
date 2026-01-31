public class TwoSumIIProblem
{
    // numbers is sorted
    public static int[] TwoSum(int[] numbers, int target)
    {
        for (int i = 0, j = numbers.Length - 1; i < numbers.Length && j >= 0; i++, j--)
        {
            var numi = numbers[i];
            var numj = numbers[j];
            var other = target - numi;

            if (numj > other)
            {
                i--;
                continue;
            }
            else if (numj < other)
            {
                j++;
                continue;
            }

            return [i + 1, j + 1];
        }
        return [];
    }

    public static int[] TwoSumWhile(int[] numbers, int target)
    {
        int l = 0, r = numbers.Length - 1;
        while (l < r)
        {
            if (numbers[r] > target - numbers[l])
            {
                r--;
                continue;
            }

            if (numbers[r] < target - numbers[l])
            {
                l++;
                continue;
            }

            return [l + 1, r + 1];
        }
        return [];
    }
}