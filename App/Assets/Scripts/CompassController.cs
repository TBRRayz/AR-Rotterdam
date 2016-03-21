using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CompassController : MonoBehaviour 
{
	public bool enableTilt = true;
	Pose3D headview;
		
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = enableTilt;
	}

	// Update is called once per frame
	void Update () {
		headview = Cardboard.SDK.HeadPose;
        GetComponent<Text>().text = "Heading: " + headview.Orientation.eulerAngles + "\nRotation: " + Camera.main.transform.rotation.eulerAngles;
	}
}