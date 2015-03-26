#pragma downcast

public static class InputMap{
	
/*

Behavior: 

Account for multiple keys pressed at once
Translate from a keypress into a x,y position on a keyboard
Be able to change which keys map to which position






*/

	// 
	
	var defaultMap : Hashtable = { 
		"1"	: 0 + 24, 
		"2"	: 1 + 24, 
		"3"	: 2 + 24,
		"4"	: 3 + 24,
		"7" : 4 + 24,
		"8" : 5 + 24,
		"9" : 6 + 24,
		"0" : 7 + 24,
		
		"q"	: 0 + 16, 
		"w"	: 1 + 16, 
		"e"	: 2 + 16,
		"r"	: 3 + 16,
		"u" : 4 + 16,
		"i" : 5 + 16,
		"o" : 6 + 16,
		"p" : 7 + 16,
		
		"a"	: 0 + 8, 
		"s"	: 1 + 8, 
		"d"	: 2 + 8,
		"f"	: 3 + 8,
		"j" : 4 + 8,
		"k" : 5 + 8,
		"l" : 6 + 8,
		";" : 7 + 8,
		
		"z"	: 0 + 0, 
		"x"	: 1 + 0, 
		"c"	: 2 + 0,
		"v"	: 3 + 0,
		"m" : 4 + 0,
		"," : 5 + 0,
		"." : 6 + 0,
		"/" : 7 + 0
	};

	var anyGridButtonDown : boolean = false;

	function Start () {

	}

	function Update () {
//		if (Input.anyKey) {
//			Debug.Log(Input.inputString);
//			if (Input.inputString.Length > 0) {
//				Debug.Log(Input.inputString[0]	);
//				Debug.Log(Input.inputString[0].ToString());
//				Debug.Log( getXYforInput( Input.inputString[0]));
//				Debug.Log( getXYforInput( Input.inputString));
//			}	
//		}
	
	}
	
	function heldDownKeys() : String{
		return "asdf";	
	}

	function isAnyGridButtonDown () : boolean {
		if (Input.anyKey) {	
			if (Input.inputString.Length > 0) {
				return !Util.isNullPos( getXYforInput( Input.inputString) );
			}
		}
		return false;
	}
	
	// Should return an array of all grid positions pressed in that frame	
	function getGridButton() : Vector2{
	}
	
	// Should return an array of all grid positions pressed down for the first frame
	function getGridButtonDown() : Vector2 {
		if (Input.anyKey) {	
			if (Input.inputString.Length > 0) {
				return getXYforInput( Input.inputString);
			}
		}
		return Util.NullPos;
	}
	
	// Returns an array of all grid positions released for the first frame
	function getGridButtonUp() : Vector2{
	}
	
	
	private function valToVec2(val : int) : Vector2{
		var x :int = val % 8;
		var y :int = val / 8;
		return Vector2(x, y);
	}
	
	
	// c needs to a string of length 1
	private function getXYforInput (c : String) : Vector2 {
	
		if (defaultMap.Contains( c )){
			return valToVec2( defaultMap[ c ] );
		} else {
			return Util.NullPos;
		}
	}
	
}