﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Unit type. Denotes an overarching Genus for a thing. 
/// 
/// Allows multiple units to be placed under one header - like multiple units classified as defenders
/// and multiple units classified as rangers
/// 
/// for AI purposes
/// 
/// Units have both a genus and a species. 
/// 
/// </summary>
public enum UnitGenus { normal, ranged, defender, melee, beacon }
public enum UnitSpecies { normal, sniper, soldier, shield, melee }

/// <summary>
/// Unit
/// 
/// 
/// The basic unit is attached to a prefab
/// its cell entities are added as children
/// 
/// the unit is responsible for managing and spawning its cell entities. 
/// also all the logic behind trying to move and attack etc.
/// 
/// also repsonsible for managing its weapons
/// 
/// </summary>
public abstract class Unit : MonoBehaviour {

	// Used for assigning specific ids
	public static int ids = 0; 

	virtual public bool multipleEntities { get {return false;} set {} }
	virtual public bool isPlayer { get {return false;} set {} }
	virtual public string unitName { get {return "Unit";} set {} }

	public string uniqName { get {return unitName + ": " + id;} set {} }

	//public bool _isEnemy;
	abstract public bool isEnemy {get; set;}

	protected int id = 0;
	[HideInInspector]
	public AIBrain brain;
	[HideInInspector]
	public UnitHealth health;

	public GameObject basicEntityPrefab; // Set in inspector
	public UnitGenus genus = UnitGenus.normal; // set in inspector
	public UnitSpecies species = UnitSpecies.normal; // set in inspect

	[HideInInspector]
	public bool hasWeapon = false;

	List<Entity> entities = new List<Entity>();
	List<Weapon> weapons = new List<Weapon>();

	protected virtual void Awake(){
		InitEntities();
		id = Unit.ids++;
		gameObject.name += ": " + id.ToString();
	}
	
	// Use this for initialization
	public virtual void Start () {
		AddToFightManager();
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}

	protected virtual void AddToFightManager(){
		FightManager.instance.AddUnit(this);
	}

	protected virtual void RemoveFromFightManager(){
		FightManager.instance.RemoveUnit(this);
	}

	protected virtual void InitEntities(){
		if (transform.childCount == 0){
			InitSpawnEntities();
		} else {
			//Add the entities to the tracking
			foreach (Transform child in transform){
				Entity cent = child.gameObject.GetComponent<Entity>();
				if (cent != null){
					AddEntity(cent);
				}
			}
		}
	}

	/// <summary>
	/// Called if the prefab doesn't have any cell entities attached to it. 
	/// </summary>
	protected virtual void InitSpawnEntities ()
	{
		GameObject instance = Instantiate(basicEntityPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		instance.transform.SetParent(transform);
		AddEntity(instance.GetComponent<Entity>());
			//		throw new System.NotImplementedException ();
	}


	/// <summary>
	/// Starts at position. Assumes not multiple entites
	/// </summary>
	public virtual void StartAtPos(int x, int y ){
//		Cell startCell = GridManager.instance.GetCell(x, y);
//		GetEntity().SetCell(startCell);
	}

	public virtual Entity GetEntity(int index = 0){
		return entities[index];
	}

	protected virtual void AddEntity(Entity cent){
		entities.Add(cent);
		cent.unit = this;
	}

	//
	protected virtual void RemoveEntity(Entity cent){
		//TODO bother implementing
	}

	public virtual void AddWeapon(Weapon w){
		weapons.Add(w);
	}

	public virtual Weapon GetWeapon(int index = 0){
		return weapons[index];
	}

	/// <summary>
	/// Called when the unit runs out of health. 
	/// </summary>
	public virtual void NoHealth(Weapon w){
		Debugger.Log ("Weapon", uniqName + " has died" );

		RemoveFromFightManager();
		Destroy(gameObject);
	}

	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name="w">The width.</param>
	void TakeDamage(Weapon w){
		CalculateHit(w);
	}


	/// <summary>
	/// Lots of logic... hmm armor?
	/// </summary>
	/// <param name="w">The width.</param>
	protected virtual void CalculateHit(Weapon w){
		health.CalculateDamage(w);
	}


}
