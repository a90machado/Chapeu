using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour {

	public Camera cam;
	public GameObject[] balls;
	private Rigidbody2D rb;
	private float maxWidth;
	public float timeLeft;
	public Text timerText;
	public GameObject GameOver;
	public GameObject restartBTT;
	private bool playing;
	public GameObject SplashScreen;
	public GameObject StartButton;
	public controladorchapeu ControlC;

	// Use this for initialization
	void Start () {
		playing = false;
		GameOver.SetActive (false);
		restartBTT.SetActive (false);

		timeLeft = 60;	
		if(cam == null){
			cam = Camera.main;
			rb = GetComponent <Rigidbody2D> ();
			Vector3 UpperC = new Vector3 (Screen.width, Screen.height, 0.0f);
			Vector3 targetWidth = cam.ScreenToWorldPoint (UpperC);
			float largulabola = balls[0].GetComponent<Renderer> ().bounds.extents.x;
			maxWidth = targetWidth.x - largulabola;

		}
	}

	public void StartGame(){
		SplashScreen.SetActive (false);
		StartButton.SetActive (false);
		playing = true;
		ControlC.MudaControl (true);
		StartCoroutine (Spawn ());
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (playing) {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
			timeLeft = 0;
		timerText.text = "Tempo:\n" + Mathf.RoundToInt(timeLeft);
		}
	}


	IEnumerator Spawn(){
		while (timeLeft > 0) {
			Vector3 startPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.position.y,0.0f);
			Quaternion spawRotation = Quaternion.identity;

			GameObject ball = balls [Random.Range (0, balls.Length)]; 
			Instantiate (ball, startPosition, spawRotation);
			yield return new WaitForSeconds (3.0f);
		}
		yield return new WaitForSeconds (2.0f);
		ControlC.MudaControl (false);
		GameOver.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		restartBTT.SetActive (true);
	}

}
