using UnityEngine;
using System.Collections;


/// <summary>
/// Shield held by a player. Perhaps defenders will be able to use them as well...
/// 
/// 
/// 
///  Assumes player for now
/// 
/// </summary>
public class Shield : MonoBehaviour {

	// Set in inspector/prefab
	// should have a ShieldEntity Script attached
	public GameObject shieldEntityPrefab;
	[HideInInspector]
	public PlayerUnit unit;
	public PlayerEnergy energy;

	// This is the shield obj which you turn on and off
	GameObject entity;
	ShieldEntity shieldEntity;
	public bool shieldOn = false; // stupid overhead for now

	int _activateCost = 5;
	public int activateCost { get{return _activateCost;} set{}  }

	float _costPerSecond = 20;
	public float costPerSecond { get{return _costPerSecond;} set{} }
	[HideInInspector]
	public float stayOnInterval = .1f;


	public float shieldHitCost = 3f;

	CooldownField costPerSecondCD;


	// Use this for initialization
	public virtual void Start () {
		unit = GetComponent<PlayerUnit>();
		energy = GetComponent<PlayerEnergy>();

		entity = Util.InitWithParent(shieldEntityPrefab, gameObject);

		shieldEntity = entity.GetComponent<ShieldEntity>();
		shieldEntity.Setup(this);

		costPerSecondCD = new CooldownField(stayOnInterval, false);

		ShieldOff();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (shieldOn && costPerSecondCD.Check()){
			shieldEntity.RefreshPosition();
			ShieldStayOn();
		}
		// holding down mouse keys is annoying
		if (Input.GetKeyDown(KeyCode.Space)){
			TryShieldOn();
		} 

		if (Input.GetKeyUp(KeyCode.Space)){
			ShieldOff();
		} 
	}

	void TryShieldOn(){
		if (shieldOn)
			return;

		if (energy.HasEnergy(activateCost)){
			shieldEntity.RefreshPosition();
			ShieldOn();
		}
	}

	public virtual void ShieldOn(){
		shieldOn = true;
		entity.SetActive(shieldOn);

		energy.UseEnergy(activateCost);

		// Playerunit can catch this i guess. ai brain too
		gameObject.SendMessage("ShieldOnMessage", this, SendMessageOptions.DontRequireReceiver);

	}

	public virtual void ShieldOff(){
		shieldOn = false;
		entity.SetActive(shieldOn);

		// Playerunit can catch this i guess. ai brain too
		gameObject.SendMessage("ShieldOffMessage", this, SendMessageOptions.DontRequireReceiver);
	}

	public virtual void ShieldStayOn(){

		if (CheckShieldEnergy(costPerSecond * stayOnInterval)){
			energy.UseEnergy(costPerSecond * stayOnInterval);
			gameObject.SendMessage("ShieldStayOnMessage", this, SendMessageOptions.DontRequireReceiver);
		}
	}

	/// <summary>
	/// Checks the shield energy.
	/// </summary>
	bool CheckShieldEnergy(float cost){
		if (!energy.HasEnergy( cost)){
			ShieldOff();
			return false;
		}
		return true;
	}


	/// <summary>
	/// Sent by shield entity
	/// 
	/// 
	/// just subtracct for now
	/// </summary>
	public virtual void ShieldHitMessage(Weapon w){


	}

	
	void OnDeath(){
		Destroy(entity);
	}

}
