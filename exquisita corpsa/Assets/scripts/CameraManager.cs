using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	private Camera cam;
	private InputManager input;

	public bool inverted;

	// Camera components
	private float minFOV = 10f; 
	private float maxFOV = 60f;
	private float sensitivityFOV = 30f;

	private Vector3 turn;
	private Vector2 horizTurnBounds = new Vector2(-30f, 30f);
	private Vector2 vertTurnBounds = new Vector2(-30f, 30f);
	private float sensitivityTurn = 30f;

	void Awake(){
		cam = GetComponent<Camera> ();
		input = GetComponent<InputManager> ();
	}

	// Use this for initialization
	void Start () {
		turn = transform.localEulerAngles;

		horizTurnBounds += Vector2.one * transform.localEulerAngles.y;
		vertTurnBounds += Vector2.one * transform.localEulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
		Zoom ();
	}

	public void Turn(){
		Vector3 dir = Vector3.zero;

		if (inverted)
			dir = (input.Begin - input.End) / (Screen.width/2f);
		else
			dir = (input.End - input.Begin) / (Screen.width/2f);

		turn += new Vector3 (-dir.y, dir.x, 0f) * sensitivityTurn * Time.deltaTime;
		turn = new Vector3 (Mathf.Clamp (turn.x, vertTurnBounds.x, vertTurnBounds.y),
							Mathf.Clamp (turn.y, horizTurnBounds.x, horizTurnBounds.y), 
							turn.z);
		transform.localEulerAngles = turn;
	}

	void Zoom(){
		float fov = cam.fieldOfView;
		fov -= Input.GetAxis ("Mouse ScrollWheel") * sensitivityFOV;
		fov = Mathf.Clamp (fov, minFOV, maxFOV);
		cam.fieldOfView = fov;
	}
}
