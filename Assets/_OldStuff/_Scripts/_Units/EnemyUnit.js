#pragma strict

public class EnemyUnit extends Unit{

	// var unitName :String = "Enemy Unit";

	private var timeOfLastMove :float = 0;
	public var timeToMove :float = 1;


	function Start(){

		Debug.Log("EnemyUnit created");

		unitName = "Enemy Unit";
		
		entities[0] = gameObject.GetComponent(EnemyEntity) ;
		mainEntity = entities[0];
		mainEntity.unit = this;

		setupOnGrid();
		super.Start();
	}

	

	function Update(){
		var timeSinceLastMove :float = Time.time - timeOfLastMove;

		if (timeSinceLastMove > timeToMove){
			mainEntity.setNewPosition( Grid.instance.randomPosRight());
			// Debug.Log("moving");
			timeOfLastMove = Time.time;
		}
	}

	function moveEntities(){
		mainEntity.setNewPosition( Grid.instance.randomPosRight());
	}
		

	function setupOnGrid(){
		mainEntity.setNewPosition( Grid.instance.randomPosRight());
	}


	function die(){
		super.die();
		SpawnManager.instance.enemyDied();
	}
}