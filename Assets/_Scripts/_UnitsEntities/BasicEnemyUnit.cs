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
	public GameObject basicCellEntityPrefab; 

	//gar c#!!!
	public override bool isEnemy {
		get { return true; }
		set { }
	}


	protected override void InitSpawnEntities ()
	{
		GameObject instance = Instantiate(basicCellEntityPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		instance.transform.SetParent(transform);

//		throw new System.NotImplementedException ();
	}


}
