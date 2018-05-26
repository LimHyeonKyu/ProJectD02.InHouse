using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelBtnManager : MonoBehaviour {

    public GameObject[] jewelBtn;
    public GameObject[] equipSlot;
    public GameObject[] equipBtn;
    public GameObject clickBtn;
    public GameObject releaseBtn;
    void Awake()
    {
        for (int i = 0; i < jewelBtn.Length; i++)
        {
            jewelBtn[i] = GameObject.Find("Stone" + i);
            jewelBtn[i].AddComponent<JewelBtn>();
        }
        for (int a = 0; a < equipSlot.Length; a++)
        {
            equipSlot[a] = GameObject.Find("Slot" + a);
            equipSlot[a].AddComponent<EquipSlotBtn>();
        }
    }

    void Update()
    {

    }
    public void Equip()//장착버튼
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (clickBtn != null)
        {
            if(clickBtn.GetComponent<JewelBtn>().soulItem!=null)
            {
                for (int a = 0; a < equipSlot.Length; a++)
                {
                    if (equipSlot[a].GetComponent<EquipSlotBtn>().soulIn == false)
                    {
                        if (clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().btnIn == true)
                        {
                            clickBtn.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().btnIn = false;
                            clickBtn.GetComponent<JewelBtn>().stoneIn = false;
                            equipSlot[a].GetComponent<EquipSlotBtn>().soulIn = true;
                            equipSlot[a].GetComponent<EquipSlotBtn>().item = clickBtn.GetComponent<JewelBtn>().soulItem;
                            equipSlot[a].GetComponent<EquipSlotBtn>().equipCount = 1;
                            clickBtn.GetComponent<JewelBtn>().clickCount = 0;
                            clickBtn.GetComponent<JewelBtn>().soulItem.transform.position = equipSlot[a].transform.position;
                        }
                    }
                }
            }
        }
    }
    public void release()//해제 버튼
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (releaseBtn.GetComponent<EquipSlotBtn>().equipCount == 1)
        {
            for (int a = 0; a < jewelBtn.Length; a++)
            {
                if (jewelBtn[a].GetComponent<JewelBtn>().stoneIn == false)
                {
                    if(releaseBtn.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().btnIn == false)
                    {
                        releaseBtn.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().btnIn = true;
                        releaseBtn.GetComponent<EquipSlotBtn>().equipCount = 0;
                        jewelBtn[a].GetComponent<JewelBtn>().stoneIn = true;
                        releaseBtn.GetComponent<EquipSlotBtn>().soulIn = false;
                        jewelBtn[a].GetComponent<JewelBtn>().soulItem = releaseBtn.GetComponent<EquipSlotBtn>().item;
                        releaseBtn.GetComponent<EquipSlotBtn>().item.transform.position = jewelBtn[a].transform.position;
                    }
                }
            }
        }
    }
}
