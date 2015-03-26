#pragma strict

/*

Spawnmanager is something that deals with creating enemies etc...
Putting the player down somewhere

*/

//Singleton

public static var instance : SpawnManager;

public var enemiesPerWave : int = 12;
public var enemiesSpawned : int = 0;
public var enemiesActive : int = 0;
public var waveStarted : boolean = false;


// Inspector var
public var enemyPF : GameObject;


function Awake () {
	instance = this;
}

function Start () {

		// for (var i:int = 0; i< 100; i ++){
		// 	Debug.Log(Util.randInt(0,4));
		// }


		// Once we figure out the prefab things
	// enemiesActive++;
	// enemiesSpawned++;
}

function Update () {
	if (shouldSpawnEnemy()){
		spawnNextEnemy();
	}
}

// Enemy Stuff
function shouldSpawnEnemy() : boolean{
	// real conditions later

	return enemiesActive == 0 && enemiesSpawned < enemiesPerWave;
}

function spawnNextEnemy(){

	enemiesSpawned++;
	enemiesActive++;

	var newEnemy : EnemyUnit = Instantiate(pickNextEnemy(), Vector3.zero, Quaternion.identity).GetComponent("EnemyUnit") as EnemyUnit;

}

function pickNextEnemy() : GameObject{
	return enemyPF;
}

function enemyDied(){
	enemiesActive--;
}


// Ally stuff
function shouldSpawnAlly(){

}

function spawnAlly(){

}


