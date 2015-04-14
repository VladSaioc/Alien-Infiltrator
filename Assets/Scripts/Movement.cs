using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Animator anim;
	public string axisName = "";
	public BoltBehavior boltBehav;
	public GameObject vent1;
	public GameObject vent2;

	public float speed = 20f;
	public int facing = 1;

	private float x;
	public bool hidden;
	private float tamp;
	private bool maxSpeed;

	// Use this for initialization
	void Start () 
	{
		hidden = false;
		anim.SetBool ("stopMovement", false);
		maxSpeed = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v;
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis(axisName)));
		if (Input.GetKeyDown ("0"))
			Application.Quit ();

		if (Input.GetAxis (axisName) < 0 && !anim.GetBool("tampered") 
		    && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")
		    && GameObject.Find ("Pause").renderer.enabled == false) {
			if(Mathf.Abs (Input.GetAxis (axisName)) == 1) maxSpeed = true;
			v = transform.localScale;
			Debug.Log (hidden);
			if(Input.GetAxis (axisName) > -0.4f && maxSpeed == true)
				anim.SetBool ("stopMovement", true);
			if(Input.GetAxis (axisName) > -0.2f && maxSpeed == true)
				anim.SetBool ("stopMovement", false);
			if (facing == 1) {
				v.x = v.x * (-1);
				facing = 0;
			}
			transform.localScale = v;
		} else if (Input.GetAxis (axisName) > 0 && !anim.GetBool("tampered")
		           && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
			if(Mathf.Abs (Input.GetAxis (axisName)) == 1) maxSpeed = true;
			Debug.Log (hidden);
			v = transform.localScale;
			if(Input.GetAxis (axisName) < 0.4f && maxSpeed == true)
				anim.SetBool ("stopMovement", true);
			if(Input.GetAxis (axisName) < 0.2f && maxSpeed == true)
				anim.SetBool ("stopMovement", false);
			if (facing == 0) {
				v.x = v.x * (-1);
				facing = 1;
			}

			transform.localScale = v;
		} else {
			v = transform.localScale;
			anim.SetBool("stopMovement", false);
			maxSpeed = false;
			if (facing == 0 && v.x > 0) v.x = v.x * (-1);
			if (facing == 1 && v.x < 0) v.x = v.x * (-1);
			transform.localScale = v;
		}

		if (anim.GetBool ("stopMovement") == true && anim.GetFloat ("speed") > 0.05) {
			anim.SetBool("stopMovement", false);
		}

		if (anim.GetBool ("stopMovement") == false && Mathf.Abs(Input.GetAxis(axisName)) > 0.4f)
			x = Input.GetAxis (axisName);
		else
			x = 0;
		if(!hidden) transform.position += transform.right * x * speed * Time.deltaTime;

		if (Input.GetMouseButtonDown (0) 
		    && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !boltBehav.fired 
		    && !hidden) {
			anim.SetBool ("tampered", true);
			tamp = 0;
		}
		
		if (anim.GetBool("tampered") == true && tamp > 0.2f) {
			anim.SetBool ("tampered", false);
			tamp = 0;
		}
		
		if (anim.GetBool ("tampered") == true) {
			tamp += Time.deltaTime;
		}
	}
}
