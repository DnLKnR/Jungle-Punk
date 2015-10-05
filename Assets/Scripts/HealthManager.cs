using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxHealth;

	public static int health;

	public Slider healthBar;

	public bool isDead;

	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		healthBar = GetComponent<Slider>();

		health = maxHealth;

		levelManager = FindObjectOfType<LevelManager>();

		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0 && !isDead) {
			levelManager.RespawnPlayer();
			isDead = true;
		}
		healthBar.value = health;
	}
	public static void Hurt(int damage){
		health -= damage;
	}
	public void Reset(){
		health = maxHealth;
	}
}
