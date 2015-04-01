using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private Vector2 initialForce;
	private bool ballIsActive;
	private Vector2 ballPosition;
	public GameObject paddle;
	public AudioClip hitSound;
	// Use this for initialization
	void Start () {
		initialForce = new Vector2 (100.0f, 300.0f);
		ballIsActive = false;
		ballPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") == true) {
						if (ballIsActive == false) {
								rigidbody2D.isKinematic = false;
								rigidbody2D.AddForce (initialForce);
								ballIsActive = !ballIsActive;
						}
				}
		if (ballIsActive == false && paddle != null) {
						ballPosition.x = paddle.transform.position.x;
						transform.position = ballPosition;
				}

		if (ballIsActive && transform.position.y < -6) {
						ballPosition.x = paddle.transform.position.x;
						ballIsActive = false;
						transform.position = ballPosition;
						rigidbody2D.isKinematic = true;
						
						//Find player object
						GameObject player = GameObject.FindGameObjectsWithTag ("Player") [0];
						player.SendMessage ("takeLives");
				}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (ballIsActive) {
						audio.PlayOneShot (hitSound);
				}
	}
}
