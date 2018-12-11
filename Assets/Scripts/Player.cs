using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Public Variables
	public States states;
	public int maxHp; // Maximum possible health
	public int atk;
	public int def;
	public float atkGrowth;
	public float defGrowth;
	public float hpGrowth;

	public float atkTime = 3.0f;
	// Private Variables
	private int currentHp; // Updated number of Health
	private int[] attackPattern; // Array of integer [ 1, 2, 3]
	private int[] desiredAtk; // Collect the Pattern

	private int atkVal;
	private int defVal;

	private int level;
	private int counter = -1;
	private bool isReady = false;
	private bool isAttacking = false;
	private float atkCounter = 0.0f;

	void Start() {
		atkVal = (int)(atk * ((atk * atkGrowth) + 1));
		maxHp = (int)(maxHp * ((maxHp * hpGrowth) + 1));
		defVal = (int)(def * ((def * defGrowth) + 1));
		currentHp = maxHp;
		attackPattern = new int[3];
		desiredAtk = new int[3];
	}
	void Update() {
		Debug.Log(isReady);
		Debug.Log(atkCounter);
		if(isAttacking) {
			if(atkCounter <= atkTime) {
				atkCounter += Time.deltaTime;
			} else {
				isReady = false;
				isAttacking = false;
				atkCounter = 0.0f;
			}
		}
		// Check if the Attack Input is enough
		if(!isReady) {
			states.ChangeState("precombat");
		}

	}

	public void Use_Pattern(int atkType) {
		counter += 1;
		attackPattern[counter] = atkType;
		if(counter >= 2) {
			isReady = true;
		}
	}

	public void CombatReady() {
		if(isReady == true) {
			// Change the State to Combat
			states.ChangeState("combat");
			// attackPattern = new int[3];
			counter = -1;
			isAttacking = true;
		}
	}

	public int[] GetDesiredAtk() {
		desiredAtk = new int[3];
		// Collect the Pattern before reset
		desiredAtk[0] = attackPattern[0];
		desiredAtk[1] = attackPattern[1];
		desiredAtk[2] = attackPattern[2];
		return desiredAtk;
	}
	public int TakeDamage(int dam) {
		int trueDam = defVal - dam;
		if(trueDam > 0) {
			currentHp -= trueDam;
		} else {
			currentHp -= 0;
		}
		return trueDam;
	}

	public int GetHp() {
		return currentHp;
	}

	public int GetAtk() {
		return atkVal;
	}

	public int GetDef() {
		return defVal;
	}

	public int GetCounter() {
		return counter;
	}

	public void ResetCounter() {
		counter = 0;
	}

	IEnumerator delay(float num) {	
		yield return new WaitForSeconds(num);
		desiredAtk = new int[3];
	}
 
}
