#pragma strict


/* 

GridEntities belong to units and ipnhabit tiles on a grid

Tiles use gridentitites to reach units
GridEntities track health.

*/


var unit : Unit;
var currentTile: Tile;
var currentPos: Vector2;

var atNewPos: boolean = true;

// Entities track Health
var health :int;
var MaxHealth :int;

public function get Health() : int {
	return health;
}

public function set Health( value : int ){
	health = value;
}
	


function Start () {

}

function Update () {
	// Debug.Log("FOOO");
	if (!atNewPos)	{
		moveToPosition(currentPos);
		atNewPos = true;
	}
}

/* ------- Damage and Health ------- */

function takeDamage( damage : int){
	Debug.Log("Damage taken");
	health -= damage;

	if (health <= 0)
		die();
}

function die(){
	Debug.Log(unit.unitName + " had died");
	currentTile.removeEntity(this);
	unit.die();

}

/* ------- Movement ------- */
function setNewPosition(p :Vector2){
	// Debug.Log("SetNew at: " + p);
	// Remove from tracking
	if (currentTile != null){
		currentTile.removeEntity(this);
	}


	currentTile = Grid.instance.getTile(p);
	currentTile.addEntity(this);

	currentPos = p;
	atNewPos = false;
}

function moveToPosition(p :Vector2){

	// Debug.Log("Move at: " + p);

	var v : Vector2 = Grid.instance.getXYForGridPos(p);
	var offset: int = Constants.tileDim/2;
	var v3 : Vector3 = new Vector3(v.x + offset, v.y + offset, -1);
	transform.position = v3;
}

function moveToPosition(x:int, y:int){	
	moveToPosition(Vector2(x,y));
}


function ToString(){
	return "Entity for: " + unit.unitName;
}