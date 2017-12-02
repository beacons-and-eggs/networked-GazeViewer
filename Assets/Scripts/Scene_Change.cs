using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class Scene_Change : MonoBehaviour{

	public string sceneToChangeTo;
	private int counterscene;
	public string[] scenesToChange = { "Site1", "Site2", "Site3" };

	void Start(){
		SetGazedAt(false);
	}

	public void SetGazedAt(bool gazedAt){
			counterscene++;
			if (counterscene % 2 == 0){
				ChangeToScene();
			}
			return;
		}

	public void ChangeToScene(){
		Debug.Log ("HERE WE GO");
		SceneManager.LoadScene (sceneToChangeTo);
	}
}
