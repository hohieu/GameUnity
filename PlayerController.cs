using UnityEngine;
using System.Collections;
using CnControls;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody2D _myBody;

	[SerializeField]private GameObject _bullet;

	[SerializeField]private AudioClip _weaponClip;

	[SerializeField]private GameObject _explosionPlayer;

	[SerializeField]private AudioClip _explosionPlayerClip;
	// Use this for initialization
	void Awake () {
		_myBody = GetComponent<Rigidbody2D> ();
	}

	void Start(){
		StartCoroutine (Shoot ());
	}

	// Update is called once per frame
	void FixedUpdate () {
		float h = CnInputManager.GetAxis ("Horizontal") * speed;
		float v = CnInputManager.GetAxis ("Vertical") * speed;
		_myBody.velocity = new Vector2 (h,v);
	}

	IEnumerator Shoot(){
		yield return new WaitForSeconds (0.2f);

		Vector3 temp = transform.position;
		temp.y += 0.5f;
		Instantiate (_bullet, temp, Quaternion.identity);

		AudioSource.PlayClipAtPoint (_weaponClip, temp);

		StartCoroutine (Shoot ());
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Enemy" || target.tag == "Rock" || target.tag == "RedBullet") {
			Destroy (gameObject);
			Destroy (target.gameObject);
			_explosionPlayer = (GameObject)Instantiate (_explosionPlayer, target.transform.position, Quaternion.identity);
			Destroy (_explosionPlayer,1);

			if (GamePlayController.instance != null) {
				GamePlayController.instance._PlayerDied ();
			}

			AudioSource.PlayClipAtPoint (_explosionPlayerClip, transform.position);
		}
	}
}
