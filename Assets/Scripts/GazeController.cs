using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GazeController : NetworkBehaviour {

//	public Camera playerCamera;
	private LineRenderer gazeLine;
	private float worldRadius = 10f;
	public GameObject endPoint;
	public GameObject face;
	private GameObject gazeObject;
	// Position Storage Variables
	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	[SyncVar]
	Vector3 destinationPoint;

	// Use this for initialization
	void Start () {		
		this.gazeLine = GetComponent<LineRenderer> ();

		if (isServer) {
			renderGaze (false);
		}
		if (isClient) {
			positionGazeViewObject ();
		} 
	}

	//get GazePrefab and disable rendering and interaction
	void renderGaze(bool isRendered){
		this.gazeLine.enabled = isRendered;
		gazeObject = GameObject.FindGameObjectWithTag ("Gaze");
		gazeObject.gameObject.GetComponent<CapsuleCollider> ().enabled = isRendered;
		MeshRenderer[] renderings = gazeObject.GetComponentsInChildren<MeshRenderer> ();
		foreach (MeshRenderer render in renderings) {
			render.enabled = isRendered;
		}
	}
	
	// Update is called once per frame
	void Update () {
		floatAnimation ();
		Vector3 gazeOrigin = transform.position;
		Vector3 gazeDestination = new Vector3(-10f, 5f, -10f);

		if (isServer) {
			destinationPoint = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, worldRadius));
		} else if (isClient) {
			renderGaze (true);
			faceTowards (destinationPoint);
			drawLine (gazeOrigin, destinationPoint);
		}
	}

	void positionGazeViewObject(){
		transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (0.2f, 0.7f, 2f));
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
