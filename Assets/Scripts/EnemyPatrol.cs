using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {
	
	public float moveSpeed;
	public bool moveRight;
	
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	
	private bool notAtEdge;
	public Transform edgeCheck;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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

		if (moveRight) {
			if(x > 0){
				x = -x;
			}
			transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);
			rigidBody2D.velocity = new Vector2 (moveSpeed, rigidBody2D.velocity.y);
		} else {
			if(x < 0){
				x = -x;
			}
			transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);
			transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
			rigidBody2D.velocity = new Vector2 (-moveSpeed, rigidBody2D.velocity.y);
		}
	}
}
