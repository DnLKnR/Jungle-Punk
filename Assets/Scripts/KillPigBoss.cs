using UnityEngine;
using System.Collections;

public class KillPigBoss : MonoBehaviour {

	EnemyPatrol enemyPatrol;
	// Use this for initialization
	void Start () {
		enemyPatrol = GetComponentInParent<EnemyPatrol> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			enemyPatrol.defeated = true;
			enemyPatrol.rigidBody2D.isKinematic = false;
			enemyPatrol.rigidBody2D.velocity = new Vector2 (enemyPatrol.moveSpeed * 5, enemyPatrol.rigidBody2D.velocity.y);
			Debug.Log("You won the game!!!");
		}
	}
}
