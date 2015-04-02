using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Represesnts a cell in teh grid. actually attached to a cell object
/// 
/// stored in the GridManager.Instance.cells
/// </summary>
public class Cell : MonoBehaviour {

	public static int numRows = 4;
	public static int numCols = 10;
	public static float maxX = 6f;
	public static float minX = -6f;
	public static float maxY = 3f;
	public static float minY = -3f;
	public static float spriteDim;
	
	public int x; // col. There are 10 cols
	public int y; // row. There are 4 rows

	public static bool spriteSetup = false;


	// only one entity. but lets just 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/// <summary>
	/// Tries to add the entity to this cell
	/// 
	/// assumes the CellEntity tracks the previous cell
	/// 
	/// 
	/// 
	/// </summary>
	/// <returns><c>true</c>, if add entity was successfully added , <c>false</c> otherwise.</returns>
	/// <param name="cent">Cent.</param>
//	public bool TrySetEntity(CellEntity cent){
//		if (hasEntity){
//			return false;
//		} else {
//			hasEntity = true;
//			currentEntity = cent;
//			return true;
//		}
//	}
//
//	public bool RemoveEntity(){
//		if (!hasEntity){
//			return false;
//		} else {
//			hasEntity = false;
//			currentEntity = null;
//			return true;
//		}
//	}






	public void Setup(int nx, int ny){

		if (!spriteSetup){
			SpriteRenderer sr = GetComponent<SpriteRenderer>();
			Cell.spriteDim = sr.sprite.bounds.extents[0] * 2;
			//			Debugger.Log("Grid", sr.sprite.vertices[1]);
			spriteSetup = true;
		}

		x = nx;
		y = ny;
		
		// The cells take up the entire floor or something
		Vector3 newPos = new Vector3();

		float cellDimX = (Cell.maxX - Cell.minX) / (float)Cell.numCols; // should be uhh, 100/10 = 10..
		float cellDimY = (Cell.maxY - Cell.minY) / (float)Cell.numRows;

//		Debug.Log ("Cell.maxX" + Cell.maxX.ToString());
//		Debug.Log ("CellDim: " + cellDim.ToString());

		float cellScaleX = cellDimX / Cell.spriteDim;
		float cellScaleY = cellDimY / Cell.spriteDim;

		// the .5 accounts for the position being in the center of the cell
		float dx = ((float)x + 0.5f) * cellDimX;
		float dy = ((float)y + 0.5f) * cellDimY;

		newPos.x = Cell.minX + dx;
		newPos.y = Cell.minY + dy;

		transform.position = newPos;
		transform.localScale = new Vector3(cellScaleX, cellScaleY, 1);

	}



}
