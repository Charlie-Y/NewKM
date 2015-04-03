using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum AIStrategy { none, advancing, waiting, attacking, spawning}

/// <summary>
/// AI brain to be attached to a Unit
/// </summary>
public abstract class AIBrain : MonoBehaviour {

	// for debugging
	public string debugStatus; 

	protected Unit unit;
	
	// how often to think...
	protected CooldownField thinkCooldown;

	protected virtual float thinkTime { get{return .5f;} set{} }


	// Things i think all of AI brains will want
	public AIStrategy currentStrat = AIStrategy.none;
	public Unit targetUnit;
	private float someSpeed = 70f;

	// Inspector!
	public bool brainOn = true;

//	public float targetRangeMod = 0.7f; 

	public virtual void Awake(){
		unit = GetComponent<Unit>();
		unit.brain = this;



		thinkCooldown = new CooldownField(thinkTime, true);
		thinkCooldown.Clean();
	}

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		if (!brainOn)
			return;
//		if (Input.GetKeyDown(KeyCode.Space) && targetUnit != null)
//			weapon.FireAtEntity(targetUnit.GetEntity(), false);

		if (thinkCooldown.Check()){
			thinkCooldown.Fire();

			DetermineStrategy();
		}
	
		ExecuteStrategy();

	}

	// These should probably be the abstract ovverrides
	/*
	switch(currentStrat){
		case AIStrategy.none: 
		case AIStrategy.waiting :
		}
	 */
	protected abstract void DetermineStrategy();

	protected abstract void ExecuteStrategy();

	/// <summary>
	/// Checks the target unit.
	/// </summary>
	/// <returns><c>true</c>, if target unit is there, <c>false</c> otherwise.</returns>
	protected bool CheckTargetUnit(){
		return targetUnit != null;
	}

	// Returns true if the entites are greater than dist apart
	protected bool EntityDistApart(float dist, Entity e1, Entity e2){
		Vector2 dv = (e1.transform.position - e2.transform.position);
		return dv.magnitude > dist;
	}

	protected Unit FindNearestEnemy(){
		List<Unit> units;
		Unit tempUnit = default(Unit);

		if (unit.isEnemy){
			units = FightManager.instance.alliedUnits;
		} else {
			units = FightManager.instance.enemyUnits;
		}

//		return Util.RandomFromList<Unit>(units);

		float minDist = float.MaxValue;
		Vector3 thisPos = unit.GetEntity().transform.position;

		foreach(Unit u in units){
//			if (u == null)
//				continue;

			float thisDist = (u.GetEntity().transform.position - thisPos).magnitude;
			if ( thisDist < minDist){
				minDist = thisDist;
				tempUnit = u;
			}
		}

		return tempUnit;
	}

	protected void MoveEntityTowardsEntity(Entity e1, Entity e2){
		e1.transform.position = Vector2.MoveTowards(e1.transform.position, e2.transform.position, someSpeed * Time.deltaTime);
		//		e1.unit.transform.position = Vector2.MoveTowards(e1.unit.transform.position, e2.unit.transform.position, someSpeed * Time.deltaTime);
	}

	protected void MoveEntityAwayFromEntity(Entity e1, Entity e2){
//		Vector2 pos = -(e2.transform.position - e1.transform.position);

		e1.transform.position = Vector2.MoveTowards(e1.transform.position, e2.transform.position, someSpeed * Time.deltaTime);
//		e1.unit.transform.position = Vector2.MoveTowards(e1.unit.transform.position, e2.unit.transform.position, someSpeed * Time.deltaTime);
	}




















}
