using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	private float _speed;

	private Rigidbody2D _myBody;

	// Use this for initialization
	void Awake () {
		_myBody = GetComponent<Rigidbody2D> ();
	}

	void Start(){
		_speed = Random.Range (-4,-1);
		_myBody.angularVelocity = Random.Range (0, 200);
	}

	// Update is called once per frame
	void FixedUpdate () {
		_myBody.velocity = new Vector2 (_myBody.velocity.x, _speed);
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Bounds") {
			Destroy (gameObject);
		}
	}
}
