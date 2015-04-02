using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Player teleport!
/// 
/// teleport the player! wow!
/// 
/// 
/// 
/// 
/// 
/// 
/// </summary>
public class PlayerTeleport : MonoBehaviour {

	public GameObject teleportLocations; // set in inspector
	public GameObject tpLocationPrefab; // set in inspector

	PlayerUnit player;
	PlayerEnergy energy;
	Entity playerEntity;
	List<TPLocation> locations;

	public float gridDim = 50f;

	public float teleportCost = 3f;


	bool useGrid = false;

	void Awake(){
		player = GetComponent<PlayerUnit>();
		energy = GetComponent<PlayerEnergy>();
		// Setup the grid and what is capable
	}

	// Use this for initialization
	void Start () {
		playerEntity = player.GetEntity();

		if (useGrid)
			SetupTPLocations();
	}
	
	// Update is called once per frame
	void Update () {
		if (useGrid)
			TryGridTeleport();
	}


//	void MouseLeftDownMessage(Vector3 pos){
//		Debugger.Log ("Teleport", "TeleportLeftDown: " + pos);
//		TeleportToPosition(pos);
//	}
	
	void MouseRightDownMessage(Vector3 pos){
		Debugger.Log ("Teleport", "TeleportRightDown: " + pos);
		TryTeleport(pos);
	}
	
	void TryTeleport(Vector3 pos){
		if (energy.HasEnergy(teleportCost)){
			TeleportToPosition(pos);
			energy.UseEnergy(teleportCost);
		}

	}

	void TeleportToPosition(Vector3 newPos){

		newPos.z = 0;
		Vector3 oldPos = playerEntity.transform.position;
		playerEntity.transform.position = newPos;

		player.SendMessage("TeleportDoneMessage", oldPos);

	}




	void TryGridTeleport(){
		char? _c = InputMapper.instance.GetInputChar();
		if (!_c.HasValue)
			return;
		
		TPLocation tpl = LocationFromInput(_c.Value);
		playerEntity.transform.position = tpl.transform.position;
		
	}

	void SetupTPLocations(){
		locations = new List<TPLocation>();
		playerEntity = player.GetEntity();
		
		for(int i = 0; i < Grid.dim * Grid.dim; i++){
			GameObject instance = Util.InitWithParent(tpLocationPrefab, teleportLocations);
			TPLocation tpl = instance.GetComponent<TPLocation>();
			locations.Add(tpl);
			
			tpl.Setup(InputMapper.instance.chars[i], this, i);
		}
	}


	/// <summary>
	/// TPLocations from input.
	/// 
	/// relies on stored indexes
	/// </summary>
	/// <returns>The from input.</returns>
	/// <param name="c">C.</param>
	TPLocation LocationFromInput(char c){
		return locations[ InputMapper.instance.GetIndexForChar(c)];
	}



}
