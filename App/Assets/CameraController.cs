using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	
	//WebCamTexture back;
	public GameObject plane;

	// Use this for initialization
	void Start ()
	{

		WebCamDevice[] devices = WebCamTexture.devices;
		//WebCamTexture webcamTexture = new WebCamTexture();

			Debug.Log ("Script has been started");
			plane = GameObject.FindWithTag ("Player");

		WebCamTexture webcamTexture = new WebCamTexture();
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play();


		}


	// Update is called once per frame
	void Update ()
	{

	}
}