using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Unit.
/// 
/// 
/// The basic unit is attached to a prefab
/// its cell entities are added as children
/// 
/// the unit is responsible for managing and spawning its cell entities. 
/// 
/// </summary>
public abstract class Unit : MonoBehaviour {


	virtual public bool multipleEntities { get {return false;} set {} }
	abstract public bool isEnemy {get; set;}

	public int centCount = 0;

	List<CellEntity> entities = new List<CellEntity>();
	
	void Awake(){
		InitEntities();
		
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void InitEntities(){
		if (transform.childCount == 0){
			InitSpawnEntities();
		} else {
			//Add the entities to the tracking
			foreach (Transform child in transform){
				CellEntity cent = child.gameObject.GetComponent<CellEntity>();
				AddEntity(cent);
			}
		}
	}

	/// <summary>
	/// Called if the prefab doesn't have any cell entities attached to it. 
	/// </summary>
	protected abstract void InitSpawnEntities();


	/// <summary>
	/// Starts at position. Assumes not multiple entites
	/// </summary>
	public virtual void StartAtPos(int x, int y ){
		Cell startCell = GridManager.instance.GetCell(x, y);
		GetEntity().SetCell(startCell);
	}

	protected virtual CellEntity GetEntity(int index = 0){
		return entities[index];
	}

	protected virtual void AddEntity(CellEntity cent){
		entities.Add(cent);
		cent.unit = this;
		centCount++;
	}

	//
	protected virtual void RemoveEntity(CellEntity cent){
		//TODO bother implementing
	}


}
