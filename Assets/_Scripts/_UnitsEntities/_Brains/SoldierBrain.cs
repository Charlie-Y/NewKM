using UnityEngine;
using System.Collections;

public class SoldierBrain : AIBrain {

	public Weapon weapon;
	

	public override void Awake(){
		base.Awake();

		weapon = GetComponent<Weapon>();
		if (weapon == null){
			Debug.LogError("Weapon needed on " + unit.unitName);
		} else {
			
		}
	}
	
	// These should probably be the abstract ovverrides
	protected override void DetermineStrategy(){
		Debugger.Log ("Brain", "DetermineStrategy...");
		switch(currentStrat){
		case AIStrategy.none: case AIStrategy.waiting :
			// find the nearest unit of the other group
			if (targetUnit == null){

				Unit nearestEnemy = FindNearestEnemy();
				targetUnit = nearestEnemy;

			} 
			
			if (targetUnit != null){
				Entity e1 = unit.GetEntity();
				Entity e2 = targetUnit.GetEntity();
				
				if (EntityDistApart( weapon.range * weapon.rangeMod, e1, e2)){
					currentStrat = AIStrategy.advancing;
				} else {
					currentStrat = AIStrategy.attacking;
				}

			}
			
			
			
			
			break;
		}
	}
	
	protected override void ExecuteStrategy(){
		if (!CheckTargetUnit())
			currentStrat = AIStrategy.none;
		
		switch(currentStrat){
		case AIStrategy.advancing:
			Entity e1 = unit.GetEntity();
			Entity e2 = targetUnit.GetEntity();
			
			
			//			if (unit.isEnemy){
			//				Debugger.Log("Brain", unit.unitName + " targeting " + targetUnit.unitName);
			MoveEntityTowardsEntity(e1, e2);
			//			} else {
			//				MoveEntityAwayFromEntity(e1, e2);
			//			}
			
			if (!EntityDistApart(weapon.range * weapon.rangeMod, e1, e2)){
				currentStrat = AIStrategy.attacking;
				//				currentStrat = AIStrategy.waiting;
			}
			
			break;
		case AIStrategy.attacking: 
			
			weapon.FireAtEntity(targetUnit.GetEntity(), true);
			break;
		}
	}
	

}
