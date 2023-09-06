using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranged_enemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackcooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Rangeattack Parameters")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballes;

    [Header("Collider Parameters")]
    [SerializeField] private float coliderdistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerlayer;
    private float cooldowntimer = Mathf.Infinity;

    [Header("Sounds")]
    [SerializeField] private AudioClip fireballsound;

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

            if (cooldowntimer >= attackcooldown)
            {
                //attack
                cooldowntimer = 0;
                anim.SetTrigger("rangeattack");
                soundmanager.instance.playsound(fireballsound);
            }
        }
        //if you see the player stop petroling otherwise continue petroling
        if (enemypetrol != null)
        {
            enemypetrol.enabled = !playerinsight();
        }

    }

    private void rangedattack()
    {
        cooldowntimer = 0;
        //shoot projectile

        fireballes[findfireball()].transform.position = firepoint.position;
        fireballes[findfireball()].GetComponent<enemyprojectile>().activateprojectile();
    }

    private int findfireball()
    {
        for (int i = 0; i < fireballes.Length; i++)
        {
            if (!fireballes[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }
    private bool playerinsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * coliderdistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            , 0, Vector2.left
            , 0, playerlayer);

       
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * coliderdistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
