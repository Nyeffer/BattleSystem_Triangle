using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

	// Static instance of BattleManager which allows it to be accessed by any other script
	public static BattleManager instance = null;

	// Public Variables
	public GameObject player;
	public GameObject preCombatHUD;
	public GameObject combatHUD;
	public GameObject postCombatHUD;
	public States State;
	public GameObject[] Enemies;
	public string[] states;

	// Private Variables 
	private GameObject desiredEnemy;
	private int[] playerPattern;
	//private char[] playerPat;
	private int[] enemyAtkPattern;
	private int[] enemyPattern;
	//private Character[] enemyPat;
	private int playerHp;
	private int playerAtk;
	private int enemyHp;
	private int enemyAtk;

	// Check if instance already exist
	void Awake() {
		if(instance == null) {
			// if not, set instance to this
			instance = this;
		// if instance already exists and it's not this	
		} else if (instance != this) {
			// then Destroy this. this enforce our singleton pattern.
			Destroy(gameObject);
		}
	}

	void Start() {
		State.ChangeState("precombat");
		playerPattern = new int[3];
		enemyAtkPattern = new int[3];
		enemyPattern = new int[3];
		PickEnemy();
		State.ChangeState(states[0]);
		playerAtk = player.GetComponent<Player>().GetAtk();
		enemyAtk = desiredEnemy.GetComponent<Enemy>().GetAtk();
	}

	void Update() {
		if(player.GetComponent<Player>().GetCounter() < 2) {
			// This is Pre-Combat
			switch(State.GetCurrentState()) {
				case "precombat":
					preCombatHUD.SetActive(true);
					combatHUD.SetActive(false);
					postCombatHUD.SetActive(false);
					// Check Enemy Attack Pattern
					enemyAtkPattern = desiredEnemy.GetComponent<Enemy>().PickAttackPatterns();
					SetEnemyPattern(enemyAtkPattern, 3);
					//enemyPat = ArrayUtils.toObject(enemyPattern);
					// Check Player Attack Pattern
					// playerAtkPattern[0] = player.GetComponent<Player>().GetDesiredAtk()[0];
					// playerAtkPattern[1] = player.GetComponent<Player>().GetDesiredAtk()[1];
					// playerAtkPattern[2] = player.GetComponent<Player>().GetDesiredAtk()[2];
					//playerPat = ArrayUtils.toObject(playerPattern);
				break;
				case "combat":
					SetPlayerPattern(player.GetComponent<Player>().GetDesiredAtk(), 3);
					preCombatHUD.SetActive(false);
					combatHUD.SetActive(true);
					postCombatHUD.SetActive(false);
					for (int i = 0; i <= 2; i++) {
						switch(i) {
							case 0:
								if(playerPattern[0] == 1 && enemyPattern[0] == 2) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[0] == 2 && enemyPattern[0] == 1) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[0] == 2 && enemyPattern[0] == 3) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[0] == 3 && enemyPattern[0] == 2) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[0] == 3 && enemyPattern[0] == 1) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[0] == 1 && enemyPattern[0] == 3) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[0] == enemyPattern[0]){
									Debug.Log("Attack was Neutralized");
								}
							break;
							case 1:
								if(playerPattern[1] == 1 && enemyPattern[1] == 2) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[1] == 2 && enemyPattern[1] == 1) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[1] == 2 && enemyPattern[1] == 3) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[1] == 3 && enemyPattern[1] == 2) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[1] == 3 && enemyPattern[1] == 1) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[1] == 1 && enemyPattern[1] == 3) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[1] == enemyPattern[1]){
									Debug.Log("Attack was Neutralized");
								}
							break;
							case 2:
								if(playerPattern[2] == 1 && enemyPattern[2] == 2) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[2] == 2 && enemyPattern[2] == 1) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[2] == 2 && enemyPattern[2] == 3) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[2] == 3 && enemyPattern[2] == 2) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[2] == 3 && enemyPattern[2] == 1) {
									Debug.Log("Enemy receive " + desiredEnemy.GetComponent<Enemy>().TakeDamage(playerAtk) + " ");
								} else if(playerPattern[2] == 1 && enemyPattern[2] == 3) {
									Debug.Log("Player receive " + player.GetComponent<Player>().TakeDamage(enemyAtk) + " ");
								} else if(playerPattern[2] == enemyPattern[2]){
									Debug.Log("Attack was Neutralized");
								}
							break;
							default:
							break;
						}
					}
					if(player.GetComponent<Player>().GetHp() <= 0) {
						// Go To Lose Scene
					} else if(desiredEnemy.GetComponent<Enemy>().GetHp() <= 0) {
						State.ChangeState("postcombat");
					} else {
						State.ChangeState("precombat");
					}
				break;
				case "postcombat":
					// Show the gain of Exp
					// Level Mechanic in here
					// For now 
					State.ChangeState("precombat");
				break;
				default:
				break;
			}
		} else {
			player.GetComponent<Player>().ResetCounter();
		}
	}

	void PickEnemy() {
		int rand = Random.Range(0, Enemies.Length);
		switch(rand) {
			case 0:
				Enemies[0].SetActive(true);
				desiredEnemy = Enemies[0];
			break;
			case 1:
				Enemies[1].SetActive(true);
				desiredEnemy = Enemies[1];
			break;
			case 2:
				Enemies[2].SetActive(true);
				desiredEnemy = Enemies[2];
			break;
			case 3:
				Enemies[3].SetActive(true);
				desiredEnemy = Enemies[3];
			break;
			default:
			break;
		}
	}

	public void SetPlayerPattern(int[] pattern, int num) {
		playerPattern = new int[pattern.Length];
		for(int i = 0; i < pattern.Length; i++) {
			playerPattern[i] = pattern[i];
		}
	}

	public void SetEnemyPattern(int[] pattern, int num) {
		enemyPattern = new int[pattern.Length];
		for(int i = 0; i < num; i++) {
			enemyPattern[i] = pattern[i];
		}
	}		
}
