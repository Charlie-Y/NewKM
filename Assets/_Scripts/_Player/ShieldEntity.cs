using UnityEngine;
using System.Collections;

/// <summary>
/// Shield entity script. passes things and messages to parent etc..
/// </summary>
public class ShieldEntity : MonoBehaviour {

	Shield shield;
	public GameObject toFollow; // set by Shield.cs
	bool isSetup = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isSetup)
			transform.position = toFollow.transform.position;
	}

	public void Setup(Shield s){
		toFollow = s.unit.GetEntity().gameObject;
		isSetup = true;
	}


}
