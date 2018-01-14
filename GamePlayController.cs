using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[HideInInspector]public int playerScore = 0;

	[SerializeField]private Animator _gameOverPanel;

	[SerializeField]private Text _scoreText, _endScoreText;

	void Awake(){
		_MakeInstance ();
	}

	void Start(){
		_scoreText.text = "" + playerScore;
	}

	void Update(){
		_UpdateGamePlayController ();
	}

	void _UpdateGamePlayController(){
		_scoreText.text = "" + playerScore;
	}

	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void _PlayerDied(){
		_gameOverPanel.Play ("SlideIn");
		_endScoreText.text = "" + playerScore;
		_scoreText.gameObject.SetActive (false);
	}

	public void _RestartButton(){
		Application.LoadLevel ("GamePlay");
	}
}
