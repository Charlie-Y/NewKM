#pragma strict

public class PlayerUnit extends Unit{

	
	//Inspector for now
	public var mainAttack : Attack;

	function Start () {
		unitName = "Player Unit1";
		// Debug.Log(gameObject.GetComponent(PlayerEntity) );
		entities[0] = gameObject.GetComponent(PlayerEntity) ;
		mainEntity = entities[0];
		mainEntity.unit = this;

		setupOnGrid();


		mainAttack = gameObject.AddComponent.<Attack>();

		super.Start();
	}


	function Update () {
		if (InputMap.isAnyGridButtonDown()){
			var v : Vector2 = InputMap.getGridButtonDown();
			if (Grid.instance.isGridLeft(v)){
				moveEntity(v);				
			} else { //if (Grid.isGridRight(v)){
				launchAttack(v);
			}
		}

		super.Update();
	}

	// Just put it somewhere arbitrary
	function setupOnGrid(){
		mainEntity.setNewPosition( Grid.instance.randomPosLeft());
	}

	/*
	
	

	*/
	function moveEntity(v :Vector2){
		mainEntity.setNewPosition(v);
	}


	//
	function launchAttack(v: Vector2){
		// Debug.Log("Player attacking: " + v.ToString());
		
		mainAttack.apply(v);
	}

}