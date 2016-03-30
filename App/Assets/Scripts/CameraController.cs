using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
        WebCamTexture webcamTexture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}

	// Update is called once per frame
	void Update ()
	{

	}
}