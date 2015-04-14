using UnityEngine;
using System.Collections;

public class VentBehav : MonoBehaviour {

	private GameObject infilt;
	public Animator anim;
	private bool occupied;

	// Use this for initialization
	void Start () {
		infilt = GameObject.FindGameObjectWithTag ("Player");
		occupied = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x - 1 < infilt.transform.position.x
			&& transform.position.x + 1 > infilt.transform.position.x
			&& transform.position.y + 3 > infilt.transform.position.y
			&& transform.position.y - 3 < infilt.transform.position.y
			&& Input.GetKeyDown ("w")) {
			infilt.GetComponent<Transform>().renderer.enabled = false;
			infilt.GetComponent<Movement>().hidden = true;
			anim.SetBool("occupy", true);
			occupied = true;
		}

		if (occupied && Input.GetKeyDown ("s")) {
			infilt.GetComponent<Transform>().renderer.enabled = true;
			infilt.GetComponent<Movement>().hidden = false;
			anim.SetBool("occupy", false);
			occupied = false;
		}
	}
}
