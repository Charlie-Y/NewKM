using UnityEngine;
using System.Collections;



public class BasicGun : Weapon {

	public override WeaponT type {get {return WeaponT.gun;} set{} } // Set these in the inspector
	public override WeaponV variation {get {return WeaponV.normal;} set{} } // that will determine the weapon type

	//protected void Set(int dmg, float rge, float rm, float speed, float c, string n){
	protected override void SetupFields ()
	{
		Set( 10 , 6f, 0.8f, 9f, .2f, this.GetType().ToString());
	}

}
