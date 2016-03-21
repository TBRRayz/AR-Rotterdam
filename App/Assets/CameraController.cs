using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	
	//WebCamTexture back;
	public GameObject plane;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Script has been started");

		WebCamTexture webcamTexture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}


	// Update is called once per frame
	void Update ()
	{

	}
}