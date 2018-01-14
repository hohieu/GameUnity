using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float _speed;

	private Rigidbody2D _myBody;

	[SerializeField]private GameObject _bullet;

	[SerializeField]private AudioClip _weaponEnemyClip;

	// Use this for initialization
	void Awake () {
		_myBody = GetComponent<Rigidbody2D> ();
	}

	void Start(){
		_speed = Random.Range (-4,-1);
		StartCoroutine (Shoot ());
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

	IEnumerator Shoot(){
		yield return new WaitForSeconds (Random.Range (1, 3));

		Vector3 temp = transform.position;
		temp.y -= 0.5f;
		Instantiate (_bullet, temp, Quaternion.identity);

		AudioSource.PlayClipAtPoint (_weaponEnemyClip, temp);

		StartCoroutine (Shoot ());
	}
}
