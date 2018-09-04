using UnityEngine;
using System.Collections;

public class detroyoncontact : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D outro) {
		Destroy (outro.gameObject);
	}
}
