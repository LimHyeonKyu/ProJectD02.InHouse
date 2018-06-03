using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class SoulStone : MonoBehaviour {

    public GameObject jewelPN;
    public GameObject[] jewelChang;
    public bool[] btnIn;
    public int costValue;
    public int soulSkillNumber;
    public int firstValue;
    public Vector3 parentPos;
    public Vector3[] pos;
    void Awake()
    {
        jewelPN = GameObject.Find("JewelPanel");
        gameObject.transform.parent = jewelPN.transform;
    }
	void Start ()
    {
        //LoadedStonePositon();
        if(firstValue==0)
        {
            for (int i = 0; i < jewelChang.Length; i++)
            {
                jewelChang[i] = GameObject.Find("Stone" + i);
                if (jewelChang[i].GetComponent<JewelBtn>().stoneIn == false)
                {
                    if (btnIn[0] == false)
                    {
                        btnIn[0] = true;
                        btnIn[1] = false;
                        jewelChang[i].GetComponent<JewelBtn>().stoneIn = true;
                        jewelChang[i].GetComponent<JewelBtn>().soulItem = gameObject;
                        gameObject.transform.position = jewelChang[i].transform.position;
                        gameObject.transform.parent = jewelChang[i].transform;
                    }
                }
            }
        }
        else if (firstValue == 1)
        {
            //for (int i = 0; i < jewelChang.Length; i++)
            //{
            //    jewelChang[i] = GameObject.Find("Stone" + i);
            //    if (jewelChang[i].GetComponent<JewelBtn>().stoneIn == false)
            //    {
            //        if (btnIn[0] == false)
            //        {
            //            btnIn[0] = true;
            //            btnIn[1] = false;
            //            jewelChang[i].GetComponent<JewelBtn>().stoneIn = true;
            //            jewelChang[i].GetComponent<JewelBtn>().soulItem = gameObject;
            //            gameObject.transform.localPosition = pos[soulSkillNumber];
            //            gameObject.transform.parent = jewelChang[i].transform;
            //        }
            //    }
            //}
            for (int i = 0; i < pos.Length; i++)
            {
                jewelChang[i] = GameObject.Find("Stone" + i);
                gameObject.transform.parent = jewelChang[i].transform;
                gameObject.transform.localPosition = pos[soulSkillNumber];
            }
        }
    }
	
	void Update ()
    {
		
	}
    public void SaveStonePosition()
    {
        PlayerPrefs.SetFloat("StonePosX" + soulSkillNumber.ToString(), parentPos.x);
        PlayerPrefs.SetFloat("StonePosY" + soulSkillNumber.ToString(), parentPos.y);
        PlayerPrefs.SetFloat("StonePosZ" + soulSkillNumber.ToString(), parentPos.z);
        Debug.Log(parentPos);
        PlayerPrefs.SetInt("FirstValue6", firstValue);
    }
    public void LoadedStonePositon()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            pos[soulSkillNumber].x = PlayerPrefs.GetFloat("StonePosX" + soulSkillNumber.ToString(), parentPos.x);
            pos[soulSkillNumber].y = PlayerPrefs.GetFloat("StonePosY" + soulSkillNumber.ToString(), parentPos.y);
            pos[soulSkillNumber].z = PlayerPrefs.GetFloat("StonePosZ" + soulSkillNumber.ToString(), parentPos.z);
        }
        //firstValue = PlayerPrefs.GetInt("FirstValue6", firstValue);
        Debug.Log("불러온다");
    }
}
