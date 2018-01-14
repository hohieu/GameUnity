using UnityEngine;
using System.Collections;

public class YellowBullet : MonoBehaviour {

	public float speed;

	private Rigidbody2D _myBody;

	[SerializeField]private GameObject _explosionEnemy, _explosionRock;

	[SerializeField]private AudioClip _explosionEnemyClip, _explosionRockClip;
	// Use this for initialization
	void Awake () {
		_myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_myBody.velocity = new Vector2 (_myBody.velocity.x, speed);
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Bounds") {
			Destroy (gameObject);
		}

		if (target.tag == "Enemy") {
			Destroy (gameObject);
			Destroy (target.gameObject);
			_explosionEnemy = (GameObject)Instantiate (_explosionEnemy, target.transform.position, Quaternion.identity);
			Destroy (_explosionEnemy,1);
			GamePlayController.instance.playerScore++;
			AudioSource.PlayClipAtPoint (_explosionEnemyClip, target.transform.position);
		}

		if (target.tag == "Rock") {
			Destroy (gameObject);
			Destroy (target.gameObject);
			_explosionRock = (GameObject)Instantiate (_explosionRock, target.transform.position, Quaternion.identity);
			Destroy (_explosionRock,1);
			GamePlayController.instance.playerScore++;
			AudioSource.PlayClipAtPoint (_explosionRockClip, target.transform.position);

		}
	}
}
