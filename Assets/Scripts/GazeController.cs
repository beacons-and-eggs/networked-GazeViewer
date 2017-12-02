using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour {

//	public Camera playerCamera;
	private LineRenderer gazeLine;
	private float worldRadius = 4f;
	public GameObject endPoint;
	public GameObject face;

	// Position Storage Variables
	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	// Use this for initialization
	void Start () {
		this.gazeLine = GetComponent<LineRenderer> ();
		positionGazeViewObject ();
	}
	
	// Update is called once per frame
	void Update () {
		floatAnimation ();
		Vector3 gazeOrigin = transform.position;
		Vector3 gazeDestination = new Vector3(-10f, 5f, -10f);
		faceTowards (gazeDestination);
		drawLine (gazeOrigin, gazeDestination);
	}

	void positionGazeViewObject(){
		transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (0.2f, 0.7f, worldRadius));
	}

	void floatAnimation(){
		tempPos = transform.position;
		tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * 0.7f) * 0.01f;
		transform.position = tempPos;
	}

	void faceTowards(Vector3 destination) {
		transform.LookAt (destination);
		transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
		face.transform.LookAt (destination);
	}

	void drawLine(Vector3 origin, Vector3 destination){
		gazeLine.SetPosition (0, origin);
		gazeLine.SetPosition (1, destination);

		endPoint.transform.position = destination;
	}
}
