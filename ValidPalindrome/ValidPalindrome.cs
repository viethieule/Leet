public static class ValidPalindromeProblem
{
    public static bool IsPalindrome(string s)
    {
        for (int i = 0, j = s.Length - 1; i < s.Length && j >= 0; i++, j--)
        {
            if (i >= j)
            {
                return true;
            }

            var c1 = char.ToLowerInvariant(s[i]);
            var c2 = char.ToLowerInvariant(s[j]);
            if (c1 == c2)
            {
                continue;
            }

            var isC1Invalid = !char.IsAsciiLetterOrDigit(c1);
            var isC2Invalid = !char.IsAsciiLetterOrDigit(c2);

            if (isC1Invalid && isC2Invalid)
            {
                continue;
            }

            if (isC1Invalid)
            {
                j++;
                continue;
            }

            if (isC2Invalid)
            {
                i--;
                continue;
            }

            if (c1 != c2)
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsPalindromeWhile(string s)
    {
        int l = 0, r = s.Length - 1;

        while (l < r)
        {
            if (!char.IsAsciiLetterOrDigit(s[l]))
            {
                l++;
                continue;
            }

            if (!char.IsAsciiLetterOrDigit(s[r]))
            {
                r--;
                continue;
            }

            if (char.ToLowerInvariant(s[l]) != char.ToLowerInvariant(s[r]))
            {
                return false;
            }

            l++;
            r--;
        }
        return true;
    }
}