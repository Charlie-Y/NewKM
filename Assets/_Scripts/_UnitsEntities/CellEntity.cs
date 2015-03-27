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
public abstract class CellEntity : MonoBehaviour {


	protected Cell currentCell;
	protected Cell previousCell;
	public Unit unit; // set by the unit in AddEntity

	public bool isEnemy(){
		return unit.isEnemy;
	}

	public void SetCell(Cell cell){
//		previousCell.
		previousCell = currentCell;
		currentCell = cell;
		currentCell.currentEntity = this;
		currentCell.hasEntity = true;

		if (previousCell != null){
			previousCell.hasEntity = false;
			previousCell.currentEntity = null;
		}	

		transform.position = currentCell.gameObject.transform.position;
	}


}
