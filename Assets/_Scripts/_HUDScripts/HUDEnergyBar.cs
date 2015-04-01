using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// HUD energy bar. Yay!
/// </summary>
public class HUDEnergyBar : MonoBehaviour {

	PlayerUnit player;

	// Set all in inspector. Should be from prefab of course
	public Text currentEnergyText;
	public Text maxEnergyText;
	public Image energyFillImg;



	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null){
//			Debugger.Log("HUD", "faul");
			player = GameObject.FindWithTag("Player").GetComponent<PlayerUnit>();
			return;

		}

		currentEnergyText.text = player.currentEnergy.ToString();
		maxEnergyText.text = player.maxEnergy.ToString();


//		Debugger.Log("HUD", player.GetEnergyPercentage());
		energyFillImg.fillAmount = player.GetEnergyPercentage();

	}
}
