using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public float speed;
    public float enemyHP;
    public float damage;
    public GameObject player;
    public GameObject unit;
    public enum ENEMYSTATE
    {
        IDLE,
        MOVE,
        ATTACK,
        DEAD
    }
    public ENEMYSTATE enemystate;
	void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	void Update ()
    {
        switch (enemystate)
        {
            case ENEMYSTATE.IDLE:

                break;
            case ENEMYSTATE.MOVE:
                transform.Translate(-speed * Time.deltaTime, 0, 0);//왼쪽이동
                break;
            case ENEMYSTATE.ATTACK:

                break;
            case ENEMYSTATE.DEAD:
                Destroy(gameObject);//오브젝트를 파괴한다
                break;
            default:
                break;
        }
		if(transform.position.x <-1.9f)//만약 오브젝트 포지션x값이 -1.9보다 작아진다면
        {
            enemystate = ENEMYSTATE.DEAD;//에너미스테이트를 DEAD로 바꾼다
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Unit1")//만약 태그된게 Unit1이라면
        {
            enemystate = ENEMYSTATE.DEAD;//enemystate를 DEAD로 바꾼다
        }
        if (col.gameObject.tag == "Unit2")//만약 태그된게 Unit1이라면
        {
            enemystate = ENEMYSTATE.DEAD;//enemystate를 DEAD로 바꾼다
        }
        if (col.gameObject.tag == "Unit3")//만약 태그된게 Unit1이라면
        {
            enemystate = ENEMYSTATE.DEAD;//enemystate를 DEAD로 바꾼다
        }
        if (col.gameObject.tag == "Player")//만약 태그된게 Player라면
        {
            enemystate = ENEMYSTATE.DEAD;//enemystate를 DEAD로 바꾼다
        }
    }
}
