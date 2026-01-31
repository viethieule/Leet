public static class LongestRepeatingCharReplacement
{
    public static int CharacterReplacement(string s, int k)
    {
        var window = new Dictionary<char, int>();
        var maxf = 0;
        var maxLength = 0;
        int left = 0, right = 0;
        while (right < s.Length)
        {
            var r = s[right];
            right++;
            if (window.TryGetValue(r, out int value))
            {
                window[r] = ++value;
            }
            else
            {
                window[r] = 1;
            }
            maxf = Math.Max(window[r], maxf);

            while (maxf + k < right - left + 1)
            {
                var l = s[left];
                window[l]--;
                left++;
            }

            maxLength = Math.Max(maxf + k, maxLength);
        }
        return maxLength;
    }
}