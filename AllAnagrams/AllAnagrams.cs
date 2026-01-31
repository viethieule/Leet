public static class AllAnagramsProblem
{
    public static IList<int> FindAnagrams(string s, string p)
    {
        var need = new int[26];
        foreach (var c in p)
        {
            need[c - 'a']++;
        }
        int needValid = need.Count(x => x > 0);
        int valid = 0;
        var window = new int[26];
        List<int> res = new List<int>();
        int left = 0, right = 0;

        while (right < s.Length)
        {
            var r = s[right];
            right++;
            if (need[r - 'a'] > 0)
            {
                window[r - 'a']++;
                if (need[r - 'a'] == window[r - 'a'])
                {
                    valid++;
                }
            }

            while (valid == needValid)
            {
                if (right - left == p.Length)
                {
                    res.Add(left);
                }

                var l = s[left];
                left++;
                if (need[l - 'a'] > 0)
                {
                    if (need[l - 'a'] == window[l - 'a'])
                    {
                        valid--;
                    }
                    window[l - 'a']--;
                }
            }
        }

        return res;
    }
}