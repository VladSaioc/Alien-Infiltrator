using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	private bool pauseGame;

	// Use this for initialization
	void Start () {
		pauseGame = false;
		transform.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			pauseGame = !pauseGame;
			if (pauseGame == true) {
				Time.timeScale = 0;
				if(GameObject.Find("Infiltrator"))
					if(GameObject.Find("Infiltrator").GetComponent<Movement>().facing == -1)
				{
					Vector3 v = transform.localScale;
					v.x = v.x * (-1);
					transform.localScale = v;
				}
				GameObject.Find ("Pause").transform.renderer.enabled = true;
			} else
			if (pauseGame == false) {
				Time.timeScale = 1;
				GameObject.Find ("Pause").transform.renderer.enabled = false;
			}

		}
	}
}
