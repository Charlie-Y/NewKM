using UnityEngine;
using System.Collections;

public class WASDControl : MonoBehaviour {

	public float speed = 1f;
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

		x = speed * Input.GetAxis("Horizontal");
		y = speed * Input.GetAxis("Vertical");

		if (y != 0f || x != 0f)
			input = true;
		
		if (input)
//			rb.AddForce(new Vector2(x, y));
			rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
	}
}
