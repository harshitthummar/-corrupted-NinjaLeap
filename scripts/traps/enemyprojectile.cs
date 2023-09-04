using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectile : enemy_damage
{
    [SerializeField] private float speed;
    [SerializeField] private float resettime;
    private float lifetime;
    private Animator anim;
    private bool hit;
    private BoxCollider2D box;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    public void activateprojectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        box.enabled = true;
    }
    private void Update()
    {
        if (hit) { return; }
        float movementspeed=speed * Time.deltaTime;
        transform.Translate(movementspeed,0,0);
        if(lifetime > resettime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit=true;
        base.OnTriggerEnter2D(collision);//first goto parent script and then next method
        box.enabled = false;

        if (anim != null)
        {
            anim.SetTrigger("explo"); //if fireall then explode 
        }
        else
        {
            gameObject.SetActive(false);//of arrow then dwactivate the object
        }
    }

    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}

