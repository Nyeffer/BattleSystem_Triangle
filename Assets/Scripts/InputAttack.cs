using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAttack : MonoBehaviour {

	public GameObject player;

	public int DesiredAtkType;

	public void DesignatedAtkCommand() {
		player.GetComponent<Player>().Use_Pattern(DesiredAtkType);
	}
}
