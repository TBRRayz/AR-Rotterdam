using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class POIManager : MonoBehaviour
{
    public List<TextMesh> POI;

    // Use this for initialization
    void Start()
    {
        foreach (var p in POI)
        {
            p.GetComponent<Renderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float camY = Camera.main.transform.rotation.eulerAngles.y;
        foreach (var p in POI)
        {
            float rot = p.transform.rotation.eulerAngles.y;
            float diff = (camY - rot);
            diff = (diff < 0 ? -diff : diff);
            if (diff <= 10)
            {
                Debug.Log("Cam: " + camY + " Diff: " + diff);
                p.GetComponent<Renderer>().enabled = true;
            }
            else
                p.GetComponent<Renderer>().enabled = false;
        }
    }
}
