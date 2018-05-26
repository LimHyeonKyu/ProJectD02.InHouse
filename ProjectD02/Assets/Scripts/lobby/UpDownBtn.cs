using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class UpDownBtn : MonoBehaviour {

    public UILabel[] rfuILabel;//강화수치 라벨
    public ButtonManager btmMg;

    private void Start()
    {
        btmMg= GameObject.Find("BtnManager").GetComponent<ButtonManager>();
    }

    void Update()
    {
        
    }
    public void UpBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        for (int i = 0; i < LevelManager.instanCe.lv.Length; i++)
        {
            if(btmMg.target==btmMg.buttons[i])
            { 
                if (LevelManager.instanCe.lv[i] <= 10)
                {
                    if (MoneyManager.inStance.reinFoceValue <= MoneyManager.inStance.goldCount && MoneyManager.inStance.goldCount >= 0)
                    //강화값이 MoneyManager 싱글톤의 골드값보다 작거나 같은경우와 MoneyManager 싱글톤 골드값이 0보다 크거나 같을경우 강화시킨다
                    {
                        MoneyManager.inStance.goldCount -= MoneyManager.inStance.reinFoceValue;
                        MoneyManager.inStance.reinFoceValue *= 2;
                        LevelManager.instanCe.lv[i] += 1;
                    }
                }
            }
            if (LevelManager.instanCe.lv[i] >= 10)
            {
                LevelManager.instanCe.lv[i] = 10;
            }
            rfuILabel[i].text = Convert.ToString("LV " + LevelManager.instanCe.lv[i]);
        }
    }
}
