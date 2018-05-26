using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

	void Start () {
        StartCoroutine(Round());
	}
	
	void Update () {
		
	}

    IEnumerator Round()
    {
        yield return new WaitForSeconds(2.0f);
        UILabel ul = gameObject.GetComponent<UILabel>();
        ul.enabled = false;
    }
}
