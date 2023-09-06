using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    private float cooldowntimer = Mathf.Infinity;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballsound;
    private Animator anim;
    private playermovement playermovement;

    private void Awake()
    {
     anim = GetComponent<Animator>();
     playermovement = GetComponent<playermovement>();

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && cooldowntimer > attackcooldown && playermovement.canattack())
        {
            attack();
            
        }
        cooldowntimer += Time.deltaTime;
    }

    private void attack()
    {
        soundmanager.instance.playsound(fireballsound);
        anim.SetTrigger("attack");
        cooldowntimer = 0;
        fireballs[Findfireball()].transform.position=firepoint.position;
        fireballs[Findfireball()].GetComponent<projectile>().setdirection(Mathf.Sign(transform.localScale.x));

    }

    private int Findfireball()
    {
        for(int i = 0; i < fireballs.Length;i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    
    }
   
}
