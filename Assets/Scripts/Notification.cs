using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour {
	[SerializeField]
	private Text titleText;
	[SerializeField]
	private Text messageText;
	[SerializeField]
	private GameObject parent;
	[SerializeField]
	private Animation anim;
	[SerializeField]
	private AnimationClip draw;
	[SerializeField]
	private AnimationClip undraw;

	public static Notification instance;
	private void Awake(){
		instance = this;
		//parent.SetActive (false);
	}
		
	void Update () {
		if (Input.GetMouseButtonDown(0)) // for now, click/tap to trigger notification
			Display ("Question", "From Alie", 3f); 
		//to call from anywhere, use: Notification.instance.Display ("Question", "From Alie", 3f);
	}

	public void Display(string title, string message, float duration){
		anim.CrossFade (draw.name);
		titleText.text = title;
		messageText.text = message;
		parent.SetActive (true);

		duration = Mathf.Clamp (duration, draw.length, float.MaxValue);
		StartCoroutine (Stop (duration));
		
	}

	IEnumerator Stop(float duration){
		yield return new WaitForSeconds (duration);
		anim.CrossFade (undraw.name);
		StartCoroutine (End());
	}

	IEnumerator End(){
		yield return new WaitForSeconds (undraw.length);
		parent.SetActive (false);
	}
}
