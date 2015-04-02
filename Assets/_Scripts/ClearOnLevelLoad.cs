using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Clears children on level load
/// 
/// attached ot things like the ingame canvas
/// </summary>
public class ClearOnLevelLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded(int level){
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		foreach ( GameObject child in children){
			child.transform.SetParent(null);
			GameObject.Destroy(child);
		}
	}
}
