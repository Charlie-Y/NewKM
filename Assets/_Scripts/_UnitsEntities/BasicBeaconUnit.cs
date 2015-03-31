using UnityEngine;
using System.Collections;


// Beacons will spawn units... Check the AIbrain for that
public class BasicBeaconUnit : Unit {

	public bool _isEnemy = false; // set in inspector
	public override bool isEnemy {
		get { return _isEnemy; }
		set { }
	}

	override public string unitName { get { return _isEnemy ? "EnemyBeacon" : "AllyBeacon"; } set {} }







}
