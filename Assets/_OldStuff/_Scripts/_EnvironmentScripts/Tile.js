#pragma downcast

public class Tile extends ScriptableObject{

	public var gridPos : Vector2;
	public var entities : Array;
	var transform : Transform;

	//static var prefab : Transform = GameObject.FindWithTag('TileTag');
	//var prefab : GameObject = GameObject.FindWithTag('TileTag');

	function setup(p :Vector2, t : Transform){
		transform = t;
		gridPos = p;
		transform.localScale.x = .1;
		transform.localScale.y = .1;
		// transform.Rotate(Vector2.right, 270);

		entities = new Array();

		name = ToString();
	
	}

	function Start () {
	}

	function Update () {


	}

	function ToString(){
		return "Tile: " + gridPos.ToString();
	}


	function addEntity(e : GridEntity){
		entities.push(e);
	}

	function removeEntity(e : GridEntity){
		var tempEntities : GridEntity[] = entities.ToBuiltin(GridEntity) as GridEntity[];
		ArrayUtility.Remove(tempEntities, e);
		entities = new Array(tempEntities);

	}

	function damageEntities(damage : int){
		for (var e : GridEntity in entities){
			e.takeDamage(damage);
		}
	}
}