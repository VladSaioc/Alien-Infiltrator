using UnityEngine;
using System.Collections;

public class BoltBehavior : MonoBehaviour {
	public float flicker;
	public bool fired;
	public float cooldown;

	// Use this for initialization
	void Start () {
		flicker = 0f;
		cooldown = 0f;
		gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > 2f && fired == true) {
			cooldown = 0f;
			fired = false;
		}
		else
			if(fired == true) cooldown += Time.deltaTime;
		if(Input.GetMouseButton(0) && fired == false 
		   && GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle")
		   && GetComponentInParent<Movement>().hidden == false) {
				Vector2 flick = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
				cooldown = 0.1f;
				fired = true;
				gameObject.transform.position = Camera.main.ScreenToWorldPoint (flick);
				gameObject.renderer.enabled = true;
			}
		if (flicker > 0.2f) {
			Vector2 displace = new Vector2(100, 100);
			gameObject.transform.position = displace;
			gameObject.renderer.enabled = false;
			flicker = 0;
		}
		if (gameObject.renderer.enabled == true) {
			flicker += Time.deltaTime;
		}
	}
}
