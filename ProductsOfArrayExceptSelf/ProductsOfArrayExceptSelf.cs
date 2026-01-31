public static class ProductsOfArrayExceptSelfProblem
{
    public static int[] ProductExceptSelfWithDivision(int[] nums)
    {
        var allProducts = 1;
        var zeroIndexes = new List<int>();
        var rs = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (num == 0)
            {
                zeroIndexes.Add(i);
                if (zeroIndexes.Count > 1)
                {
                    return rs;
                }
            }
            else
            {
                allProducts *= num;
            }
        }

        if (zeroIndexes.Count == 1)
        {
            rs[zeroIndexes[0]] = allProducts;
            return rs;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            rs[i] = allProducts / (nums[i] == 0 ? 1 : nums[i]);
        }
        return rs;
    }

    public static int[] ProductsOfArrayExceptSelfWODivision(int[] nums)
    {
        var rs = new int[nums.Length];
        var map1 = new int[nums.Length];
        map1[0] = 1;
        var map2 = new int[nums.Length];
        map2[map2.Length - 1] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            map1[i] *= nums[i];
            if (i + 1 < nums.Length) map1[i + 1] = map1[i];

            var otherIndex = nums.Length - 1 - i;
            map2[otherIndex] *= nums[otherIndex];
            if (otherIndex > 0) map2[otherIndex - 1] = map2[otherIndex];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var left = i - 1 < 0 ? 1 : map1[i - 1];
            var right = i + 1 >= nums.Length ? 1 : map2[i + 1];
            rs[i] = left * right;
        }

        return rs;
    }

    public static int[] ProductsOfArrayExceptSelfO1(int[] nums)
    {
        var rs = new int[nums.Length];
        rs[0] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            rs[i] *= nums[i];
            if (i + 1 < nums.Length) rs[i + 1] = rs[i];
        }
        var suffix = 1;
        for (int i = nums.Length - 1; i >= 0 ; i--)
        {
            rs[i] = suffix * (i - 1 < 0 ? 1 : rs[i - 1]);
            suffix *= nums[i];
        }
        return rs;
    }
}