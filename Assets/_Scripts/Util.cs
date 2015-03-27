using UnityEngine;
using System.Collections;

public static class Util {

	public static GameObject InitWithParent(GameObject prefab, GameObject parent ){
		GameObject instance = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		instance.transform.SetParent(parent.transform);
		return instance;
	}


}
