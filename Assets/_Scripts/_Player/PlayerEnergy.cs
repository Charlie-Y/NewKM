using UnityEngine;
using System.Collections;

public class PlayerEnergy : MonoBehaviour {

	PlayerUnit player;

	public bool infiniteEnergy = false;

//	[HideInInspector]
	public int maxEnergy = 100;
	//	[HideInInspector]
	public float currentEnergy = 50f;
	//	[HideInInspector]
	public float energyRegen = 5f; // per second
	float energyRegenInterval = .1f; // regen cooldown
	
	CooldownField energyRegenCD;

	void Awake(){
		player = GetComponent<PlayerUnit>();
		player.energy = this;
	}

	// Use this for initialization
	void Start () {
		energyRegenCD = new CooldownField(energyRegenInterval, false);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (energyRegenCD.Check()){
			RegenEnergy();
		}
	}

	public void UseEnergy(float amount){
		if (infiniteEnergy){
			return;
		}

		currentEnergy -= amount;
	}
	
	public bool HasEnergy(float energy){
		if (infiniteEnergy){
			return true;
		}
		return currentEnergy >= energy;
	}

	public float GetEnergyPercentage(){
		return (float)currentEnergy/ (float) maxEnergy;
	}
	
	protected virtual void RegenEnergy(){
		if (currentEnergy >= maxEnergy){
			currentEnergy = maxEnergy;
			return;
		}
		currentEnergy += energyRegen * energyRegenInterval;
		
		//		Debugger.Log ("HUD", currentEnergy);
		//		Debugger.Log ("HUD", energyRegen );
		//		Debugger.Log ("HUD", energyRegenInterval);
		//		Debugger.Log ("HUD", 1f * .2f);
	}
	

}
