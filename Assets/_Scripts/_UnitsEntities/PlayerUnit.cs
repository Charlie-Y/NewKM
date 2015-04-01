using UnityEngine;
using System.Collections;


/// <summary>
/// Player OHHH MAN
/// 
/// 
/// what does this deal with? everything! yaya!
/// </summary>
public class PlayerUnit : Unit {

	override public bool isPlayer { get {return true;} set {} }
	override public bool isEnemy { get {return false;} set {} } //lol
	override public string unitName { get {return "PlayerUnit";} set {} }


	// should be set by shield
	public Shield shield;

	[HideInInspector]
	public int maxEnergy = 100;
	[HideInInspector]
	public int currentEnergy = 100;
	[HideInInspector]
	public int energyRegen = 0; // per second
	

	public override void Start ()
	{
		base.Start ();

		shield = GetComponent<Shield>();
	}

	protected override void CalculateHit (Weapon w)
	{
		// useful because some projectiles move too fast
		if (shield.shieldOn){
			ShieldHit(w);
		} else {
			base.CalculateHit(w);
		}

	}

	public float GetEnergyPercentage(){
		return (float)currentEnergy/ (float) maxEnergy;
	}


	//Sent by weapon entity
	void ShieldHit(Weapon w){
		Debugger.Log("Shield", "ShieldHit");
	}

	public override void NoHealth(Weapon w){
//		Debugger.Log ("Weapon", uniqName + " has died" );
		RemoveFromFightManager();
		gameObject.SetActive(false);
	}
}
