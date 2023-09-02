using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [Header ("FireTrap Timer")]
    [SerializeReference] private float activationdelay;
    [SerializeReference] private float activetime;
    [SerializeField] private float damage;
    private Animator anim;
    private SpriteRenderer spiterend;
    private bool triggered;
    private bool active;
    private Health player;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        spiterend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(activefiretrap());

            player = collision.GetComponent<Health>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
    }

    private void Update()
    {
        if (active && player != null)
            player.takedamage(damage);
    }
    private IEnumerator activefiretrap()
    {
        //now when this trigger we also have to set animations
        triggered = true;
        spiterend.color =Color.red;//when triggers it becomes red
      
        yield return new WaitForSeconds(activationdelay);

        active = true;
        anim.SetBool("activated", true);
        //now we activate our fire fire some seconds 

        spiterend.color = Color.white;//after that notify it will became normal
        yield return new WaitForSeconds(activetime);
        triggered = false;
        active = false;

        anim.SetBool("activated", false);
    }
}
