using UnityEngine;
using System.Collections;

public enum WeaponT { none, gun, laser, bash, swing} // weapontype
public enum WeaponV { normal, ballistic } // weapon variation

/// <summary>
/// Weapon.
/// 
/// Weapons determine some of the strategy
/// 
/// Should be attached to units gameobjects so that I can reference the prefabs easier
/// 
/// 
/// </summary>
public abstract class Weapon : MonoBehaviour {

	// Just abstract as to make sure it happens
	public abstract WeaponT type {get; set;} // Set these in the inspector
	public abstract WeaponV variation {get; set;} // that will determine the weapon type
	
	// how much raw damage it does
	[HideInInspector]
	public int damage;
	// how far the bullet travels
	[HideInInspector]
	public float range; 
	// how far to be from the enemy based on the range. multiplier
	[HideInInspector]
	public float rangeMod;
	[HideInInspector]
	public float cooldown;
	[HideInInspector]
	public float projectileSpeed;
	[HideInInspector]
	public string weaponName;

	public GameObject projectilePrefab;

	public CooldownField fireCD;
	

	public Unit owner; //setup in Unit.SetupWeapon


	void Awake(){
		owner = GetComponent<Unit>();
		owner.hasWeapon = true;

		owner.AddWeapon(this);

		SetupFields();
		fireCD = new CooldownField(cooldown, false);

		Check();
	}

	// Maybe keep this in a data file somewhere
	// or maybe make this a script by script thing...
	protected abstract void SetupFields();

	protected virtual void Check(){
		if (rangeMod > 1){
			Debug.LogError("Weapon held by " + owner.uniqName + " has a rm > 1 ");
		}
	}

	protected void Set(int dmg, float rge, float rm, float speed, float c, string n){
		damage = dmg;
		range = rge;
		rangeMod = rm;
		projectileSpeed = speed;
		cooldown = c;
		weaponName = n; 
	}


	/// <summary>
	/// Spawns an projectileonE, and tells it where to go.
	/// </summary>
	/// <param name="e">Your target that the weapon projectile will see.</param>
	public virtual void FireAtEntity(Entity e, bool useCooldown ){
		if (!useCooldown || fireCD.Check()){
			GameObject instance = Instantiate(projectilePrefab, owner.GetEntity().transform.position, Quaternion.identity) as GameObject;
			WeaponEntity went = instance.GetComponent<WeaponEntity>();
			went.Setup(this, e, projectileSpeed);
		}
	}
}
