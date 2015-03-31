using UnityEngine;
using System.Collections;


/// <summary>
/// Unit health tracker
/// 
/// 
/// also responsible for displaying health, and telling the main unit it is out of health
/// 
/// 
/// for multiple entities per unit hell if i care
/// </summary>
public class UnitHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth = 100;
	public bool invincible = false;

	Unit unit;

	void Awake(){
		unit = GetComponent<Unit>();
		unit.health = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Maybe have some kind of armor system...
	// later
	public void TakeDamage(Weapon w){
		if (invincible)
			return;

		// Take into consideration unit armor
		currentHealth -= w.damage;

		if (currentHealth <= 0){
			unit.NoHealth(w);
		}


	}
}
