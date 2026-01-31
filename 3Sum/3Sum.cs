using System.Diagnostics.CodeAnalysis;

public static class ThreeSumProblem
{
    public static List<IList<int>> ThreeSum(int[] nums)
    {
        var rs = new List<IList<int>>();
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            
            int l = i + 1, r = nums.Length - 1;
            while (l < r)
            {
                var sum = nums[i] + nums[l] + nums[r];
                if (sum > 0)
                {
                    r--;
                    continue;
                }

                if (sum < 0)
                {
                    l++;
                    continue;
                }

                rs.Add([nums[i], nums[l], nums[r]]);
                l++;
                r--;
                while (l < r && nums[l] == nums[l - 1])
                {
                    l++;
                }
            }
        }
        return rs;
    }
}