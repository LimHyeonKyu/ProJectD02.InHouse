using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour {

    public float goldCount;
    public float soulCount;
    public float reinFoceValue;
    public GameObject goldLabel;
    public GameObject soulLabel;
    private static MoneyManager _inStance = null;
    public static MoneyManager inStance
    {
        get
        {
            if (_inStance == null)
            {
                _inStance = FindObjectOfType(typeof(MoneyManager)) as MoneyManager;
            }
            return _inStance;
        }
    }

    void Awake ()
    {
        if (_inStance == null)
            _inStance = this;
        else if (_inStance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
       // LoadedMoney();
    }
	
	void Update ()
    {
        Scene sc = SceneManager.GetActiveScene();
        if(sc.buildIndex==1)
        {
            goldLabel = GameObject.Find("GoldLabel");
            soulLabel = GameObject.Find("SoulLabel");
            goldLabel.GetComponent<UILabel>().text = FoMatCount(goldCount);
            soulLabel.GetComponent<UILabel>().text = FoMatCount(soulCount);
        }
        //SaveMoney();
    }
    public void SaveMoney()
    {
        PlayerPrefs.SetFloat("Gold", goldCount);
        PlayerPrefs.SetFloat("Soul", soulCount);
       // PlayerPrefs.SetFloat("ReinForceValue", reinFoceValue);
    }
    public void LoadedMoney()
    {
        goldCount = PlayerPrefs.GetFloat("Gold", goldCount);
        soulCount = PlayerPrefs.GetFloat("Soul", soulCount);
        //reinFoceValue = PlayerPrefs.GetFloat("ReinForceValue", reinFoceValue);
    }
    public string FoMatCount(float data)//숫자단위마다 ','을 찍어주는 함수
    {
        return string.Format("{0:#,###0}", data);
    }
}
