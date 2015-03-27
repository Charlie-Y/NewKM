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

	public static int minX = -6;
	public static int maxX = 6;
	public static float maxY = 3.5f;
	public static float minY = -3.5f;

	public static float spriteDim;
	
	public int x; // col. There are 10 cols
	public int y; // row. There are 4 rows

	public static bool setup = false;

	List<CellEntity> entities = new List<CellEntity>();

	// assume just one for now
	public bool hasEntity = false;
	public CellEntity currentEntity = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}






	public void Setup(int nx, int ny){

		if (!setup){
			SpriteRenderer sr = GetComponent<SpriteRenderer>();
			Cell.spriteDim = sr.sprite.bounds.extents[0] * 2;
			//			Debugger.Log("Grid", sr.sprite.vertices[1]);
			setup = true;
		}

		x = nx;
		y = ny;
		
		// The cells take up the entire floor or something
		Vector3 newPos = new Vector3();

		float cellDim = (Cell.maxX - Cell.minX) / Cell.numCols; // should be uhh, 100/10 = 10..

		float cellScale = cellDim / Cell.spriteDim;

		// the .5 accounts for the position being in the center of the cell
		float dx = ((float)x + 0.5f) * cellDim;
		float dy = ((float)y + 0.5f) * cellDim;

		newPos.x = Cell.minX + dx;
		newPos.y = Cell.minY + dy;

		transform.position = newPos;
		transform.localScale = new Vector3(cellScale, cellScale, 1);

	}



}
