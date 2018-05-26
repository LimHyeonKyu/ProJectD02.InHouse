using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlotBtn : MonoBehaviour {

    public JewelBtnManager jewelMg;
    public GameObject item;
    public bool soulIn = false;
    public int equipCount;

    void Start()
    {
        jewelMg = GameObject.Find("JewelBtnManager").GetComponent<JewelBtnManager>();
    }


    void Update()
    {
        if(soulIn==false)
        {
            item = null;
        }
    }
    void OnClick()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        jewelMg.equipBtn[0].SetActive(false);
        jewelMg.equipBtn[1].SetActive(true);
        jewelMg.releaseBtn = gameObject;
    }
}
