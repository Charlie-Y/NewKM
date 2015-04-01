using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Heads up display for each unit. shows health and shows its name
/// 
/// name is just for debugging purposes
/// </summary>
public class UnitHUD : MonoBehaviour {

	Unit unit;
	UnitHealth health;

	// Set in inspector, for now..
	public GameObject healthBarPrefab;
	public GameObject textPrefab;


	public bool showName = true;
	
	float barOffset = -.05f;

	GameObject toFollow;
	SpriteRenderer rend;
	GameObject healthBar;
	Image healthBarFillImg;

	bool hasHealth = false;

	// Use this for initialization
	void Start () {
		unit = GetComponent<Unit>();
		health = GetComponent<UnitHealth>(); 

		hasHealth = health != null;

		if (hasHealth)
			CreateHealthUI();
		
	}
	
	// Update is called once per frame
	// The health bar will  need to track the thing in worldspace as well
	void Update () {
		if (hasHealth)
			UpdateHealthUI();
	}



	void CreateHealthUI(){
		if (healthBarPrefab == null)
			return;
		
		GameObject canvas = GameObject.FindWithTag("IngameCanvas");
		healthBar = Util.InitWithParent(healthBarPrefab, canvas);
		
		// This is ridiculous
		healthBarFillImg = healthBar.transform.GetChild(0).gameObject.GetComponent<Image>();
		healthBarFillImg.fillAmount = HealthPercentage();
		
		toFollow = unit.GetEntity().gameObject;
		rend = toFollow.GetComponent<SpriteRenderer>();
	}
	
	void UpdateHealthUI(){
		if (healthBarPrefab == null)
			return;
		if (toFollow == null)
			return;

		float offsetY = rend.bounds.size.y + barOffset;
		Vector3 newPos =  toFollow.transform.position;
		newPos.y += offsetY;
		healthBar.transform.position = newPos;
	}
	
	float HealthPercentage(){
		//		return .1f;
		float result = (float)health.currentHealth /  (float)health.maxHealth ;
		//		Debugger.Log ("Health", result);
		return result;
	}

	// Received from UnitHealth
	void OnDamageFromWeapon(Weapon w){
		healthBarFillImg.fillAmount = HealthPercentage();
	}

	// Received from UnitHealth
	void OnDeath(Weapon w){
		Destroy(healthBar);
	}
}
