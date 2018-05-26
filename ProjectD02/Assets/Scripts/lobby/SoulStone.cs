using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulStone : MonoBehaviour {

    public GameObject jewelPN;
    public GameObject[] jewelChang;
    public bool btnIn = false;
	void Start ()
    {
        jewelPN = GameObject.Find("JewelPanel");
        gameObject.transform.parent = jewelPN.transform;
        for (int i = 0; i < jewelChang.Length; i++)
        {
            jewelChang[i] = GameObject.Find("Stone" + i);
            if (jewelChang[i].GetComponent<JewelBtn>().stoneIn == false)
            {
                if (btnIn == false)
                {
                    btnIn = true;
                    jewelChang[i].GetComponent<JewelBtn>().stoneIn = true;
                    jewelChang[i].GetComponent<JewelBtn>().soulItem = gameObject;
                    gameObject.transform.position = jewelChang[i].transform.position;
                }
            }
        }
	}
	
	void Update ()
    {
		
	}
}
