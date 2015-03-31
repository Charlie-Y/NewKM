using UnityEngine;
using System.Collections;


/// <summary>
/// Kill on awake.
/// 
/// Try to compile this first
/// </summary>
public class KillOnAwake : MonoBehaviour {

	// Set in inspector
	public bool on = true;

	void Awake(){
		if (on)
			Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
