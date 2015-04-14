using UnityEngine;
using System.Collections;

public class HumanBehavior : MonoBehaviour {

	private GameObject infilt;
	public GameObject guard1;
	public GameObject guard2;
	public GameObject guard3;
	public GameObject distraction;
	private bool distracted;
	public float distractionTime;
	private float facingUndistracted;
	public float hearingX;
	public float sightX;
	public float sightY;
	private bool dead;
	public float facing = 1;
	public float patrolDist;
	public float linger;
	private float walkDist = 0;
	private float waitTime = 0;
	public float speed;
	public GameObject bolt;
	public Animator anim;

	// Use this for initialization
	void Start () {
		infilt = GameObject.Find ("Infiltrator");
		distracted = false;
		distractionTime = 0;
		dead = false;
		if (facing == -1) {
			Vector2 v = transform.localScale;
			v.x *= (-1);
			transform.localScale = v;
		}
		if(!GameObject.Find("Computer")) distraction = null;
	}
	void Turn()
	{
		Vector2 v = transform.localScale;
		v.x *= (-1);
		transform.localScale = v;
		facing = facing * (-1);
	}

	void GuardDetection(GameObject guard)
	{
		//Detection of dead allies
		if(facing == 1) {
			if(transform.position.x + sightX * facing > guard.transform.position.x
			   && transform.position.x < guard.transform.position.x
			   && transform.position.y + sightY > guard.transform.position.y
			   && transform.position.y - sightY < guard.transform.position.y
			   && guard.GetComponent<HumanBehavior>().dead == true)
				Application.LoadLevel(Application.loadedLevel);}
		else if(facing == -1)
		{
			if(transform.position.x + sightX * facing < guard.transform.position.x
			   && transform.position.x > guard.transform.position.x
			   && transform.position.y + sightY > guard.transform.position.y
			   && transform.position.y - sightY < guard.transform.position.y
			   && guard.GetComponent<HumanBehavior>().dead == true)
				Application.LoadLevel(Application.loadedLevel);
		}
	}

	// Update is called once per frame
	void Update () {
		if (bolt.transform.position.x <= gameObject.transform.position.x + 1
			&& bolt.transform.position.x >= gameObject.transform.position.x - 1
			&& bolt.transform.position.y <= gameObject.transform.position.y + 1.88
			&& bolt.transform.position.y >= gameObject.transform.position.y - 1.88)
			dead = true;
		if (dead == true)
			anim.SetBool ("dead", dead);
		if (!dead) 
		{
			//Distraction
			if(distraction != null)
			{
			if(distraction.GetComponent<ComputerScript>().deactive == true && distracted == false)
			{
			   if(facing == 1)
					{
					if ((transform.position.x - hearingX < distraction.transform.position.x
					     && transform.position.x + hearingX > distraction.transform.position.x)
					    || (transform.position.x + sightX > distraction.transform.position.x
					    && transform.position.x < distraction.transform.position.x))
				{
							facingUndistracted = facing;
							distracted = true;
					if(transform.position.x > distraction.transform.position.x)
					{
						Turn ();
					}
				}
					}
				else
					{
					if ((transform.position.x - hearingX < distraction.transform.position.x
					     && transform.position.x + hearingX > distraction.transform.position.x)
					    || (transform.position.x + sightX > distraction.transform.position.x
					    && transform.position.x < distraction.transform.position.x))
				{
							facingUndistracted = facing;
							distracted = true;
					if(transform.position.x < distraction.transform.position.x)
					{
						Turn ();
					}
				}
				}
			}
			if(distracted == true)
			{
				distractionTime += Time.deltaTime;
				if(distractionTime > 4)
				{
					distracted = false;
					distractionTime = 0;
					if(facingUndistracted != facing)
					{
						Turn ();
					}
				}
			}
			}
			//Walking
			if (Mathf.Abs (walkDist) <= patrolDist && !distracted) 
			{
				float xOffset = transform.position.x;
				transform.position += transform.right * speed * Time.deltaTime * facing;
				walkDist += Mathf.Abs (Mathf.Abs(transform.position.x) - Mathf.Abs(xOffset));
			} 
			else 
			{
				if(!distracted)
				{
					if(waitTime <= linger)
					{
						waitTime += Time.deltaTime;
					}
					else
					{
						walkDist = 0;
						waitTime = 0;
						Turn();
					}
				}
			}
			//Detection of character
			if(facing == 1) {
			if(transform.position.x + sightX * facing > infilt.transform.position.x
			   && transform.position.x < infilt.transform.position.x
			   && transform.position.y + sightY > infilt.transform.position.y
			   && transform.position.y - sightY < infilt.transform.position.y
			   && !infilt.GetComponent<Movement>().hidden)
					Application.LoadLevel(Application.loadedLevel);}
			else if(facing == -1)
			{
				if(transform.position.x + sightX * facing < infilt.transform.position.x
				   && transform.position.x > infilt.transform.position.x
				   && transform.position.y + sightY > infilt.transform.position.y
				   && transform.position.y - sightY < infilt.transform.position.y
				   && !infilt.GetComponent<Movement>().hidden)
					Application.LoadLevel(Application.loadedLevel);
			}

			//Detection of allies
			if(guard1 != null) GuardDetection(guard1);
			if(guard2 != null) GuardDetection(guard2);
			if(guard3 != null) GuardDetection(guard3);
		}
	}
}
