using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public GameObject spawnPoint;
	
	private PlayerController player;
	
	// Use this for initialization
	void Start () {
		//Get PlayerController Object that already exists in the scene
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RespawnPlayer(){
		//Turn player off
		TogglePlayer(false);
		//Reset the players position to their last checkpoint position
		player.transform.position = spawnPoint.transform.position;
		Debug.Log ("Player Respawn");
		//Turn player back on
		TogglePlayer(true);
	}
	
	public void TogglePlayer(bool isEnabled){
		//Get Renderer object from the player
		Renderer renderer = player.GetComponent<Renderer>();
		//Get RigidBody2D object from player
		Rigidbody2D rigidBody2D = player.GetComponent<Rigidbody2D>();
		//Stop all player movement
		rigidBody2D.velocity = Vector2.zero;
		//Enable/Disable player being controlled
		player.enabled = isEnabled;
		//Enable/Disable player form being visible
		renderer.enabled = isEnabled;
	}
}

