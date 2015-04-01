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
	public GameObject unitNamePrefab;

	public bool showName = true;
	
	float barOffset = 0f;
	float textOffset = -6f;

	GameObject canvas;
	GameObject toFollow;
	SpriteRenderer rend;

	// Health bar
	GameObject healthBar;
	Image healthBarFillImg;

	// Name
	GameObject nameTextObj;
	Text nameText;

	bool hasHealth = false;

	// Use this for initialization
	void Start () {
		unit = GetComponent<Unit>();
		health = GetComponent<UnitHealth>(); 

		hasHealth = health != null;

		if (hasHealth || showName){
			canvas = GameObject.FindWithTag("IngameCanvas");
			toFollow = unit.GetEntity().gameObject;
			rend = toFollow.GetComponent<SpriteRenderer>();
		}

		if (hasHealth)
			CreateHealthUI();

		if (showName)
			CreateNameUI();
		
	}


	// Update is called once per frame
	// The health bar will  need to track the thing in worldspace as well
	void Update () {
		if (hasHealth)
			UpdateHealthUI();

		if (showName)
			UpdateNameUI();
	}


	void CreateNameUI(){
		nameTextObj = Util.InitWithParent(unitNamePrefab, canvas);
		nameText = nameTextObj.GetComponent<Text>();
		nameText.text = unit.uniqName;

		UpdateNameUI();
	}

	void UpdateNameUI(){
		nameTextObj.transform.position = HUDPos(textOffset);
	}

	void CreateHealthUI(){
		if (healthBarPrefab == null)
			return;
		

		healthBar = Util.InitWithParent(healthBarPrefab, canvas);
		
		// This is ridiculous
		healthBarFillImg = healthBar.transform.GetChild(0).gameObject.GetComponent<Image>();
		healthBarFillImg.fillAmount = HealthPercentage();
		
		UpdateHealthUI();
	}


	Vector3 HUDPos(float offset = 0){
		float offsetY = rend.bounds.size.y + barOffset + offset;
		Vector3 newPos =  toFollow.transform.position;
		newPos.y += offsetY;

		return newPos;
	}

	void UpdateHealthUI(){
		if (healthBarPrefab == null)
			return;
		if (toFollow == null)
			return;


		healthBar.transform.position = HUDPos(barOffset);
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
		Destroy(nameTextObj);
	}
}
