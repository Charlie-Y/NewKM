using UnityEngine;
using System.Collections;


/// <summary>
/// Shield held by a player. Perhaps defenders will be able to use them as well...
/// 
/// 
/// 
/// 
/// </summary>
public class Shield : MonoBehaviour {

	// Set in inspector/prefab
	// should have a ShieldEntity Script attached
	public GameObject shieldEntityPrefab;
	[HideInInspector]
	public Unit unit;

	// This is the shield obj which you turn on and off
	GameObject entity;
	public bool shieldOn = false; // stupid overhead for now

	// Use this for initialization
	void Start () {
		unit = GetComponent<Unit>();
		entity = Util.InitWithParent(shieldEntityPrefab, gameObject);

		entity.GetComponent<ShieldEntity>().Setup(this);

		ShieldOff();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			ShieldOn();
		} 

		if (Input.GetKeyUp(KeyCode.Space)){
			ShieldOff();
		} 
	}

	void ShieldOn(){
		shieldOn = true;
		entity.SetActive(shieldOn);
	}

	void ShieldOff(){
		shieldOn = false;
		entity.SetActive(shieldOn);
	}

//	public void TakeDamage(Weapon w){
//		Debugger.Log("Shield", "TakeDamage");
//	}

	// Sent by WeaponEntity. maybe i could just send this to the unit...
	// sigh this is roundabout
//	public void ShieldHit(Weapon w){
//		Debugger.Log("Shield", "ShieldHit");
//		if (unit.isPlayer)
//			unit.SendMessage("OnShieldHit", w);
//	}

	void OnDeath(){
		Destroy(entity);
	}

}
