using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDHealthBar : MonoBehaviour {

	UnitHealth health;
	
	// Set all in inspector. Should be from prefab of course
	public Text currentHealthText;
	public Text maxHealthText;
	public Image healthFillImg;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health == null){
//			Debugger.Log("HUD", "faul");
			health = GameObject.FindWithTag("Player").GetComponent<UnitHealth>();
			return;
			
		}
		
		currentHealthText.text = health.currentHealth.ToString();
		maxHealthText.text = health.maxHealth.ToString();
		
		
//		Debugger.Log("HUD", player.GetHealthPercentage());
		healthFillImg.fillAmount = health.GetHealthPercentage();
		
	}
}
