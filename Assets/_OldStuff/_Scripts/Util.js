#pragma strict

/*


============ Current Practices ============

Uhhh. try to have all the prefabs have all the approiate scripts on them when
they are created


Rechanigng the Architecture... Start scripts are responsible for 

In that way all we need to do is call Instantiate. 

Have the scripts connect to each other in the Start calls.
This may have to change later, because Units aren't always attached to specific
GameObjects...?

I will just accept that I have to use the inspector. Just make sure to
comment all the inspector loaded things...


Not going to use colliders for the moment

============ Class management =============

The Grid tracks the Tiles

Tiles
	track entities on them

Entities 
	track which unit they belong to
	and which tile they are on
	track health and damage
	move Tranforms

Units are responsible for delegating and interfacing
	Tracking and sending Attacks
	Taking Damage
	Tracking Health
	Entities
		Units can have multiple entities, like a body, leg1, leg2
		Units usually have one entity
	Units tell Entities how to move
	
PlayerUnit is a unit 
	that delegates inputs into attacks and movements
	tracks information that the GUI needs
	
EnemyUnits/AllyUnits are units
	that have AIs 
	handle move and attack AI
	
Attacks 
	carry basic info like damage, name, etc
	and also assign damage to tiles

SpawnManager is a static class responsible for generating enemies
	takes into account things like levels
	progress in a level
	etc. 
	

*/

public static class Util {

	var NullPos : Vector2 = new Vector2(-1,-1);
	
	
	function isNullPos( v : Vector2) : boolean{
		return NullPos == v;
	}

	// Random integer in range inclusive
	function randInt(min :int, max :int) :int{
		return min + Mathf.Floor(Random.value * (max - min + 1));
	}

	// simple
	// Uses the == operator?
	// returns -1 on failure
	function ArrayIndexOf(a : Array, val :Object): int{
		for (var i: int; i < a.length; i++){
			if (a[i] == val){
				return i;
			}
		}
		return -1;
	}

	// Removes a matching object from a given array
	function ArrayRemoveElem(a : Array, val : Object) : Object{
		var index :int = ArrayIndexOf(a, val);
		if (index != -1){
			a.RemoveAt(index);
		} else{
			return null;
		}
		return null;
	}


}