using UnityEngine;
using System.Collections;


/// <summary>
/// Player OHHH MAN
/// 
/// 
/// what does this deal with? everything! yaya!
/// </summary>
public class PlayerUnit : Unit {

	override public bool isPlayer { get {return true;} set {} }
	override public bool isEnemy { get {return false;} set {} } //lol
	override public string unitName { get {return "PlayerUnit";} set {} }
	
	void Start(){
		// don't update the fightmanager for now
	}

}
