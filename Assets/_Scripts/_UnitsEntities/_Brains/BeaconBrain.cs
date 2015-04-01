using UnityEngine;
using System.Collections;

public class BeaconBrain : AIBrain {

	// I'm going to need a prefab retreival system
	public GameObject spawnPrefab;

	CooldownField spawnCD;
	float spawnTime = 3f;
	float spawnRadius = 20f;
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
				SpawnNearby(3);
				numToSpawn--;
			}

			break;
		}
	}


	protected void SpawnNearby(int times = 1){
		if (spawnPrefab == null){
			Debug.LogError(unit.uniqName + "'s beaconbrain has no spawnprefab");
			return;
		}


		for(int i = 0; i < times; i++){
			GameObject unitParent = FightManager.instance.unitParent;
			GameObject thing = Util.InitWithParent(spawnPrefab, unitParent); 

			Vector3 newPos = unit.GetEntity().transform.position;
			Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
			newPos.x += randomCircle.x;
			newPos.y += randomCircle.y;


			thing.transform.position = newPos;
		}
	}

}
