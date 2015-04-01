using UnityEngine;
using System.Collections;

public class BlockHit : MonoBehaviour {
	public int hitsToKill;
	public int points;
	private int numberOfHits;
	// Use this for initialization
	void Start () {
		numberOfHits = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Ball"){
			numberOfHits++;
			if(numberOfHits == hitsToKill){
				//First, points will be added for destroying this block. Then this block will be destroyed.

				//To find player (in this case object with "Player" tag)
				GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

				//To send a message to player. i.e. Call function to add points.
				player.SendMessage("addPoints", points);		//"addPoints" is function name and 'points' is argument.

				//Destroy the object
				Destroy(this.gameObject);
			}
		}
	}
}
