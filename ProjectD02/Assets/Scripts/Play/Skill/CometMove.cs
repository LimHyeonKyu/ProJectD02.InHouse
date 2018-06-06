﻿using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class CometMove : MonoBehaviour {


    public GameObject target;
    public float cometAtk;
    public float speed = 1;

    CharacterController characterController;
  

    public void Awake()
    {

        //if(gameObject.name=="Comet0")
        //{
        //    target = cm.GetComponent<CometManager>().aoeTargets[0];
        //}


        //if (gameObject.name == "Comet1")
        //{
        //    target = cm.GetComponent<CometManager>().aoeTargets[1];
        //}



        //if (gameObject.name == "Comet2")
        //{
        //    target = cm.GetComponent<CometManager>().aoeTargets[2];
        //}



    }

    void Start()
    {

        characterController = GetComponent<CharacterController>();
        //for (int i = 0; i < cm.GetComponent<CometManager>().aoeTargets.Count; i++)
        //{
        //    target[i] = cm.GetComponent<CometManager>().aoeTargets[i];
        //    transform.parent = target[i].transform;
        //}

    }

	
	void Update ()
    {

        Vector3 dir = target.transform.position - transform.position;
        dir.y = -0.25f;
        dir.Normalize();
        characterController.SimpleMove(dir * speed);
       

        gameObject.transform.Translate(3 * Time.deltaTime, -5 * Time.deltaTime, 0);
        

    }

    public void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<UnitController>().GetDamage(cometAtk);
            Destroy(gameObject);
        }
     
    }

}
