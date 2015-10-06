using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public Rigidbody2D rigidBody2D;

	public float moveSpeed;
	public float backSpeed;
	public bool moveRight;
	
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	
	private bool notAtEdge;
	public Transform edgeCheck;

	public bool defeated;
	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();

		defeated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (defeated) {
			return;
		}

		//Check if the enemy has hit a wall
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
		//Check if the enemy has near an edge
		notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
		//if the enemy is hitting the wall or near an edge, reverse direction
		if (hittingWall || !notAtEdge) {
			moveRight = !moveRight;
		}
		
		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
		float x = transform.localScale.x;
		ParticleSystem particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
		if (moveRight) {
			if(particleSystem != null){
				particleSystem.enableEmission = false;
			}
			if(x > 0){
				x = -x;
			}
			transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);
			rigidBody2D.velocity = new Vector2 (backSpeed, rigidBody2D.velocity.y);
		} else {
			if(particleSystem != null){
				particleSystem.enableEmission = true;
			}
			if(x < 0){
				x = -x;
			}
			transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);
			transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
			rigidBody2D.velocity = new Vector2 (-moveSpeed, rigidBody2D.velocity.y);
		}
	}
}
