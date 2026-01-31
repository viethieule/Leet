static class GroupAnagramsProblem
{
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dict = new Dictionary<string, IList<string>>();
        foreach (var str in strs)
        {
            var charFreq = new char[26];
            foreach (char s in str)
            {
                charFreq[s - 'a']++;
            }
            var val = new string(charFreq);
            if (dict.TryGetValue(val, out IList<string> value)) value.Add(str);
            else dict[val] = [str];
        }
        return [.. dict.Values];
    }
}