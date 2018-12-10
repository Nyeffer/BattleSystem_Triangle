using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour {

	// Private Variables
	private string currentState;
	// Allows you change state from an Instance
	public void ChangeState(string stateToBe) {
		currentState = stateToBe;
	}
	// Allows you to check the value of the currentState from an Instance
	public string GetCurrentState() {
		return currentState;
	}

}
