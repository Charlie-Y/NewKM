#pragma strict

// Encapsulates a lot of the grid math. 
// Also keeps track of all the individual tiles.

//	var tiles[32] : Tile

// X is column number
// y,z is the row number
// Lower left corner is (0,0), upper right corner is ( 7,3)

// THe grid is centered on the screen at (0,0)

private var tiles : Tile[] = new Tile[Constants.xTiles * Constants.yTiles];
// private var tiles : Tile[] = new Tile[100];
public var tileCount :int = 0;
public var tilesSetup :boolean = false;
public var tilePF : GameObject;

public static var instance : Grid;

function Awake(){
	instance = this;
}

function Start () {


	drawGrid();
//		checkGrid();
}

function Update () {
	// if (false){
	// 	Debug.Log("foo")
	// }	
}

public function checkGrid(){
	Debug.Log("Grid size: " + tileCount);
	for( var t : Tile in tiles){
		Debug.Log(t);
		Debug.Log("Should be: " + getTile(t.gridPos));
	}
}

public function drawGrid(){
	
	var spacing: int = 1;

	var xScale: int = 4;
	var zScale: int = 4;
	
	var tileCount : int = 0;

	// var tile : GameObject = GameObject.FindWithTag('TileTag');
	var currentTile : Tile;
	var tempGO : GameObject;

	for (var y = 0; y < Constants.yTiles; y++) {
        for (var x = 0; x < Constants.xTiles; x++) {
        	
//        	var calculatedSpacing : int = (x == 0 || z == 0) ? 0 : spacing; 
			var xSpacing:int = 1;
			var zSpacing:int = 1; 
			var v : Vector2 = getXYForGridPos(x, y);
			var offset: int = Constants.tileDim/2;
            
            // create a new Tile object
            // draw it in the position
            
            
            
            // save it to the array
			currentTile = ScriptableObject.CreateInstance("Tile");
			tempGO = Instantiate(tilePF, Vector3 (v.x + offset, v.y + offset, -1), Quaternion.identity);
         	   
         
            tiles[tileCount] = currentTile;
            currentTile.setup(Vector2(x, y), tempGO.transform);
         

         	// Debug.Log(tileCount);   
            
            tileCount++;
          	            
        }
    }
    
    tilesSetup = true;
}


public function getTile(v :Vector2) : Tile{
	if (tilesSetup){
		return tiles[ v.x + (v.y * Constants.yTiles)];
	}
	return null;
}

public function randomPosRight() : Vector2{
	var x :int = Util.randInt(Constants.xTiles / 2, Constants.xTiles - 1);
	var y :int = Util.randInt(0,Constants.yTiles - 1);
	return Vector2(x, y);
}

public function randomPosLeft() : Vector2{
	var x :int = Util.randInt(0,(Constants.xTiles/2) - 1);
	var y :int = Util.randInt(0,Constants.yTiles - 1);
	return Vector2(x, y);
}


	// Translates
public function getXYForGridPos( p : Vector2) : Vector2 {
	return getXYForGridPos(p.x, p.y);
}

public function getXYForGridPos( x :int, y:int) : Vector2 {
		var newX : int = (x - Constants.xTiles/2) * Constants.tileDim;
		var newY : float = (y - Constants.yTiles/2.0) * Constants.tileDim;
	//		Debug.Log(Vector2( newX, newY));
	return Vector2( newX, newY);
}


// Assumes nonNull
public function isGridLeft(v : Vector2) : boolean {
	return v.x <= (Constants.xTiles/2) - 1;
}

// Assumes nonNull
public function isGridRight(v :Vector2): boolean{
	return !isGridLeft(v);
}

