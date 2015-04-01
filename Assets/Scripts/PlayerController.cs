using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float playerVelocity;
	public Text score;
	public AudioClip pointSound;
	public AudioClip lifeSound;
	private Vector3 playerPosition;
	private float boundary;
	private int playerLives;
	private int playerPoints;
	// Use this for initialization
	void Start () {
		playerPosition = gameObject.transform.position;
		boundary = 4.5f;
		playerLives = 3;
		playerPoints = 0;
		updateUI ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerPosition.x <= boundary && playerPosition.x >= -boundary)
			playerPosition.x += Input.GetAxis ("Horizontal") * playerVelocity;

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		transform.position = playerPosition;
		if (playerPosition.x > boundary)
						playerPosition.x = boundary;
				else if (playerPosition.x < -boundary)
						playerPosition.x = -boundary;

		WinLose ();
	}

	//To add points everytime a block is destroyed. This will be called by BlockHit.cs script.
	void addPoints(int points){
		playerPoints += points;
		audio.PlayOneShot (pointSound);
		updateUI ();
	}

	void takeLives(){
		playerLives--;
		audio.PlayOneShot (lifeSound);
		updateUI ();
	}

	void updateUI(){
		score.text = "Score: " + playerPoints + "    Lives: " + playerLives;
	}

	void WinLose(){
		if (playerLives == 0)
			Application.LoadLevel ("Level1");
		if (GameObject.FindGameObjectsWithTag ("Block").Length == 0) {
			if (Application.loadedLevelName == "Level2")
				Application.LoadLevel ("Level1");
			else
				Application.Quit ();
		}
	}
}
