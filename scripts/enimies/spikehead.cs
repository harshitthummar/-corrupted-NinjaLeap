using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class spikehead : enemy_damage
{

    [Header ("Spikehead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerlayer;
    private Vector3 destination;
    [SerializeField] private float checkdelay;
    private float checktimer;
    private bool attacking;
    private Vector3[] direction = new Vector3[4];

    private void OnEnable()
    {
        stop();
    } 
    private void Update()
    {
        if(attacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);

        }
        else
        {
            checktimer += Time.deltaTime;
            if(checktimer > checkdelay)
            {
                checkforplayer();
            }
        }
    }
    private void checkforplayer()
    {
        calculatedirections();
        for (int i = 0; i < direction.Length; i++)
        {
            Debug.DrawRay(transform.position, direction[i], UnityEngine.Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction[i],range,playerlayer);

            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = direction[i];
                checktimer = 0;
            }
        }
    }
    private void calculatedirections()
    {
        direction[0] = transform.right * range;//right
        direction[1] = -transform.right * range;//left
        direction[2]=  transform.up * range;//up
        direction[3]= -transform.up * range;//down 
    }
    private void stop()
    {
        destination=transform.position;
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        stop();
    }
  
}
