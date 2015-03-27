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
	GridData currentData;
	int currentWave;

	List<Unit> units = new List<Unit>();

	// Set in insprctor for now
	public GameObject basicEnemyUnitPrefab; 
	public GameObject basicAllyUnitPrefab; 

	public GameObject unitParent;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void Init(){
//		blah!

		// spawn the first wave
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
		SpawnUnitAtPos(basicEnemyUnitPrefab, 1, 1);
		SpawnUnitAtPos(basicEnemyUnitPrefab, 2, 2);

	}

	Unit SpawnUnitAtPos(GameObject unitPrefab, int x, int y){
		GameObject instance = Util.InitWithParent(unitPrefab, unitParent);
		Unit u = instance.GetComponent<Unit>();
		u.StartAtPos(x,y);
		return u;
	}


}












