using UnityEngine;
using System.Collections;


/// <summary>
/// Player OHHH MAN
/// 
/// 
/// what does this deal with? everything! yaya!
/// </summary>
public class PlayerUnit : Unit {


	public static PlayerUnit instance;

	override public bool isPlayer { get {return true;} set {} }
	override public bool isEnemy { get {return false;} set {} } //lol
	override public string unitName { get {return "PlayerUnit";} set {} }

	// should be set by shield
	public Shield shield;
	public PlayerEnergy energy;

	protected override void Awake (){
		base.Awake ();
		shield = GetComponent<Shield>();
		energy = GetComponent<PlayerEnergy>();

		if (PlayerUnit.instance == null)
			PlayerUnit.instance = this;
		else if (PlayerUnit.instance != this)
			Destroy(gameObject); 
	}

	public override void Start ()
	{
		// Don't add to fight manager
//		base.Start ();
	}

	protected override void CalculateHit (Weapon w){
		// useful because some projectiles move too fast
		if (shield.shieldOn){
			ShieldHit(w);
		} else {
			base.CalculateHit(w);
		}

	}


	public static PlayerUnit GetPlayer(){
		return instance;
	}
	
	//Sent by weapon entity
	void ShieldHit(Weapon w){
		Debugger.Log("Shield", "ShieldHit");
		shield.SendMessage("ShieldHitMessage", w, SendMessageOptions.DontRequireReceiver);
	}

	public override void NoHealth(Weapon w){
//		Debugger.Log ("Weapon", uniqName + " has died" );
		RemoveFromFightManager();
		gameObject.SetActive(false);
	}

	// Sent by shield
	// Shield has already been turned on, 
	void ShieldOnMessage(Shield s){
//		energy.UseEnergy(s.activateCost);
	}

	void ShieldStayOnMessage(Shield s){
//		energy.UseEnergy(s.costPerSecond * s.stayOnInterval);
	}


	// Sent by shield
	void ShieldOffMessage(Shield s){
		//blah!
	}

	// Sent by MouseCatcher
	void MouseLeftDownMessage(Vector3 pos){
//		Debugger.Log ("Teleport", "PlayerLeftDown: " + pos);
	}
	
	void MouseRightDownMessage(Vector3 pos){
//		Debugger.Log ("Teleport", "PlayerRightDown: " + pos);
	}
	
	// Sent by PlayerTeleport
	void TeleportDoneMessage(Vector3 oldPos){

	}

}





