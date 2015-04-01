using UnityEngine;
using System.Collections;

public class BeaconBrain : AIBrain {

	// I'm going to need a prefab retreival system
	public GameObject spawnPrefab;

	CooldownField spawnCD;
	float spawnTime = 3f;
	float spawnRadius = 1f;
	int numToSpawn = 3;

	public bool infiniteSpawn = false;


	public override void Awake ()
	{
		base.Awake ();

		spawnCD = new CooldownField(spawnTime);

	}
	

	protected override void DetermineStrategy(){
		switch(currentStrat){
		case AIStrategy.none: case AIStrategy.waiting :
			if (numToSpawn > 0 || infiniteSpawn)
				currentStrat = AIStrategy.spawning;
			break;
		}
	}
	
	protected override void ExecuteStrategy(){
		switch(currentStrat){
		case AIStrategy.none: case AIStrategy.waiting :
			break;
		case AIStrategy.spawning:
			if (numToSpawn <= 0 && !infiniteSpawn)
				currentStrat = AIStrategy.none;

			if (spawnCD.Check()){
				spawnCD.Fire();
				SpawnNearby();
				numToSpawn--;
			}

			break;
		}
	}

	protected void SpawnNearby(){
		if (spawnPrefab == null){
			Debug.LogError(unit.uniqName + "'s beaconbrain has no spawnprefab");
			return;
		}

		GameObject unitParent = FightManager.instance.unitParent;
		GameObject thing = Util.InitWithParent(spawnPrefab, unitParent); 
		thing.transform.position = unit.GetEntity().transform.position;
	}

}
