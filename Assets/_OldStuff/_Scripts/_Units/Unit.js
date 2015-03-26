#pragma strict


// There are a max of 16 entities that can belong to a unit anyways...?
//	 Nah lets use Arrays
protected var entities : GridEntity[] = new GridEntity[16];
protected enum UnitType{ Base, Player, Ally, Enemy};

protected var unitType: UnitType = UnitType.Base;

// var entities : Array;
public var unitName : String = "BaseUnit";
protected var mainEntity : GridEntity;

function Start () {
	// generateEntities();
}

function Update () {

}


// Generates the appropriate entities for this class
function generateEntities(){

}

// Moves the entities around
function moveEntities(){

}

// grid pos to start at
function spawnAt(){

}

// Chooses an attack and fires it
// Has to take into consideration entities?
// Perhaps it fires attacks from entities?
function launchAttack(){

}

function ToString(){
	return unitName;
}

function die(){
	Destroy(gameObject);
}


