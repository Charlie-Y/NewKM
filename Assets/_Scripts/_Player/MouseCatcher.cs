using UnityEngine;
using System.Collections;


/// <summary>
/// Teleport catcher.cs should be attached to some background object which can catch alll the mouseclicks
/// 
/// 
/// or something...
/// </summary>
public class MouseCatcher : MonoBehaviour {


	PlayerUnit player;
	



	// Use this for initialization
	void Start () {
		player = PlayerUnit.GetPlayer();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver(){
		// Left
		if (Input.GetMouseButtonDown(0) ){
			player.SendMessage("MouseLeftDownMessage", GetMousePosition().Value, SendMessageOptions.DontRequireReceiver);
		}
		if (Input.GetMouseButtonDown(1) ){
			player.SendMessage("MouseRightDownMessage", GetMousePosition().Value, SendMessageOptions.DontRequireReceiver);
		}
	}



	Vector3? GetMousePosition(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = default(RaycastHit);
		
		if (Physics.Raycast(ray, out hit)){
			Vector3? newTarget = hit.point;
//			Debug.Log(newTarget);
			return newTarget;
		}

		return null;
	}

}
