using UnityEngine;
using System.Collections;

public class SpanwerEnemy : MonoBehaviour {

	[SerializeField]private GameObject[] _enemies; 

	private BoxCollider2D _box;

	// Use this for initialization
	void Awake () {
		_box = GetComponent<BoxCollider2D> ();
	}

	void Start(){
		StartCoroutine (Spanwer ());
	}

	IEnumerator Spanwer(){
		yield return new WaitForSeconds (Random.Range(1, 3));

		float minX = -_box.bounds.size.x/2;
		float maxX = _box.bounds.size.x/2;

		Vector3 temp = transform.position;

		temp.x = Random.Range (minX, maxX);

		int enemiesRandomIndex = Random.Range (0, _enemies.Length);

		Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

		StartCoroutine (Spanwer ());
	}
}
