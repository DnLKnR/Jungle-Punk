using UnityEngine;
using System.Collections;

public class FallingGround : MonoBehaviour {

	private Rigidbody2D ground;
	//Number of seconds before ground starts falling
	public float delay;

	// Use this for initialization
	void Start () {
		ground = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Player") {
			StartCoroutine("Fall");
		}
	}
	/* Destroy the object when it leaves the map */
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Border"){
			Destroy(gameObject);
		}
	}
	/* Allow ground to fall after the delay */
	IEnumerator Fall(){
		yield return new WaitForSeconds(delay);
		ground.isKinematic = false;
	}
}
