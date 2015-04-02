using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Teleport location.
/// 
/// 
/// wheee...
/// </summary>
public class TPLocation : MonoBehaviour {

	char gridChar;

	GameObject TPLocationLabelPrefab;
	PlayerTeleport pt;
	public int index = -1;
	public Vector2 pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Setup(char c, PlayerTeleport playerTeleport, int ind){
		gridChar = c;
		pt = playerTeleport;
		index = ind;


		Vector2? gridPos = InputMapper.instance.GetGridPosForChar(c);
		pos = gridPos.Value;

		Vector2 actualPos = gridPos.Value;

		actualPos.y = Grid.dim - actualPos.y;

		actualPos.y -= 2.5f;
		actualPos.x -= 1.5f;

		actualPos *= pt.gridDim;

		transform.localPosition = actualPos;

	}



}
