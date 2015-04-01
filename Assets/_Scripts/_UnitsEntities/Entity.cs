using UnityEngine;
using System.Collections;


/// <summary>
/// Cell entity.
/// 
/// Belongs on a cell
/// 
/// Just keep it responsible for tracking collisions and which cell it's attached to.
/// 
/// </summary>
public abstract class Entity : MonoBehaviour {


	public Unit unit; // set by the unit in AddEntity
	public float size; // should be the size of the rendered thing

	public bool isEnemy(){
		return unit.isEnemy;
	}

	void Awake(){

	}

	void Start(){
		// Check for sprite Renderer
//		if ( GetComponent<SpriteRenderer>() ==  default(SpriteRenderer) ){ 
//			Debug.LogWarning(unit.unitName + "'s entity does not have a sprite attached");
//		} else {
//			Debug.Log ("fine");
//		}


//		ScaleSpriteToSize();

	}

	/// <summary>
	/// Sets the localScale to make sure the size of the entity is right
	/// </summary>
	void ScaleSpriteToSize(){
		transform.localScale = new Vector3(0.5f,0.5f,1f);
	}

	/// <summary>
	/// Entity hit by the weapon stuff
	/// </summary>
	/// <param name="other">Other.</param>
//	void EntityHit( Weapon w){
//		Debugger.Log("Weapon", unit.unitName + " hit");
//
//
//
//	}
}
