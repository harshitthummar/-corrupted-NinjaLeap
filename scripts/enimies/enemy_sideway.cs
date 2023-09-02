using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sideway : MonoBehaviour
{
    [SerializeField] private float movementdistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private float leftedge;
    private float rightedge;
    private bool movingleft;

    private void Awake()
    {
        leftedge = transform.position.x - movementdistance;
        rightedge = transform.position.y + movementdistance;
    }
    private void Update()
    {
        if (movingleft)
        {
            if(transform.position.x > leftedge)
            {
                transform.position=new Vector3(transform.position.x-speed*Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            {
                movingleft = false;
            }
        }
        else
        {
            if (transform.position.x < rightedge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().takedamage(damage);
        }
    }
}
