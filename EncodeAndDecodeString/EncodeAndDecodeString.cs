using System.Text;

// The trick is to think of an unique property of a single string
// In this case, length of the string

static class EncodeAndDecodeStringProblem
{
    public static string Encode(IList<string> strs)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < strs.Count; i++)
        {
            var s = strs[i];
            if (string.IsNullOrEmpty(s))
            {
                sb.Append("000");
                continue;
            }
            sb.Append(s.Length.ToString().PadLeft(3, '0'));
            sb.Append(s);
        }
        return sb.ToString();
    }

    public static List<string> Decode(string s)
    {
        var rs = new List<string>();
        int k;
        for (var i = 0; i < s.Length; i += k + 3)
        {
            k = int.Parse(string.Concat(s[i], s[i + 1], s[i + 2]));
            if (k == 0)
            {
                rs.Add(string.Empty);
                continue;
            }
            var sb = new StringBuilder();
            for (int j = i + 3; j < i + 3 + k; j++)
            {
                sb.Append(s[j]);
            }
            rs.Add(sb.ToString());
        }
        return rs;
    }
}