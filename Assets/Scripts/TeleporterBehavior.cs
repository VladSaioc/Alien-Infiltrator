using UnityEngine;
using System.Collections;

public class TeleporterBehavior : MonoBehaviour {

	public GameObject destination;
	private GameObject infilt;

	// Use this for initialization
	void Start () {
		infilt = GameObject.Find ("Infiltrator");
	}
	
	// Update is called once per frame
	void Update () {
		if(infilt.transform.position.x < transform.position.x + 2 &&
		   infilt.transform.position.x > transform.position.x - 2 &&
		   infilt.transform.position.y > transform.position.y &&
		   infilt.transform.position.y < transform.position.y + 6 &&
		   Input.GetKeyDown ("w"))
		{
			Vector3 v = destination.transform.position;
			v.y += 2;
			infilt.transform.position = v;
		}
	
	}
}
