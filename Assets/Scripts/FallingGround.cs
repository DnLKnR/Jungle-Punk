using UnityEngine;
using System.Collections;

public class FallingGround : MonoBehaviour {

	private Rigidbody2D ground;
	//Number of seconds before ground starts falling
	public float delay;

	private Vector3 initialPosition;
	private Quaternion initialRotation;
	// Use this for initialization
	void Start () {
		ground = GetComponent<Rigidbody2D>();
		initialPosition = gameObject.transform.position;
		initialRotation = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Player") {
			StartCoroutine("Fall");
		}
	}
	/* Reset the item after it leaves the map */
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Border"){
			ground.isKinematic = true;
			//Reset platform position
			gameObject.transform.position = initialPosition;
			gameObject.transform.rotation = initialRotation;
		}
	}
	/* Allow ground to fall after the delay */
	IEnumerator Fall(){
		yield return new WaitForSeconds(delay);
		ground.isKinematic = false;
	}
}
