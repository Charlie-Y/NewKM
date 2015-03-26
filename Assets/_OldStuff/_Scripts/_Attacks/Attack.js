#pragma strict

/*

An Attack is something that is applied to a Grid at one point and then the entitites on the Grid.

Attacks are responsible for having specific information special to each attack
Each entity has access to a list of attacks that they can execute. 

*/
 

public enum AttackType { Shot, Beam, PlusBomb};
public var attackName : String = "Basic Attack";
public var attackDamage : int = 10;
public var source: Unit;

// public var attackEntity : AttackEntity;

function Start () {

}

function Update () {

}

// Applies the damage to the Grid tiles.
// Calls affectedTiles - which should be different for each attack
// and damages each entity on them.
function apply( attackPos : Vector2){

	// Draw the animation - needs to create a game object and give it 
	// the animation

	for (var t : Tile in affectedTiles(attackPos) ){
		t.damageEntities( attackDamage );
	}
}


// Returns an array of Tiles
// Attackpos is where the attack is centered. 

function affectedTiles(attackPos : Vector2) : Array{
	var tileArray : Array = new Array();

	var mainTile : Tile = Grid.instance.getTile(attackPos);

	// Debug.Log(mainTile);

	tileArray.push(mainTile);
	return tileArray;
}