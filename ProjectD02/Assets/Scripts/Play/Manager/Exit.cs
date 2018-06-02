﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public GameObject bgmMG;

    void Awake()
    {
        bgmMG = GameObject.Find("BGMManager");
    }
    void OnClick()
    {
        SceneManager.LoadScene(2);
        bgmMG.GetComponent<AudioSource>().clip = MusicManager.instance.bgmClip[1];
        MusicManager.instance.auDios.Play();
    }
}
