using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 
/// Attach to the HUDCanvas
/// 
/// Finds HUDcamera set and sets the Canvas Element to it
/// 
/// HUD camera should have a tag on it
/// </summary>
public class FindHUDCamera : MonoBehaviour {

	Canvas canvas;

	void Awake(){
		canvas = GetComponent<Canvas>();
		Setup();
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (canvas.worldCamera == null){
			Setup();
		} else {
			Vector3 newPos = canvas.worldCamera.transform.position;
			newPos.z = 0;
			transform.position = newPos;
		}


	}

	void Setup(){
		canvas.worldCamera = GameObject.FindWithTag("HUDCamera").GetComponent<Camera>();
	}

}
