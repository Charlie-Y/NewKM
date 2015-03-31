using UnityEngine;
using System.Collections;



public class BasicAllyUnit : Unit {

	public override bool isEnemy {
		get { return false; }
		set { }
	}
	override public string unitName { get {return "AllyUnit";} set {} }




}
