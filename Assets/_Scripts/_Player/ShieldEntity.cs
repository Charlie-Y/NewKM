using UnityEngine;
using System.Collections;

/// <summary>
/// Shield entity script. passes things and messages to parent etc..
/// </summary>
public class ShieldEntity : MonoBehaviour {

	[HideInInspector]
	public Shield shield;
	public GameObject toFollow; // set by Shield.cs
	bool isSetup = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	// For some reason this and the unit need to be refreshed. 
	void Update () {
		if (isSetup)
			RefreshPosition();
	}

	public void RefreshPosition(){
		transform.position = toFollow.transform.position;
	}

	public void Setup(Shield s){
		shield = s;
		toFollow = s.unit.GetEntity().gameObject;
		isSetup = true;
	}


}
