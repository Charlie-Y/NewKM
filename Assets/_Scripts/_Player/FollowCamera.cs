using UnityEngine;
using System.Collections;

/// <summary>
/// Script that tells the camera to follow hte player
/// 
/// make sure its not the only one
/// </summary>
public class FollowCamera : MonoBehaviour {

	Camera cam;
	PlayerEntity entity;
	public float camSpeed = 2f; // some values of this make camera lag. hmm
	public float followDist = 50f; 

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
		entity = (PlayerEntity) (GameObject.FindWithTag("Player").GetComponent<PlayerUnit>().GetEntity());
	}
	
	// Update is called once per frame
	void Update () {
		if ( (transform.position - entity.transform.position).magnitude < followDist)
			return;

		Vector3 newPos = Vector3.Lerp(transform.position, entity.transform.position, Time.deltaTime * camSpeed);
		newPos.z = -10;
		transform.position = newPos;
	}
}
