﻿using UnityEngine;
using System.Collections;

public class WeaponEntity : MonoBehaviour {

	public Weapon w;
	public Vector3 target;
	public float someSpeed;
	public bool setup = false;
	public bool isEnemy = false;

	// Set sprites in inspector
	public Sprite enemySprite;
	public Sprite allySprite;

	float range;
	Vector3 direction;
	Vector3 startPosition;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (setup){

			if (isOutOfRange()){
				Debugger.Log("Weapon", "Out of range");
//				gameObject.SetActive(false);
				Destroy(gameObject);
			}

//			transform.position = Vector2.MoveTowards(transform.position, target, someSpeed * Time.deltaTime);
			Vector3 newPos = transform.position;
			newPos += (direction * someSpeed * Time.deltaTime);
			transform.position = newPos;
		}
	}

	public void Setup(Weapon wep, Entity t, float s){
		w = wep;
		target = t.transform.position;


		direction = target - transform.position ;
		direction.Normalize();
		startPosition = transform.position;

		someSpeed = s;
		setup = true;
		isEnemy = wep.owner.isEnemy;
		range = wep.range;

		GetComponent<SpriteRenderer>().sprite = isEnemy ? enemySprite : allySprite;
		
	}

	bool isOutOfRange(){
		Vector3 v = startPosition - transform.position;
		return (v.magnitude > range);
	}

	/// <summary>
	/// Same as the side as other.
	/// </summary>
	/// <returns><c>true</c>, if other object is on same side or has no unit <c>false</c> otherwise.</returns>
	bool SameSideAsOther(GameObject other){
		if ( other.tag == "Shield"){
			Shield s = other.GetComponent<ShieldEntity>().shield;
			return ((isEnemy && s.unit.isEnemy) || (!isEnemy && !s.unit.isEnemy)) ;
		}

		Entity ent = other.GetComponent<Entity>();
		if (ent == null){
			Debugger.Log ("Weapon", other.name + " entity is null");
			return false;
		}

		return ( (isEnemy && ent.unit.isEnemy) || (!isEnemy && !ent.unit.isEnemy) );
	}

//	void OnCollisionEnter2D(Collision2D other){
//	void OnTriggerEnter2D(Collider2D other){
	void OnTriggerEnter(Collider other){
//		Debugger.Log("Weapon", "Hit: " + other.gameObject.name);
//		Debugger.Log("Weapon", "Hit: " + other.tag);
		if (SameSideAsOther(other.gameObject))
			return;
		if (w.owner != null){
			if (other.gameObject.GetComponent<Entity>() == w.owner.GetEntity()){ // Stop hitting yourself. stop hitting yourself
				return;
			}
		}

		if (other.tag == "GridWall"){
			//The gridwalls need rigidbody2ds for this to work
			// also fails on lasers and such
			Destroy(gameObject);

		} else {
			if ( other.tag == "Shield"){
				other.transform.parent.SendMessage("ShieldHit", w, SendMessageOptions.DontRequireReceiver);
			} else {
				other.transform.parent.SendMessage("TakeDamage", w, SendMessageOptions.DontRequireReceiver);

			}
//			Debugger.Log("Shield", "Hit: " + other.gameObject.name);
//			Debugger.Log("Weapon", "Hit: " + other.gameObject.transform.parent.name);
			Destroy(gameObject);
		}



	}

}
