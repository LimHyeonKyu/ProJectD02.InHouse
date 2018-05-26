using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour {

    public GameObject[] btns;
    public GameObject selector;
    public GameObject[] windows;
    public GameObject bgmMg;

    private void Start()
    {
        MinionBtn();
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i] = GameObject.Find("Btn" + i);
            btns[i].AddComponent<Btn>();
        }
    }
    void Update()
    {
        bgmMg = GameObject.Find("BGMManager");
    }

    public void MinionBtn()
    {
        windows[0].SetActive(true);
        windows[1].SetActive(false);
        windows[2].SetActive(false);
    }

    public void WeaponBtn()
    {
        windows[0].SetActive(false);
        windows[1].SetActive(true);
        windows[2].SetActive(false);
    }

    public void ShopBtn()
    {
        windows[0].SetActive(false);
        windows[1].SetActive(false);
        windows[2].SetActive(true);
    }

    public void WolrdBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(2);
    }

    public void LobbyBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(1);
    }
    public void IntroBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        SceneManager.LoadScene(0);
        bgmMg.GetComponent<AudioSource>().clip = MusicManager.instance.bgmClip[0];
        MusicManager.instance.auDios.Play();
    }
}
