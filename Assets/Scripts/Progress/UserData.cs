using System.Collections.Generic;

[System.Serializable]
public class UserData
{
    public UserData()
    {
        _pairs = new Dictionary<string, object>();
    }

    public Dictionary<string, object> _pairs;

    public int Temp;

    public void SetItem(string tag, object item)
    {
        if (!_pairs.ContainsKey(tag))
        {
            _pairs.Add(tag, item);
        }
        else
        {
            _pairs[tag] = item;
        }
    }

    public object GetValue(string tag, object defaultValue = null)
    {
        if (!_pairs.ContainsKey(tag))
        {
            _pairs.Add(tag, defaultValue);
        }

        return _pairs[tag];
    }

    public bool ContainsKey(string key)
    {
        return _pairs.ContainsKey(key);
    }
}
