public static class MinWindowSubstring
{
    public static string MinWindow(string s, string t)
    {
        var need = new Dictionary<char, int>(52);
        foreach (var c in t)
        {
            if (need.TryGetValue(c, out int value))
            {
                need[c] = ++value;
            }
            else
            {
                need.Add(c, 1);
            }
        }
        var needValid = need.Count(x => x.Value > 0);

        var window = new Dictionary<char, int>(52);
        var valid = 0;
        int left = 0, right = 0;
        int start = 0, len = int.MaxValue;

        while (right < s.Length)
        {
            var c = s[right];
            right++;

            if (need.TryGetValue(c, out int needC))
            {
                if (window.TryGetValue(c, out int windowC))
                {
                    window[c] = ++windowC;
                }
                else
                {
                    window.Add(c, 1);
                }

                if (window[c] == needC)
                {
                    valid++;
                }
            }

            while (valid == needValid)
            {
                if (right - left < len)
                {
                    start = left;
                    len = right - left;
                }

                var d = s[left];

                left++;

                if (need.TryGetValue(d, out int needD))
                {
                    if (window[d] == needD)
                    {
                        valid--;
                    }
                    window[d]--;
                }
            }
        }

        return len == int.MaxValue ? "" : s.Substring(start, len);
    }
}