using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Responsible for storing and managing references to the cells
/// 
/// also setsup the grid
/// </summary>
public class GridManager : MonoBehaviour {

	
	// Set in inspector
	public GameObject cellPrefab;
	public GameObject cellParent;

	// Not inspector
	public static GridManager instance = null;    
	List<Cell> cells = new List<Cell>();


	void Awake(){
		//Check if instance already exists
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public Cell GetCell(int x, int y){


		int index = y * 10 + x;

//		Debug.Log("indx: " + index);
//		Debug.Log("cells: " + cells.Count.ToString());
		return cells[ index ];

//		return default(Cell); // is this null?
	}

	/// <summary>
	/// Initializes the grid. should only be called once
	/// 
	/// The cols are X, the rows are Y.
	/// 
	/// The grid is a 10col, 4 row deal
	/// and the lower left corner is 0,0
	/// 
	/// </summary>
	/// <param name="something">Something.</param>
	public void InitGrid(int something){

		Debugger.Log("Grid", "InitGrid");

		for( int y = 0; y < 4; y++){
			for (int x = 0; x < 10; x++){

				GameObject instance = Instantiate(cellPrefab, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				Cell cell = instance.GetComponent<Cell>();

				instance.transform.SetParent(cellParent.transform);
				cell.Setup(x, y);
				cells.Add(cell);



			}
		}



	}
}
