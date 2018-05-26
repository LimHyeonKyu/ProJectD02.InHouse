using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class UpDownBtn : MonoBehaviour {

    public UILabel rfuILabel;//강화수치 라벨

    private void Start()
    {
        
    }

    void Update()
    {
        SetNum();
    }
    public void UpBtn()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if(LevelManager.instanCe.lv[0] <= 10)
        {
            if (MoneyManager.inStance.reinFoceValue<=MoneyManager.inStance.goldCount && MoneyManager.inStance.goldCount>=0)
            //강화값이 MoneyManager 싱글톤의 골드값보다 작거나 같은경우와 MoneyManager 싱글톤 골드값이 0보다 크거나 같을경우 강화시킨다
            {
                MoneyManager.inStance.goldCount -= MoneyManager.inStance.reinFoceValue;
                MoneyManager.inStance.reinFoceValue *= 2;
                LevelManager.instanCe.lv[0] += 1;
            }
        }
        if (LevelManager.instanCe.lv[0] >= 10)
        {
            LevelManager.instanCe.lv[0] = 10;
        }
    }

    void SetNum()
    {
        if (rfuILabel != null)
        {
            rfuILabel.text = Convert.ToString("LV "+ LevelManager.instanCe.lv[0]);     //업,다운버튼을 누를때 바뀐 레벨을 스트링으로 라벨에 넣어줌
        }
    }
}
