using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// HUD energy bar. Yay!
/// </summary>
public class HUDEnergyBar : MonoBehaviour {

//	PlayerUnit player;
	PlayerEnergy energy;

	// Set all in inspector. Should be from prefab of course
	public Text currentEnergyText;
	public Text maxEnergyText;
	public Image energyFillImg;



	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if (energy == null){
//			Debugger.Log("HUD", "faul");
			energy = GameObject.FindWithTag("Player").GetComponent<PlayerEnergy>();
			return;

		}

		currentEnergyText.text = energy.currentEnergy.ToString("F2");
		maxEnergyText.text = energy.maxEnergy.ToString();


//		Debugger.Log("HUD", player.GetEnergyPercentage());
		energyFillImg.fillAmount = energy.GetEnergyPercentage();

	}
}
