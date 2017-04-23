using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour {

	public Material material1;
	public Material material2;

	float timePeriodToChange = 0.1F;
	float timeSinceLastChange = 0;
	bool currentIsOne = true;
	Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > timeSinceLastChange + timePeriodToChange){
			if (currentIsOne) {
				rend.material = material1;
			} else {
				rend.material = material2;
			}
			currentIsOne = !currentIsOne;
			timeSinceLastChange = Time.time;
		}

	}
}
