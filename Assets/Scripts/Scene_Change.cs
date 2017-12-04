using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

[RequireComponent(typeof(Collider))]
public class Scene_Change : NetworkBehaviour {

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
			broadcastSceneChange (sceneToChangeTo);
	}

	//changes the scene of the server and broadcasts change to rest of clients
	void broadcastSceneChange(string scene){
		NetworkManager.singleton.ServerChangeScene (scene);
	}

}
