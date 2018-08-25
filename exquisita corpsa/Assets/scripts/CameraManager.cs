using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	private Camera cam;

	// Camera components
	private float minFOV = 10f; 
	private float maxFOV = 60f;
	private float sensitivityFOV = 10f;

	private float turn;
	public float minTurnLeft;
	public float maxTurnRight;

	void Awake(){
		cam = GetComponent<Camera> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Turn ();
	}

	void Turn(){
		float fov = cam.fieldOfView;
		fov -= Input.GetAxis ("Mouse ScrollWheel") * sensitivityFOV;
		fov = Mathf.Clamp (fov, minFOV, maxFOV);
		cam.fieldOfView = fov;
	}

	void Zoom(){
		
	}
}
