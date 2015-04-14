using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour {
	private GameObject infiltrator;
	public float x;
	public float yMin;
	public float yMax;
	public string nextLev;

	// Use this for initialization
	void Start () {
		infiltrator = GameObject.Find ("Infiltrator");
	}
	
	// Update is called once per frame
	void Update () {
		if (infiltrator.transform.position.x > x
			&& infiltrator.transform.position.y > yMin
			&& infiltrator.transform.position.y < yMax) {
			Application.LoadLevel (nextLev);
		}
	}
}
