using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {

    public GameObject[] skill;
    public GameObject manaMG;
    public GameObject player;
    public UISprite[] skillImage;
    public UILabel[] skillcostLabel;
    public float skillmo;
    public float statetime;
    public bool skillstart = false;
    public Dictionary<int, string> skillIcon;
    void Start ()
    {
        skillIcon = new Dictionary<int, string>();
        manaMG = GameObject.Find("ManaManager");
        player = GameObject.Find("Player");
        skillIcon.Add(0, "Stone0");
        skillIcon.Add(1, "Stone1");
        skillIcon.Add(2, "Stone2");
        skillIcon.Add(3, "Stone3");
        skillIcon.Add(4, "Stone4");
        skillIcon.Add(5, "Stone5");
        skillIcon.Add(6, "Stone6");
        skillIcon.Add(7, "Stone7");
        skillIcon.Add(8, "Stone8");
        for (int i = 0; i < SoulSkillManager.INSTANCE.soulskillNunber.Count; i++)
        {
            if (SoulSkillManager.INSTANCE.soulskillNunber != null && SoulSkillManager.INSTANCE.skillCostValue!=null)
            {
                skillImage[i].GetComponent<UISprite>().spriteName = skillIcon[SoulSkillManager.INSTANCE.soulskillNunber[i]];
                skillImage[i].gameObject.SetActive(true);
                skillcostLabel[i].text = SoulSkillManager.INSTANCE.skillCostValue[i].ToString();
            }
        }
     }
	
	void Update ()
    {
        if(skillstart == true)
        {
            player.GetComponent<PlayerController>().moveSpeed = 0;
            statetime += Time.deltaTime;
            if (statetime > skillmo)
            {
                Instantiate(skill[0], transform.position, transform.rotation);//skill배열의 0번을 생성한다
                player.GetComponent<PlayerController>().playstate = PlayerController.PLAYSTATE.NONE;
                skillstart = false;
                statetime = 0;
                player.GetComponent<PlayerController>().moveSpeed = 0.4f;
            }
        }               
	}

    public void Skill1()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (manaMG.GetComponent<ManaManager>().manaCount >= SoulSkillManager.INSTANCE.skillCostValue[0])
        {
            player.GetComponent<PlayerController>().playstate = PlayerController.PLAYSTATE.Attack1;
            manaMG.GetComponent<ManaManager>().manaCount -= SoulSkillManager.INSTANCE.skillCostValue[0];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(SoulSkillManager.INSTANCE.skillCostValue[0] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
          
            skillstart = true;
        }
    }   

    public void Skill2()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (manaMG.GetComponent<ManaManager>().manaCount >= SoulSkillManager.INSTANCE.skillCostValue[1])
        {          
            manaMG.GetComponent<ManaManager>().manaCount -= SoulSkillManager.INSTANCE.skillCostValue[1];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(SoulSkillManager.INSTANCE.skillCostValue[1] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
            Instantiate(skill[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);       //skill배열의 1번을 생성한다

            skill[1].GetComponent<SkillController>().caster = player;
        }
    }
    public void Skill3()
    {
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (manaMG.GetComponent<ManaManager>().manaCount >= SoulSkillManager.INSTANCE.skillCostValue[2])
        {
            manaMG.GetComponent<ManaManager>().manaCount -= SoulSkillManager.INSTANCE.skillCostValue[2];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(SoulSkillManager.INSTANCE.skillCostValue[2] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
            Instantiate(skill[2], transform.position, transform.rotation);//skill배열의 2번을 생성한다
        }
    }
}
