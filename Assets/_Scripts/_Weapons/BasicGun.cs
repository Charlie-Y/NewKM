using UnityEngine;
using System.Collections;

public class BasicGun : Weapon {

	public override WeaponT type {get {return WeaponT.gun;} set{} } // Set these in the inspector
	public override WeaponV variation {get {return WeaponV.normal;} set{} } // that will determine the weapon type

	protected override void SetupFields ()
	{
		Set( 60 ,6f, 0.8f, 3f, 1f, this.GetType().ToString());
	}

}
