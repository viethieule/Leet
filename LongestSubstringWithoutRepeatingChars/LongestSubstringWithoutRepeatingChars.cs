public static class LongestSubstringWithoutRepeatingCharsProblem
{
    public static int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0 || s.Length == 1) return s.Length;

        int l = 0, r = 1;
        var map = new Dictionary<char, int>
        {
            { s[l], l }
        };
        var max = 1;
        while (r < s.Length)
        {
            if (map.TryGetValue(s[r], out var valR) && valR >= l)
            {
                l = valR + 1;
            }
            else
            {
                max = Math.Max(max, r - l + 1);
            }
            
            if (!map.TryAdd(s[r], r))
            {
                map[s[r]] = r;
            }
            r++;
        }
        return max;
    }

    public static int LengthOfLongestSubstring2(string s)
    {
        var map = new Dictionary<char, int>();
        var max = 0;
        var l = 0;
        for (int r = 0; r < s.Length; r++)
        {
            if (map.TryGetValue(s[r], out var value) && value >= l)
            {
                l = value + 1;
            }
            else
            {
                max = Math.Max(max, r - l + 1);
            }
            if (!map.TryAdd(s[r], r))
            {
                map[s[r]] = r;
            }
        }
        return max;
    }

    public static int LengthOfLongestSubstringTemplate(string s)
    {
        if (s.Length == 0 || s.Length == 1) return s.Length;

        var map = new Dictionary<char, int>();
        var max = 1;
        int left = 0, right = 0;
        while (right < s.Length)
        {
            var r = s[right];
            right++;
            if (map.TryGetValue(r, out int value))
            {
                map[r] = ++value;
            }
            else
            {
                map.Add(r, 1);
            }

            while (map[r] > 1)
            {
                var l = s[left];
                left++;
                map[l]--;
            }

            max = Math.Max(max, right - left);
        }

        return max;
    }
}