using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class POIManager : MonoBehaviour
{
    public List<GameObject> POI;
    public LayerMask POILayer;
    public GameObject gazeSelector;
    const int RANGE_TRESHOLD = 10;

    // Use this for initialization
    void Start()
    {
        foreach (var p in POI)
        {
            p.GetComponent<Renderer>().enabled = false;
            p.GetComponent<PointOfInterest>().toggleImage(false);
        }

        gazeSelector.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 1);
    }

    // Update is called once per frame
    void Update()
    {
        Transform cam = Camera.main.transform;
        float camY = cam.rotation.eulerAngles.y;
        foreach (var p in POI)
        {
            float rot = p.transform.rotation.eulerAngles.y;
            float diff = (camY - rot);
            diff = (diff < 0 ? -diff : diff);

            if (diff <= RANGE_TRESHOLD)
                p.GetComponent<Renderer>().enabled = true;
            else
                p.GetComponent<Renderer>().enabled = false;
        }
    }

    void OnEnable()
    {
        Cardboard.SDK.OnTrigger += TriggerPulled;
    }

    void OnDisable()
    {
        Cardboard.SDK.OnTrigger -= TriggerPulled;
    }

    void TriggerPulled()
    {
        RaycastHit hit;
        Ray ray = new Ray(gazeSelector.transform.position, gazeSelector.transform.forward);
        //Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red, 5);

        if (Physics.Raycast(ray, out hit, 500, POILayer))
        {
            Debug.Log("Selected");
            GameObject.Find(hit.transform.name).GetComponent<PointOfInterest>().toggleImage(true);
        }
        else
        {
            foreach (var p in POI)
            {
                p.GetComponent<PointOfInterest>().toggleImage(false);
            }
        }
    }
}
