using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {

	public Text scoreText;
	private static int Score; //static make unique
	public int ballValue;

	// Use this for initialization
	void Start () {
		Score = 0;
		UpdateScore();
	}

	void OnTriggerEnter2D (Collider2D outro){
		if (outro.gameObject.CompareTag("Ball")) Score += ballValue;
		UpdateScore ();
	}

	void OnCollisionEnter2D(Collision2D outro){
		if (outro.gameObject.CompareTag("Bomba")) Score -= ballValue * 2;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void UpdateScore () {
		scoreText.text = "Score: \n" + Score;
	}
}
