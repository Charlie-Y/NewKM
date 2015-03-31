using UnityEngine;
using System.Collections;

/// <summary>
/// Basic enemy unit.
/// 
/// Does a bunch of things
/// 
/// </summary>
public class BasicEnemyUnit : Unit {

	// Set in inspector
	override public string unitName { get {return "EnemyUnit";} set {} }

	//gar c#!!!
	override public bool isEnemy { get { return true; } set { } }




}
