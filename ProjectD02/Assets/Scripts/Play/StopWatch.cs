using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour {

    public UILabel ul;
    public float sec;

	void Start () {
		
	}
	
	void Update () {
        sec += Time.deltaTime;
        ul.text = sec.ToString("#,##0.# sec");
	}
}
