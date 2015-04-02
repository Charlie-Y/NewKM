using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public bool actuallyUse = true;
	// Use this for initialization
	void Awake () {

		if (actuallyUse)
			DontDestroyOnLoad(gameObject);
		
	}
}
