public class TimeMap
{
    private readonly Dictionary<string, List<(int, string)>> map;
    public TimeMap()
    {
        map = [];
    }

    public void Set(string key, string value, int timestamp)
    {
        if (map.TryGetValue(key, out var value1))
        {
            value1.Add((timestamp, value));
        }
        else
        {
            map.Add(key, new List<(int, string)>() { { (timestamp, value) } });
        }
    }

    public string Get(string key, int timestamp)
    {
        if (!map.TryGetValue(key, out var times))
        {
            return string.Empty;
        }

        var left = 0;
        var right = times.Count - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var midValue = times[mid].Item1;
            if (midValue < timestamp)
            {
                left = mid + 1;
            }
            else if (midValue > timestamp)
            {
                right = mid - 1;
            }
            else if (midValue == timestamp)
            {
                left = mid + 1;
            }
        }
        if (right < 0)
        {
            return string.Empty;
        } 
        return times[right].Item2;
    }
}
