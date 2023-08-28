using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField]private float speed;
    private bool hit;
    private float direction;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxcolider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxcolider = GetComponent<BoxCollider2D>(); 
    }

    private void Update()
    {
        if (hit) return;
        
        float movementspeed = speed* Time.deltaTime* direction;
        transform.Translate(movementspeed,0,0);

        lifetime += Time.deltaTime;
        if(lifetime > 5) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxcolider.enabled = false;
        anim.SetTrigger("explo");
       

    }

    public void setdirection(float _direction)
    {
        lifetime = 0;
        direction=_direction;
        gameObject.SetActive(true);
        hit = false;
        boxcolider.enabled=true;

        float localscalex = transform.localScale.x;
        if(Mathf.Sign(localscalex) != _direction)
        {
            localscalex = -localscalex;

        }
        transform.localScale = new Vector3(localscalex,transform.localScale.y,transform.localScale.z);
    }

    public void deactivate()
    {
        gameObject.SetActive(false); 
    }
}
