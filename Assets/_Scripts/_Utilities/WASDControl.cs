using UnityEngine;
using System.Collections;

public class WASDControl : MonoBehaviour {

	public float speed = 300f;
//	private Vector3 pos;

	private Rigidbody rb; 

	void Start() {
//		pos = transform.position;
		rb = GetComponent<Rigidbody>();

	}
	
	void Update() {
		float x = 0;
		float z = 0;
		bool input = false;

		x = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
		z = speed * Input.GetAxis("Vertical") * Time.deltaTime;

		if (z != 0f || x != 0f)
			input = true;

//		Vector3 newPos = transform.position;
//		newPos.x += x;
//		newPos.z += z;

		
		if (input)
//			rb.AddForce(new Vector2(x, y));
			rb.AddForce(new Vector3(x, 0, z), ForceMode.Impulse);
//			transform.position = newPos;
	}
}
