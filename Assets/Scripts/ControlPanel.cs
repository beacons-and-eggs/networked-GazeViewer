using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour {

	public GameObject screen;
	public ViewerController sController;

	void Start () {
		//TODO: public instatiate a SceneView
		SlideViewerStateMachine slideViewerScript = screen.GetComponent<SlideViewerStateMachine>();
		Debug.Log (slideViewerScript);
		sController = slideViewerScript.viewerController;
		this.sController.Update ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextScreenPressed(){
		Debug.Log ("NextScenePressed");
		this.sController.incrementSlide ();
		this.sController.Update ();
	}

	public void backScreenPressed(){
		Debug.Log ("BackScenePressed");
		this.sController.decrementSlide ();
		this.sController.Update ();
	}

	public void nextWorldPressed(){
		Debug.Log ("NextScenePressed");
	}

	public void backWorldPressed(){
		Debug.Log ("BackScenePressed");
	}
}
