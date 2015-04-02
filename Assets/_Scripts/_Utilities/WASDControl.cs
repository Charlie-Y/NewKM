using UnityEngine;
using System.Collections;

public class WASDControl : MonoBehaviour {

	public float speed = 300f;
//	private Vector3 pos;

	private Rigidbody2D rb; 

	void Start() {
//		pos = transform.position;
		rb = GetComponent<Rigidbody2D>();

	}
	
	void Update() {
		float x = 0;
		float y = 0;
		bool input = false;

//		if (Input.A(KeyCode.W)){
//			y += speed;
//			input = true;
//		}
//		if (Input.GetKeyDown(KeyCode.S)){
//			y -= speed;
//			input = true;
//
//		}
//		if (Input.GetKeyDown(KeyCode.A)){
//			x -= speed;
//			input = true;
//		}
//		if (Input.GetKeyDown(KeyCode.D)){
//			x += speed;
//			input = true;
//		}

		x = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
		y = speed * Input.GetAxis("Vertical") * Time.deltaTime;

		if (y != 0f || x != 0f)
			input = true;

//		Vector2 newPos = transform.parent.position;
//		newPos.x += x;
//		newPos.y += y;
		
		if (input)
//			rb.AddForce(new Vector2(x, y));
			rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
//			transform.parent.transform.position = newPos;
	}
}
