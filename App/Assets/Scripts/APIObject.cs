using UnityEngine;

public class APIObject
{
    public string name;
    public float rating;
    public string image;
    public string wikipedia;

    public static APIObject FromJSON(string json)
    {
        return JsonUtility.FromJson<APIObject>(json);
    }
}
