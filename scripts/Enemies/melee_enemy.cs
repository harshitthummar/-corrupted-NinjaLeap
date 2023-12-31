using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_enemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackcooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float coliderdistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerlayer;
    private float cooldowntimer = Mathf.Infinity;

    [Header("Sounds Attack")]
    [SerializeField] private AudioClip swordattack;

    //refrences
    private Health playerhealth;
    private Animator anim;
    private enemypetrol enemypetrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemypetrol = GetComponentInParent<enemypetrol>();
    }
    
    private void Update()
    {
        cooldowntimer += Time.deltaTime;

        //attack only while player is on sight
        if (playerinsight())
        {
            
            if (cooldowntimer >= attackcooldown && playerhealth.currenthealth>0)
            {
                //attack
                cooldowntimer = 0;
                anim.SetTrigger("meleeattack");
                soundmanager.instance.playsound(swordattack);
            }
        }
        //if you see the player stop petroling otherwise continue petroling
        if(enemypetrol != null)
        {
            enemypetrol.enabled = !playerinsight(); 
        }
       
    }
    private bool playerinsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center+transform.right * range * transform.localScale.x * coliderdistance,
            new Vector3(boxCollider.bounds.size.x * range,boxCollider.bounds.size.y,boxCollider.bounds.size.z)
            , 0,Vector2.left
            ,0,playerlayer);

        if(hit.collider != null)
        {
            playerhealth= hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * coliderdistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void damageplayer()
    {
        if(playerinsight())
        {
            //damage player if he is in range
            playerhealth.takedamage(damage);
        }
    }
}
