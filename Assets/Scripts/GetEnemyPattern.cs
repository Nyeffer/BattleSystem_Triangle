using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemyPattern : MonoBehaviour {

	public BattleManager bm;
	public GameObject[] patterns;
	public int patternNum;
	public GameObject scene;
	void Start() {
		patterns[0].SetActive(false);
		patterns[1].SetActive(false);
		patterns[2].SetActive(false);
	}

	void Update() {
		
		switch(scene.GetComponent<States>().GetCurrentState()) {
			case "precombat":
				Reset();
				if(bm.GetEnemyPat()[patternNum] > 0) {
					switch(bm.GetEnemyPat()[patternNum]) {
						case 1:
							if(bm.GetEnemy().GetComponent<Enemy>().GetFamiliarity() >= 1) {
								patterns[0].SetActive(true);
							} else {
								patterns[3].SetActive(true);
							}
						break;
						case 2:
							if(bm.GetEnemy().GetComponent<Enemy>().GetFamiliarity() >= 2) {
								patterns[1].SetActive(true);
							} else {
								patterns[3].SetActive(true);
							}
						break;
						case 3:
							if(bm.GetEnemy().GetComponent<Enemy>().GetFamiliarity() >= 3) {
								patterns[2].SetActive(true);
							} else {
								patterns[3].SetActive(true);
							}
						break;
						default:
						break;
					}
				}
			break;
			case "combat":
				
			break;
			case "postcombat":
			break;
			default:
			break;
		}
	}

	public void Reset() {
		for(int i = 0; i < patterns.Length - 1; i++) {
			patterns[i].SetActive(false);
		}
	}
}
