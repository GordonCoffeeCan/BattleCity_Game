using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//values
	public int lifeValue = 3;
	public int playerScore = 0;
	public bool isDead = false;
	public bool isDefeated = false;

	//reference
	public Born born;
	public Text playerScoreText;
	public Text playerLifeText;
	public Image gameOverImg;

	//Singleton pattern
	private static GameManager instance;

    public static GameManager Instance {
        get {
            return instance;
        }

        set {
            instance = value;
        }
    }

	private void Awake() {
		instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDefeated) {
			gameOverImg.gameObject.SetActive(true);
			Invoke("ReturnToTitle", 3f);
			return;
        }
		if(isDead == true) {
			Recover();
        }
		playerScoreText.text = playerScore.ToString();
		playerLifeText.text = lifeValue.ToString();
	}

	private void Recover() {
		if(lifeValue <= 0) {
			//Game over
			isDefeated = true;
        } else {
			lifeValue--;
			Born _bornClone = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
			_bornClone.createPlayer = true;
			isDead = false;
        }
    }

	private void ReturnToTitle() {
		SceneManager.LoadScene(0);
    }
}
