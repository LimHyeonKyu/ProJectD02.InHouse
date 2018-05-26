using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private static LevelManager _instanCe = null;
    public static LevelManager instanCe
    {
        get
        {
            if (_instanCe == null)
            {
                _instanCe = FindObjectOfType(typeof(LevelManager)) as LevelManager;
            }
            return _instanCe;
        }
    }
    public float[] lv;

    void Start ()
    {
        if (_instanCe == null)
            _instanCe = this;
        else if (_instanCe != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        LoadedLv();
	}
	
	void Update ()
    {
        SaveLv();
	}
    public void SaveLv()
    {
        PlayerPrefs.SetFloat("UnitLevel1", lv[0]);
        PlayerPrefs.SetFloat("UnitLevel2", lv[1]);
        PlayerPrefs.SetFloat("UnitLevel3", lv[2]);
        PlayerPrefs.SetFloat("UnitLevel4", lv[3]);
        PlayerPrefs.SetFloat("UnitLevel5", lv[4]);
        PlayerPrefs.SetFloat("UnitLevel6", lv[5]);
        PlayerPrefs.SetFloat("UnitLevel7", lv[6]);
        PlayerPrefs.SetFloat("UnitLevel8", lv[7]);
        PlayerPrefs.SetFloat("UnitLevel9", lv[8]);
    }
    public void LoadedLv()
    {
        lv[0] = PlayerPrefs.GetFloat("UnitLevel1", lv[0]);
        lv[1] = PlayerPrefs.GetFloat("UnitLevel2", lv[1]);
        lv[2] = PlayerPrefs.GetFloat("UnitLevel3", lv[2]);
        lv[3] = PlayerPrefs.GetFloat("UnitLevel4", lv[3]);
        lv[4] = PlayerPrefs.GetFloat("UnitLevel5", lv[4]);
        lv[5] = PlayerPrefs.GetFloat("UnitLevel6", lv[5]);
        lv[6] = PlayerPrefs.GetFloat("UnitLevel7", lv[6]);
        lv[7] = PlayerPrefs.GetFloat("UnitLevel8", lv[7]);
        lv[8] = PlayerPrefs.GetFloat("UnitLevel9", lv[8]);
    }
}
