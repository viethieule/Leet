using Microsoft.VisualBasic;

public static class PermutationString
{
    // abc abd
    // abc lca
    public static bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;

        var freqs = new Dictionary<char, int>(26);
        foreach (var c in s1)
        {
            if (freqs.TryGetValue(c, out int value))
            {
                freqs[c] = ++value;
            }
            else
            {
                freqs[c] = 1;
            }
        }

        int left = 0;
        for (int right = 0; right < s2.Length; right++)
        {
            if (freqs.TryGetValue(s2[right], out int value))
            {
                freqs[s2[right]] = --value;
            }

            if (right - left + 1 == s1.Length)
            {
                if (freqs.All(x => x.Value == 0))
                {
                    return true;
                }

                if (freqs.TryGetValue(s2[left], out int value1)) freqs[s2[left]] = ++value1;
                left++;
            }
        }
        return false;
    }

    public static bool CheckInclusionByTemplate(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;

        var need = new int[26];
        foreach (var c in s1)
        {
            need[c - 'a']++;
        }

        var window = new int[26];
        var valid = 0;
        var needValid = need.Count(x => x > 0);
        int left = 0, right = 0;

        while (right < s2.Length)
        {
            var r = s2[right];
            right++;

            if (need[r - 'a'] > 0)
            {
                window[r - 'a']++;
                if (need[r - 'a'] == window[r - 'a'])
                {
                    valid++;
                }
            }

            while (right - left >= s1.Length)
            {
                if (valid == needValid)
                {
                    return true;
                }

                var l = s2[left];
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
        return false;
    }
}