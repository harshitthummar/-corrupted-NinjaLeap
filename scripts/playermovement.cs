using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumppower;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask walllayer;
    private float horizontalinput;
    private float walljumpcooldown;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        //get all values of player which has rigitbody2d and store it here with getcomponetnt()
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");


        //to set player move right or left  
        if (horizontalinput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalinput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }




        //setting animation state parameters
        anim.SetBool("run", horizontalinput != 0);
        anim.SetBool("grounded", isgrounded());

        if (walljumpcooldown > 0.2f)
        {
            
            body.velocity = new Vector2(horizontalinput * speed, body.velocity.y);

            if(onwall() && !isgrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 5 ;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

        }
        else
        {
            walljumpcooldown += Time.deltaTime;
        }

    }
    private void Jump()
    {
        

        if(isgrounded() )
        {
            body.velocity = new Vector2(body.velocity.x, jumppower);
            anim.SetTrigger("jump");
        }
        else if(onwall() && !isgrounded())
        {
            if (horizontalinput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x),transform.localScale.y,transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            walljumpcooldown = 0;
           
        }
  
    }

    private bool isgrounded()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0, Vector2.down,0.1f, groundlayer);
        return raycasthit.collider != null;
    }

    private bool onwall()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,new Vector2(transform.localScale.x,0), 0.1f, walllayer);
        return raycasthit.collider != null;
    }
    public bool canattack()
    {
        return horizontalinput == 0  && !onwall();
    }
}
