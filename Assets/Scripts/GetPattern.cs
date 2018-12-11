using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPattern : MonoBehaviour {

	public GameObject player;
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
				
			break;
			case "combat":
				Reset();
			break;
			case "postcombat":
			break;
			default:
			break;
		}
		if(player.GetComponent<Player>().GetDesiredAtk()[patternNum] > 0) {
			switch(player.GetComponent<Player>().GetDesiredAtk()[patternNum]) {
				case 1:
					patterns[0].SetActive(true);
				break;
				case 2:
					patterns[1].SetActive(true);
				break;
				case 3:
					patterns[2].SetActive(true);
				break;
				default:
				break;
			}
		}
	}

	public void Reset() {
		Debug.Log("hit");
		for(int i = 0; i < patterns.Length; i++) {
			patterns[i].SetActive(false);
		}
	}
}
