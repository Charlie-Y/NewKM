using UnityEngine;
using System.Collections;



public class BasicGun : Weapon {

	public override WeaponT type {get {return WeaponT.gun;} set{} } // Set these in the inspector
	public override WeaponV variation {get {return WeaponV.normal;} set{} } // that will determine the weapon type

	//Set(int dmg, float rge, float rm, float speed, float cooldown, string n){
	protected override void SetupFields ()
	{
		Set( 45 , 300f, 0.8f, 300f, 2f, this.GetType().ToString());
	}

}
