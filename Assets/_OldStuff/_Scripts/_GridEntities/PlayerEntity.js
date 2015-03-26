#pragma strict

public class PlayerEntity extends GridEntity{


	var anim : Animator;
	protected var idleAnimHash : int = Animator.StringToHash("player_idel");
	protected var moveAnimHash : int = Animator.StringToHash("player_move");


	function Start () {
	// i dunno man.
		super.Start();

		this.Health = 100;
		this.MaxHealth = 100;

		anim = GetComponent("Animator");
	}

	function Update () {
		super.Update();
//		if (InputMap.isAnyGridButtonDown()){
//			var v : Vector2 = InputMap.getGridButtonDown();
//			
//			if (Grid.isGridLeft(v)){
////				Debug.Log("Move at: " + v);
//				
//				v = Grid.getXYForGridPos(v);
//				var offset: int = Constants.tileDim/2;
//				var v3 : Vector3 = new Vector3(v.x + offset, 1, v.y + offset);
//				
//				transform.position = v3;
//				
//			} 
//		}
	}

	// Override
	function moveToPosition(p : Vector2){
		super.moveToPosition(p);

		anim.Play(moveAnimHash);
	}



}