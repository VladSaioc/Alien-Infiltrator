using UnityEngine;
using System.Collections;

public class ComputerScript : MonoBehaviour {

	public GameObject bolt;
	public bool deactive;
	public float timeDeactive;
	public Animator anim;

	// Use this for initialization
	void Start () {
		deactive = false;
		timeDeactive = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bolt.transform.position.x <= gameObject.transform.position.x + 1
			&& bolt.transform.position.x >= gameObject.transform.position.x - 1
			&& bolt.transform.position.y <= gameObject.transform.position.y + 1.88
			&& bolt.transform.position.y >= gameObject.transform.position.y - 1.88) {
			deactive = true;
			anim.SetBool("deactive", deactive);
		}
		if (deactive == true) {
			timeDeactive += Time.deltaTime;
			if(timeDeactive > 2)
			{
				timeDeactive = 0;
				deactive = false;
				anim.SetBool("deactive", deactive);
			}
		}
	}
}
