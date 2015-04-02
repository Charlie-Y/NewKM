using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/// <summary>
/// Input mapper.
/// 
/// 
/// takes a 7-0, m-/ grid.
/// 
/// Just a 4x4;
/// 
/// </summary>
public class InputMapper : MonoBehaviour {

	Hashtable keyHash;
	public static InputMapper instance;
	int cols = 4;

	// Dumde deumm.
	public char[] chars;

	void Awake(){

		//Check if instance already exists
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    

		chars = new char[] {
			'7','8','9','0',
			'u','i','o','p',
			'j','k','l',';',
			'm',',','.','/'
		};

		keyHash = new Hashtable();
		keyHash.Add('7', new Vector2(0,0));
		keyHash.Add('8', new Vector2(1,0));
		keyHash.Add('9', new Vector2(2,0));
		keyHash.Add('0', new Vector2(3,0));

		keyHash.Add('u', new Vector2(0,1));
		keyHash.Add('i', new Vector2(1,1));
		keyHash.Add('o', new Vector2(2,1));
		keyHash.Add('p', new Vector2(3,1));

		keyHash.Add('j', new Vector2(0,2));
		keyHash.Add('k', new Vector2(1,2));
		keyHash.Add('l', new Vector2(2,2));
		keyHash.Add(';', new Vector2(3,2));

		keyHash.Add('m', new Vector2(0,3));
		keyHash.Add(',', new Vector2(1,3));
		keyHash.Add('.', new Vector2(2,3));
		keyHash.Add('/', new Vector2(3,3));


	}


	void Update(){
//		if (isGridInput()){
//			Debugger.Log("Input", "isGridInput");
//			Debugger.Log ("Input", GetGridInput());
//		}
	}

	/// <summary>
	/// uh, return true if any key that is not WASD or all the other keys are pressed.
	/// 
	/// </summary>
	/// <returns><c>true</c>, if grid input was ised, <c>false</c> otherwise.</returns>
	public bool isGridInput(){
		if (string.IsNullOrEmpty(Input.inputString)) 
			return false;

		foreach(char c in Input.inputString.ToCharArray()){
			if (CharInGrid(c)){
				return true;
			}
		}

		return false;
	}

	/// <summary>
	/// Returns a grid input, vector 2. null on failure
	/// 
	/// 'n' = (3,0) '0' = (3,0) '/' = (3,3)
	/// 
	/// umm this is not normal.
	/// 
	/// TODO: have this interpolate
	/// 
	/// </summary>
	/// <returns>The input.</returns>
	public Vector2? GetGridInput(){

		string input = Input.inputString;
		Vector2? result = null;
		
		if (string.IsNullOrEmpty(input)) 
			return result;


		char[] inputChars;
		foreach(char c in input.ToCharArray()){
			if (CharInGrid(c)){
//				Debugger.Log("Input", c + " pressed");
				return (Vector2?) keyHash[c];
			}
		}


		return result;
	}

	public char? GetInputChar() {
		string input = Input.inputString;
		foreach(char c in input.ToCharArray() ) {
			if (CharInGrid(c)){
				return c;
			}
		}

		return null;
	}

	bool CharInGrid(char c){
		bool result = keyHash.Contains(c);
//		if (result){
//			Debugger.Log ("Input", c + " in grid");
//		} else {
//			Debugger.Log ("Input", c + " not in grid");
//		}
		return result;
	}


	/// <summary>
	/// Or i could search the entire darn array. too bad
	/// </summary>
	/// <returns>The char for grid position.</returns>
	/// <param name="pos">Position.</param>
	public char GetCharForGridPos(Vector2 pos){
		int index = (int)pos.x + (cols * (int)pos.y);
		return chars[index];
	}

	public Vector2? GetGridPosForChar(char c){
		return (Vector2?) keyHash[c];
	}

	/// <summary>
	/// Gets the index for char.
	/// </summary>
	/// <returns>The index for char.</returns>
	/// <param name="c">C.</param>
	public int GetIndexForChar(char c){
		Vector2? _pos = GetGridPosForChar(c);
		if (!_pos.HasValue)
			return -1;

		Vector2 pos = _pos.Value;
		int index = (int)pos.x + (cols * (int)pos.y);
		return index;
	}

}
