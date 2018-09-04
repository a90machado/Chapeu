using UnityEngine;
using System.Collections;

public class reiniciar : MonoBehaviour {

	public void RestartGame(){

		Application.LoadLevel (Application.loadedLevel);
	}
}
