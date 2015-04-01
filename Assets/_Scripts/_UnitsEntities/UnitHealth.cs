using UnityEngine;
using UnityEngine.UI;
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

	// Maybe have some kind of armor system...
	// later
	public void CalculateDamage(Weapon w){
		if (invincible)
			return;

		// Take into consideration unit armor

		// send a message to itself! yay!
		gameObject.SendMessage("OnDamageFromWeapon", w);
//		OnDamageFromWeapon(w);
		if (currentHealth <= 0){
//			OnDeath(w);
			gameObject.SendMessage("OnDeath", w);
		}

	}

	public float GetHealthPercentage(){
		return (float)currentHealth/(float)maxHealth;
	}


	void OnDamageFromWeapon(Weapon w){
		currentHealth -= w.damage;
	}

	void OnDeath(Weapon w){
		unit.NoHealth(w);

	}
}
