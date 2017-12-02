using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour {

//	public Button screenBackButton;
//	public Button screenNextButton;
//	public Button worldBackButton;
//	public Button worldNextButton;

	public List<Sprite> slideLocation;//where do the slides live NOTE: USE ABSOLUTE PATH
	public GameObject screen;

	private SlideController sController;

	void Start () {
		//TODO: public instatiate a SceneView
		sController = new SlideController(this.slideLocation, screen);
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
