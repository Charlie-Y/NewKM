using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Util {



	public static GameObject InitWithParent(GameObject prefab, GameObject parent ){
		GameObject instance = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		if (parent != null)
			instance.transform.SetParent(parent.transform);
		return instance;
	}

	public static T RandomFromList<T>(List<T> list){
		return list[ Random.Range( 0, list.Count )];
	}

}



/// <summary>
/// A boolean field that will let you know if something has hit a cooldown
/// 
/// I wonder how some things will work...
/// 
/// The basic one will just return false until a time has passed, in which 
/// 
/// </summary>
public class CooldownField{

	private float cooldownTime = 0;
	private float time;
	private float fireTime;

	/// <summary>
	/// If set to false, then the field will automatically enterCooldown
	/// after the first check returns true
	/// </summary>
	private bool requireFire = true;

	public CooldownField(){
		Setup();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="CooldownField"/> class.
	/// </summary>
	/// <param name="time">Time afer fire that this will return true.</param>
	/// <param name="startOnCooldown">If set to <c>true</c> start on cooldown and force a wait for the first true check.</param>
	public CooldownField(float cTime, bool reqFire = true){
		cooldownTime = cTime;
		requireFire = reqFire;

		Setup();
	}

	void Setup(){
		time = Time.time;
		fireTime = time + cooldownTime;
	}

	/// <summary>
	/// Check if the cooldown is finished. Should be called in something related to Update()
	/// </summary>
	public bool Check(){
		bool result = Time.time > fireTime;
		if (result && !requireFire)
			Fire();

		return result;
	}

	/// <summary>
	/// Sets the cooldownField to be on cooldown and waits for the time. 
	/// </summary>
	public void Fire(){
		fireTime = Time.time + cooldownTime;
	}

	/// <summary>
	/// Guarantees the next Check() returns true
	/// </summary>
	public void Clean(){
		fireTime = 0;
	}

}
