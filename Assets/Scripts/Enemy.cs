using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Public Variables
	public int maxHp;
	public int[] firstPattern;
	public int[] secondPattern;
	public int atk;
	public int def;
	public int level;
	public int familiarity = 0;
	


	// Private Variables
	private int currentHp;
	private int[] desiredAtk;
	private int atkVal;
	private int defVal;

	void Start() {
		currentHp = (int)(maxHp * ((level * 0.25) + 1));
		atkVal = atk * level;
		defVal = def * level;
	}

	public int[] PickAttackPatterns() {
		int rand = Random.Range(0, 2);
		desiredAtk = new int[3];
		switch(rand) {
			case 0:
				desiredAtk[0] = firstPattern[0];
				desiredAtk[1] = firstPattern[1];
				desiredAtk[2] = firstPattern[2];
			break;
			case 1:
				desiredAtk[0] = secondPattern[0];
				desiredAtk[1] = secondPattern[1];
				desiredAtk[2] = secondPattern[2];
			break;
			default:
			break;
		}
		return desiredAtk;
	}

	public int TakeDamage(int dam) {
		int trueDam = dam - defVal;
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

	public void SetFamiliarity(int newVal) {
		familiarity = newVal;
	}

	public int GetFamiliarity() {
		return familiarity;
	}


}
