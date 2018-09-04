using UnityEngine;
using System.Collections;

public class controladorchapeu : MonoBehaviour {

	public Camera cam;
	private Rigidbody2D rb;
	private float maxWidth;
	private bool cancontrol;

	// Use this for initialization
	void Start () {
		cancontrol = false;
		if(cam == null){
			cam = Camera.main;
			rb = GetComponent <Rigidbody2D> ();
			Vector3 UpperC = new Vector3 (Screen.width, Screen.height, 0.0f);
			Vector3 targetWidth = cam.ScreenToWorldPoint (UpperC);
			float largurachapeu = GetComponent<Renderer> ().bounds.extents.x;
			maxWidth = targetWidth.x - largurachapeu;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		Vector3 rawpos = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector2 targetPosition = new Vector3 (rawpos.x, 0.0f);
		float targetW = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		targetPosition = new Vector2 (targetW, 0.0f);
		if (cancontrol)rb.MovePosition (targetPosition);
	}

	public void MudaControl(bool control){
		cancontrol = control;
	}

}
