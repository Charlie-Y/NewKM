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
//		return;

		if ( (transform.position - entity.transform.position).magnitude < followDist)
			return;

//		Vector3 newPos = Vector3.Lerp(transform.position, entity.transform.position, Time.deltaTime * camSpeed);

		Vector2 myXZ = new Vector2( transform.position.x, transform.position.z);
		Vector2 otherXZ = new Vector2( entity.transform.position.x, entity.transform.position.z);


		Vector3 newPos = Vector2.Lerp(myXZ, otherXZ, Time.deltaTime * camSpeed);
		newPos.z = newPos.y;

//		Vector3 newPos = entity.transform.position;
		newPos.y = 30f;

		transform.position = newPos;
	}
}
