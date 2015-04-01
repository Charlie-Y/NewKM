using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Fight manager.
/// 
/// Does everything related to the arc of a fight, starting, waves, ending
/// 
/// 
/// </summary>
public class FightManager : MonoBehaviour {

	// Fightmanagers load GridData for 
	GridData currentData;/// <summary>
	/// The current wave.
	/// </summary>
	int currentWave;

	public static FightManager instance;

//	List<Unit> units = new List<Unit>();
	public List<Unit> alliedUnits = new List<Unit>();
	public List<Unit> enemyUnits = new List<Unit>();
	public PlayerUnit playerUnit;


	// Set in insprctor for now
	public GameObject basicEnemyUnitPrefab; 
	public GameObject basicAllyUnitPrefab; 

	// just for organization, put them under a gameobject
	public GameObject unitParent;
	public GameObject weaponEntityParent;


	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
	}

	// Use this for initialization
	void Start () {
		playerUnit = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUnit>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void Init(){
		LoadGridData();
		StartFight();
	}

	void LoadGridData(){

	}

	void StartFight(){
		SpawnWave();
	}

	void SpawnWave(){

		Debug.Log("SpawnWabe");

		// spawn an enemy
		// spawn an ally
//		SpawnUnitAtPos(basicEnemyUnitPrefab, 8, 1);
//		SpawnUnitAtPos(basicEnemyUnitPrefab, 8, 2);

//		SpawnUnitAtPos(basicAllyUnitPrefab, 1, 2);.
//		SpawnUnitAtPos(basicAllyUnitPrefab, 2, 2);
	}

	Unit SpawnUnitAtPos(GameObject unitPrefab, int x, int y){
		GameObject instance = Util.InitWithParent(unitPrefab, unitParent);
		Unit u = instance.GetComponent<Unit>();
		u.StartAtPos(x,y);

//		if (u.isEnemy){
//			enemyUnits.Add(u);
//		} else {
//			alliedUnits.Add(u);
//		}

		return u;
	}


}












